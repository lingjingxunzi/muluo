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
    public class FileWaitting_08 : FileBase
    {
        private CM023DocManager documentManager_08;

        public FileWaitting_08(CM023DocManager dm)
        {
            this.documentManager_08 = dm;
        }

        public static void Start(CM023DocManager dm)
        {
            InitQueInfo(dm, readFolderName_08, waittingFolderName_08);
            dm.t = new Thread(new FileWaitting_08(dm).Run);
            dm.t.Start();
        }

        public void Run()
        {
            while (true)
            {
                if (documentManager_08.IsDoctumentAvailable)
                {
                    OrderModels doc = documentManager_08.GetDocument();
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
                        MoveFile(doc.Name, waittingFolderName_08, completeFolderName_08);
                    }
                    catch (Exception ex)
                    {
                        MoveFile(doc.Name, waittingFolderName_08, exceptionFolderName_08);
                    }
                }
                else
                {
                    InitQueInfo(documentManager_08, readFolderName_08, waittingFolderName_08);
                }
            }
        }
        static string readFolderName_08 = "D://Distribution//08//";
        static string exceptionFolderName_08 = "D://Distribution//exception//";
        static string completeFolderName_08 = "D://Distribution//08//Actived//";
        static string waittingFolderName_08 = "D://Distribution//08//waitting//";
    }
}
