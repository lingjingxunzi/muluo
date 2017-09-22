using System;
using System.IO;
using System.Text;
using MONO.Order.Test.FlowAgents;
using MONO.Order.Test.Models;
using MONO.Order.Test.Tools;
using System.Collections;
using MONO.Order.Test.LogWriter;

namespace MONO.Order.Test
{
    public class OrderHelper
    {
        public static void operationOrder()
        {
            try
            {
                foreach (FileInfo file in GetFilesAse("E://Distribution//Waitting"))
                {
                    var sr = new StreamReader(file.FullName, Encoding.Default);
                    String line;
                    try
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            var arr = line.Split(',');
                            if (arr.Length > 0)
                            {
                                var instance = AgentManager.GetAgentInstance(arr[0]);
                                var param = GetAgentParams(arr);
                                var startDate = DateTime.Now;
                                var str = instance.AgentRequest(param);
                                var endDate = DateTime.Now;
                                BaseCode.WriteLog("订单号:" + param.HistoriesKey + "接口:" + param.Carrier + "处理时间为:" + (endDate - startDate));
                                if (!string.IsNullOrEmpty(str))
                                {
                                    ContactException(str, file);//连接异常
                                    if (ContactClose(str, sr, file)) break;//全国移动偶尔出现访问关闭的情况
                                    str = instance.GetResultStr(str);//解析返回的xml文件
                                }
                                var url = GetUrl(str, arr);
                                var startBack = DateTime.Now;
                                HttpWebRequestTools.GetRequestByHttpWebDefault(url);//请求统一地址,通知自营系统订购状态
                                var endBack = DateTime.Now;
                                BaseCode.WriteLog("地址:" + url);
                                BaseCode.WriteLog("订单号:" + param.HistoriesKey + "数据返回:" + param.Carrier + "处理时间为:" + (endBack - startBack));

                            }
                        }
                        sr.Close();
                        var activedFolder = new DirectoryInfo("E://Distribution//Actived");
                        var defaultFolder = new DirectoryInfo("E://Distribution//Waitting");
                        if (activedFolder.GetFiles(file.Name).Length == 0 && defaultFolder.GetFiles(file.Name).Length == 1)
                        {
                            file.CopyTo("E://Distribution//Actived//" + file.Name);
                            file.Delete();
                        }
                        else
                        {
                            file.Delete();
                        }
                    }
                    catch (Exception ex)
                    {
                        BaseCode.WriteLog(ex.Message);
                        var activedFolder = new DirectoryInfo("E://Distribution//exception");
                        var defaultFolder = new DirectoryInfo("E://Distribution//Waitting");
                        if (activedFolder.GetFiles(file.Name).Length == 0 && defaultFolder.GetFiles(file.Name).Length == 1)
                        {
                            file.CopyTo("E://Distribution//exception//" + file.Name);
                            file.Delete();
                        }
                        else
                        {
                            file.Delete();
                        }
                    }
                }
            }
            catch (Exception readEx)
            {
                BaseCode.WriteLog(readEx.ToString());
            }
        }

        private static AgentParamBase GetAgentParams(string[] arr)
        {
            return new AgentParamBase
            {
                MobilePhone = arr[2],
                HistoriesKey = arr[3],
                Carrier = arr[0],
                ProductId = arr[1],
                PakgeSize = int.Parse(arr[4])
            };
        }

        private static string GetUrl(string str, string[] arr)
        {
            return (arr.Length == 6 ? arr[5] : "http://113.207.124.164/Order/GetOrderResultCallBack.aspx") + "?data=" + str + "&TransKey=" + arr[3];
        }

        private static bool ContactClose(string str, StreamReader sr, FileInfo file)
        {
            if (str.Contains("error_description"))
            {
                sr.Close();
                var exFolder = new DirectoryInfo("E://Distribution//exception");

                if (exFolder.GetFiles(file.Name).Length == 0)
                {
                    file.CopyTo("E://Distribution//exception//" + file.Name);
                    file.Delete();
                }
                else
                {
                    file.Delete();
                }
                return true;
            }
            return false;
        }

        private static void ContactException(string str, FileInfo file)
        {
            if (str.Contains("error_description"))
                throw new Exception("连接异常，移动至待处理文件夹，订单号：" + file.Name);
        }


        public static FileInfo[] GetFilesAse(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles("*.txt");
            //Array.Sort(files, delegate(FileInfo x, FileInfo y) { return x.CreationTime.CompareTo(y.CreationTime); });
            return files;
        }
    }
}
