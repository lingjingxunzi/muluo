using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using FlowOrderConsole.FlowAgents;
using FlowOrderConsole.Models;
using FlowOrderConsole.Tools.RequestUrl;

namespace FlowOrderConsole.FilePartition
{
    public class FileException : FileBase
    {
        private CM023DocManager documentManager_ex;

        public FileException(CM023DocManager dm)
        {
            this.documentManager_ex = dm;
        }

        public static void Start(CM023DocManager dm)
        {
            InitQueInfo(dm, readFolderName_ex, waittingFolderName_ex);
            dm.t = new Thread(new FileException(dm).Run);
            dm.t.Start();
        }

        public void Run()
        {
            while (true)
            {
                if (documentManager_ex.IsDoctumentAvailable)
                {
                    OrderModels doc = documentManager_ex.GetDocument();
                    BaseCode.WriteLog(doc.Name );
                    try
                    {
                        var instance = AgentManager.GetAgentInstance(doc.Carrier);
                        var param = new AgentParamBase
                        {
                            MobilePhone = doc.Mobile,
                            HistoriesKey = doc.HisKey,
                            Carrier = doc.Carrier,
                            ProductId = doc.Code,
                            PakgeSize = int.Parse(doc.Size)
                        };
                        var str = instance.AgentRequest(param);//订购
                        BaseCode.WriteLog(str );
                        if (string.IsNullOrEmpty(str) || str.Contains("error_description"))
                            throw new Exception("连接失败！详情：" + str);
                        str = instance.GetResultStr(str);//解析返回的字符串
                        var url = GetUrl(str, doc.BackUrl, doc.HisKey);
                        BaseCode.WriteLog(url );
                        HttpWebRequestTools.GetRequestByHttpWebDefault(url);

                        MoveFile(doc.Name, waittingFolderName_ex, completeFolderName_ex);
                    }
                    catch (Exception ex)
                    {
                        BaseCode.WriteLog(ex.Message + "订单号：" + doc.HisKey );
                        MoveFile(doc.Name, waittingFolderName_ex, exceptionFolderName_ex);
                    }
                }
            }
        }
        static string readFolderName_ex = "D://Distribution//exception//";
        static string exceptionFolderName_ex = "D://Distribution//08//";
        static string completeFolderName_ex = "D://Distribution//Actived//";
        static string waittingFolderName_ex = "D://Distribution//exception//waitting//";
        static string logFlag_ex = "ex";
    }
}
