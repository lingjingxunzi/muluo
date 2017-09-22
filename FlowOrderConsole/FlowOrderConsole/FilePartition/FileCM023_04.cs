﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using FlowOrderConsole.FlowAgents;
using FlowOrderConsole.Models;
using FlowOrderConsole.Tools.RequestUrl;

namespace FlowOrderConsole.FilePartition
{
    public class FileCM023_04 : FileBase
    {
        private CM023DocManager documentManager_cm023_03;

        public FileCM023_04(CM023DocManager dm)
        {
            this.documentManager_cm023_03 = dm;
        }

        public static void Start(CM023DocManager dm)
        {
            InitQueInfo(dm, readFolderName_cm023_04, waittingFolderName_cm023_04);
            dm.t = new Thread(new FileCM023_04(dm).Run);
            dm.t.Start();
        }

        public void Run()
        {
            while (true)
            {
                if (documentManager_cm023_03.IsDoctumentAvailable)
                {
                    OrderModels doc = documentManager_cm023_03.GetDocument();
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
                        BaseCode.WriteLog(url);
                        HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                        MoveFile(doc.Name, waittingFolderName_cm023_04, completeFolderName_cm023_04);
                    }
                    catch (Exception ex)
                    {
                        BaseCode.WriteLog(ex.Message + "订单号：" + doc.HisKey);
                        MoveFile(doc.Name, waittingFolderName_cm023_04, exceptionFolderName_cm023_04);
                    }
                }
                else
                {
                    InitQueInfo(documentManager_cm023_03, readFolderName_cm023_04, waittingFolderName_cm023_04);
                }
            }
        }

        static string readFolderName_cm023_04 = "D://Distribution//CM023_04//";
        static string exceptionFolderName_cm023_04 = "D://Distribution//CM023_04//";
        static string completeFolderName_cm023_04 = "D://Distribution//CM023_04//Actived//";
        static string waittingFolderName_cm023_04 = "D://Distribution//CM023_04//waitting//";
    }
}