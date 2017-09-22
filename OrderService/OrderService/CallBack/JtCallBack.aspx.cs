﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using MONO.FB.Models.ViewModel;
using OrderService.Tools;

namespace OrderService.CallBack
{
    public partial class JtCallBack : Page
    {
        public JtCallBack()
        {
            LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LogMsg.Info(Request.Url);
            if (!IsPostBack)
            {
                LogMsg.Info("JTCallBack start");
                var result = new JavaScriptSerializer().Deserialize<JTCallBackModel>(GetJsonStr());
                LogMsg.Info("FlowKey:" + result.FlowKey);
                LogMsg.Info("OrderStatus:" + result.OrderStatus);
                if (result.FlowKey.Contains("D-"))
                {
                    var url = ConfigurationSettings.AppSettings["JTDisUrl"] + "?FlowKey=" + result.FlowKey + "&OrderKey=" + result.OrderKey + "&OrderStatus=" + result.OrderStatus + "&FailReason=" + result.FailReason;
                    LogMsg.Info(url);
                    HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                }
                else
                {
                    var url = ConfigurationSettings.AppSettings["JTHomeUrl"] + "?FlowKey=" + result.FlowKey + "&OrderKey=" + result.OrderKey + "&OrderStatus=" + result.OrderStatus + "&FailReason=" + result.FailReason;
                    LogMsg.Info(url);
                    HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                }
                LogMsg.Info("JTCallBack end");
            }

            Response.Expires = -1;
            Response.Clear();
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "application/json";
            Response.Write("OK");
            Response.End();
        }




        private string GetJsonStr()
        {
            string result = "";
            string jsonStr = "", line;
            try
            {
                LogMsg.Info("GetJsonStr Start");
                var streamResponse = Request.InputStream;
                var streamRead = new StreamReader(streamResponse, Encoding.UTF8);

                while ((line = streamRead.ReadLine()) != null)
                {
                    LogMsg.Info(line);
                    jsonStr += line;
                }
                streamResponse.Close();
                streamRead.Close();
                LogMsg.Info(jsonStr);
                result = jsonStr;
            }
            catch (Exception ex)
            {
                result = "msg-数据发布（In）异常：" + ex.Message;
                LogMsg.Info(result);
            }
            return result;
        }


        private ILog LogMsg;





    }
}