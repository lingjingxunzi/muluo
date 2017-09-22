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
    public class FileCT023 : FileBase
    {
        private CM023DocManager documentManager_ct023;

        public FileCT023(CM023DocManager dm)
        {
            this.documentManager_ct023 = dm;
        }

        public static void Start(CM023DocManager dm)
        {
            InitQueInfo(dm, readFolderName_cm023, waittingFolderName_cm023);
            dm.t = new Thread(new FileCT023(dm).Run);
            dm.t.Start();
        }

        public void Run()
        {
            while (true)
            {
                if (documentManager_ct023.IsDoctumentAvailable)
                {
                    OrderModels doc = documentManager_ct023.GetDocument();
                    BaseCode.WriteLog(doc.Name);
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
                        BaseCode.WriteLog(str);
                        if (string.IsNullOrEmpty(str) || str.Contains("error_description"))
                            throw new Exception("连接失败！详情：" + str);
                        str = instance.GetResultStr(str);//解析返回的字符串
                        if (str.Contains("连接Boss失败"))
                            throw new Exception("连接失败！详情：" + str);
                        var url = GetUrl(str, doc.BackUrl, doc.HisKey);
                        BaseCode.WriteLog("测试是否新版本："+url.Replace("},",","));
                        BaseCode.WriteLog(url);
                        HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                        MoveFile(doc.Name, waittingFolderName_cm023, completeFolderName_cm023);
                    }
                    catch (Exception ex)
                    {
                        BaseCode.WriteLog(ex.Message + "订单号：" + doc.HisKey);
                        MoveFile(doc.Name, waittingFolderName_cm023, exceptionFolderName_cm023);
                    }
                }
                else
                {
                    InitQueInfo(documentManager_ct023, readFolderName_cm023, waittingFolderName_cm023);
                }
            }
        }

         
        static string readFolderName_cm023 = "D://Distribution//CT023//";
        static string exceptionFolderName_cm023 = "D://Distribution//CT023//";
        static string completeFolderName_cm023 = "D://Distribution//CT023//Actived//";
        static string waittingFolderName_cm023 = "D://Distribution//CT023//waitting//";

    }
}
