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
    public class FileWaitting_03 : FileBase
    {
        private CM023DocManager documentManager_03;

        public FileWaitting_03(CM023DocManager dm)
        {
            this.documentManager_03 = dm;
        }

        public static void Start(CM023DocManager dm)
        {
            InitQueInfo(dm, readFolderName_03, waittingFolderName_03);
             dm.t = new Thread(new FileWaitting_03(dm).Run) ;
            dm.t.Start();
        }

        public void Run()
        {
            while (true)
            {
                if (documentManager_03.IsDoctumentAvailable)
                {
                    OrderModels doc = documentManager_03.GetDocument();
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
                        MoveFile(doc.Name, waittingFolderName_03, completeFolderName_03);
                    }
                    catch (Exception ex)
                    {
                        MoveFile(doc.Name, waittingFolderName_03, exceptionFolderName_03);
                    }
                }
                else
                {
                    InitQueInfo(documentManager_03, readFolderName_03, waittingFolderName_03);
                }
            }
        }
        static string readFolderName_03 = "D://Distribution//03//";
        static string exceptionFolderName_03 = "D://Distribution//exception//";
        static string completeFolderName_03 = "D://Distribution//03//Actived//";
        static string waittingFolderName_03 = "D://Distribution//03//waitting//";
        static string logFlag_03 = "03";
    }
}
