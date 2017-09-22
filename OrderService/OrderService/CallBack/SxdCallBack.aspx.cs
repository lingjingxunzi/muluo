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
using OrderService.Models.CallBackModels;
using OrderService.Tools;

namespace OrderService.CallBack
{
    public partial class SxdCallBack : System.Web.UI.Page
    {
        public SxdCallBack()
        {
            LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LogMsg.Info(Request.Url);
                var str = GetJsonStr();
                LogMsg.Info(str);
                if (string.IsNullOrEmpty(str)) return;
                var result = new SxdCbResult();
                try
                {
                    var strArr = str.Split('&');
                    result.partnerOrderId = strArr[1].Split('=')[1];
                    result.tradeCode = strArr[3].Split('=')[1];
                    result.tradeId = strArr[6].Split('=')[1];
                }
                catch (Exception ex)
                {
                    LogMsg.Info(ex.Message);
                }
                LogMsg.Info("FlowKey:" + result.partnerOrderId);
                var url = ConfigurationSettings.AppSettings["SXDDisUrl"] + "?passParm=" + result.partnerOrderId +
                          "&serialNo=" + result.tradeId + "&result=" + result.tradeCode + "&msg=";
                LogMsg.Info(url);
                HttpWebRequestTools.GetRequestByHttpWebDefault(url);

                Response.Expires = -1;
                Response.Clear();
                Response.ContentEncoding = Encoding.UTF8;
                Response.ContentType = "application/json";
                Response.Write("ok");
                Response.End();

            }
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