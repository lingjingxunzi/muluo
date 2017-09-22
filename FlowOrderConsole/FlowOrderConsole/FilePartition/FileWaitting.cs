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
    public class FileWaitting : FileBase
    {
        private CM023DocManager documentManager_waitting;

        public FileWaitting(CM023DocManager dm)
        {
            this.documentManager_waitting = dm;
        }

        public static void Start(CM023DocManager dm)
        {
            InitQueInfo(dm, readFolderName_all, waittingFolderName_all);
            dm.t = new Thread(new FileWaitting(dm).Run);
            dm.t.Start();
        }

        public void Run()
        {
            while (true)
            {
                if (documentManager_waitting.IsDoctumentAvailable)
                {
                    OrderModels doc = documentManager_waitting.GetDocument();
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
                            PakgeSize = int.Parse(doc.Size),
                            FaceValue = doc.FaceValue
                        };
                        var str = instance.AgentRequest(param);//订购
                        BaseCode.WriteLog(str );
                        //if (string.IsNullOrEmpty(str) || str.Contains("error_description"))
                        //    throw new Exception("连接失败！详情：" + str);
                        str = instance.GetResultStr(str);//解析返回的字符串
                        if (str.Contains("连接Boss失败"))
                            throw new Exception("连接失败！详情：" + str);
                        var url = GetUrl(str, doc.BackUrl, doc.HisKey);
                        BaseCode.WriteLog(url );
                        HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                        MoveFile(doc.Name, waittingFolderName_all, completeFolderName_all);
                    }
                    catch (Exception ex)
                    {
                        BaseCode.WriteLog(ex.Message + "订单号：" + doc.HisKey );
                        MoveFile(doc.Name, waittingFolderName_all, exceptionFolderName_all);
                    }
                }
                else
                {
                    InitQueInfo(documentManager_waitting, readFolderName_all, waittingFolderName_all);
                }
            }
        }


        static string readFolderName_all = "D://Distribution//Waitting//";
        static string exceptionFolderName_all = "D://Distribution//exception//";
        static string completeFolderName_all = "D://Distribution//Actived//";
        static string waittingFolderName_all = "D://Distribution//Waitting//waitting//";
        static string logFlag = "all";
    }
}
