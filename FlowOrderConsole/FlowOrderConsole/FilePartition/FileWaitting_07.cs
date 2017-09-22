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
    public class FileWaitting_07 : FileBase
    {
        private CM023DocManager documentManager_07;

        public FileWaitting_07(CM023DocManager dm)
        {
            this.documentManager_07 = dm;
        }

        public static void Start(CM023DocManager dm)
        {
            InitQueInfo(dm, readFolderName_07, waittingFolderName_07);
            dm.t = new Thread(new FileWaitting_07(dm).Run);
            dm.t.Start();
        }

        public void Run()
        {
            while (true)
            {
                if (documentManager_07.IsDoctumentAvailable)
                {
                    OrderModels doc = documentManager_07.GetDocument();
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
                        BaseCode.WriteLog(str );
                        if (string.IsNullOrEmpty(str) || str.Contains("error_description"))
                            throw new Exception("连接失败！详情：" + str);
                        str = instance.GetResultStr(str);//解析返回的字符串
                        var url = GetUrl(str, doc.BackUrl, doc.HisKey);
                        BaseCode.WriteLog(url);
                        HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                        MoveFile(doc.Name, waittingFolderName_07, completeFolderName_07);
                    }
                    catch (Exception ex)
                    {
                        MoveFile(doc.Name, waittingFolderName_07, exceptionFolderName_07);
                    }
                }
                else
                {
                    InitQueInfo(documentManager_07,readFolderName_07,waittingFolderName_07);
                }
            }
        }
        static string readFolderName_07 = "D://Distribution//07//";
        static string exceptionFolderName_07 = "D://Distribution//exception//";
        static string completeFolderName_07 = "D://Distribution//07//Actived//";
        static string waittingFolderName_07 = "D://Distribution//07//waitting//";
        
    }
}
