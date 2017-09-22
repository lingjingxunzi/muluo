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
    public class FileWaitting_04 : FileBase
    {
        private CM023DocManager documentManager_04;

        public FileWaitting_04(CM023DocManager dm)
        {
            this.documentManager_04 = dm;
        }

        public static void Start(CM023DocManager dm)
        {
            InitQueInfo(dm, readFolderName_04, waittingFolderName_04);
            dm.t = new Thread(new FileWaitting_04(dm).Run);
            dm.t.Start();
        }

        public void Run()
        {
            while (true)
            {
                if (documentManager_04.IsDoctumentAvailable)
                {
                    OrderModels doc = documentManager_04.GetDocument();
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
                        MoveFile(doc.Name, waittingFolderName_04, completeFolderName_04);
                    }
                    catch (Exception ex)
                    {
                        MoveFile(doc.Name, waittingFolderName_04, exceptionFolderName_04);
                    }
                }
                else
                {
                    InitQueInfo(documentManager_04, readFolderName_04, waittingFolderName_04);
                }
            }
        }
        static string readFolderName_04 = "D://Distribution//04//";
        static string exceptionFolderName_04 = "D://Distribution//exception//";
        static string completeFolderName_04 = "D://Distribution//04//Actived//";
        static string waittingFolderName_04 = "D://Distribution//04//waitting//";
        static string logFlag_04 = "04";
    }
}
