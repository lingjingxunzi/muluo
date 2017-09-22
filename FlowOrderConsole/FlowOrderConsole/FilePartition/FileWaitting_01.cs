using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using FlowOrderConsole.FlowAgents;
using FlowOrderConsole.Models;
using FlowOrderConsole.Tools.RequestUrl;

namespace FlowOrderConsole.FilePartition
{
    public class FileWaitting_01 : FileBase
    {
        private CM023DocManager documentManager_01;

        public FileWaitting_01(CM023DocManager dm)
        {
            this.documentManager_01 = dm;
        }

        public static void Start(CM023DocManager dm)
        {
            InitQueInfo(dm, readFolderName_01, waittingFolderName_01);
            dm.t = new Thread(new FileWaitting_01(dm).Run);
            dm.t.Start();
        }

        public void Run()
        {
            while (true)
            {
                if (documentManager_01.IsDoctumentAvailable)
                {

                    OrderModels doc = documentManager_01.GetDocument();
                    BaseCode.WriteLog("执行：" + doc.Name );
                    if (doc == null) break;
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
                        if (string.IsNullOrEmpty(str) || str.Contains("error_description"))
                            throw new Exception("连接失败！详情：" + str);
                        str = instance.GetResultStr(str);//解析返回的字符串
                        var url = GetUrl(str, doc.BackUrl, doc.HisKey);
                        HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                        BaseCode.WriteLog(url );
                        MoveFile(doc.Name, waittingFolderName_01, completeFolderName_01);
                    }
                    catch (Exception ex)
                    {
                        MoveFile(doc.Name, waittingFolderName_01, exceptionFolderName_01);
                    }
                }
                else
                {
                    InitQueInfo(this.documentManager_01, readFolderName_01, waittingFolderName_01);
                }
            }
        }

        public static string logFlag_01 = "all";
        static string readFolderName_01 = "D://Distribution//01//";
        static string exceptionFolderName_01 = "D://Distribution//exception//";
        static string completeFolderName_01 = "D://Distribution//01//Actived//";
        static string waittingFolderName_01 = "D://Distribution//01//waitting//";

    }
}
