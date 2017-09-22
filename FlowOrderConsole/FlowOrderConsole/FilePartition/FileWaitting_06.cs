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
    public class FileWaitting_06 : FileBase
    {
        private CM023DocManager documentManager_06;

        public FileWaitting_06(CM023DocManager dm)
        {
            this.documentManager_06 = dm;
        }

        public static void Start(CM023DocManager dm)
        {
            InitQueInfo(dm, readFolderName_06, waittingFolderName_06);
            dm.t = new Thread(new FileWaitting_06(dm).Run);
            dm.t.Start();
        }

        public void Run()
        {
            while (true)
            {
                if (documentManager_06.IsDoctumentAvailable)
                {
                    OrderModels doc = documentManager_06.GetDocument();
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
                        MoveFile(doc.Name, waittingFolderName_06, completeFolderName_06);
                    }
                    catch (Exception ex)
                    {
                        MoveFile(doc.Name, waittingFolderName_06, exceptionFolderName_06);
                    }
                }
                else
                {
                    InitQueInfo(documentManager_06, readFolderName_06, waittingFolderName_06);
                }
            }
        }
        static string readFolderName_06 = "D://Distribution//06//";
        static string exceptionFolderName_06 = "D://Distribution//exception//";
        static string completeFolderName_06 = "D://Distribution//06//Actived//";
        static string waittingFolderName_06 = "D://Distribution//06//waitting//";
         
    }
}
