using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Xml;
using log4net;
using OrderService.Models.CallBackModels;
using OrderService.Tools;

namespace OrderService.CallBack
{
    /// <summary>
    /// FujanCMCallBackHandler 的摘要说明
    /// </summary>
    public class FujanCMCallBackHandler : IHttpHandler
    {
        public FujanCMCallBackHandler()
        {
            LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void ProcessRequest(HttpContext context)
        {
            LogMsg.Info(context.Request.Url);
            context.Response.ContentType = "text/plain";
            var data = GetJsonStr(context);
            LogMsg.Info(data);
            var instance = InitBaseInfo(data);
            LogMsg.Info(instance.orderId);
            var url = ConfigurationSettings.AppSettings["SXDDisUrl"] + "?passParm=" + instance.orderId + "&serialNo=&result=" + (instance.result.Equals("0000") ? "0" : instance.result) + "&msg=" + instance.desc;
            LogMsg.Info(url);
            HttpWebRequestTools.GetRequestByHttpWebDefault(url);
            context.Response.Write("<response><result>0000</result><desc></desc></response>");
        }
        private string GetJsonStr(HttpContext context)
        {
            string result = "";
            string jsonStr = "", line;
            try
            {
                LogMsg.Info("GetJsonStr Start");
                var streamResponse = context.Request.InputStream;
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

        private AggregationFjCallBackModel InitBaseInfo(string str)
        {
            var aggr = new AggregationFjCallBackModel();
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(str);
            var selectSingleNode = xmlDoc.SelectSingleNode("//request//body//item");
            if (selectSingleNode != null)
            {
                XmlNodeList xn0 = selectSingleNode.ChildNodes;
                foreach (XmlNode node in xn0)
                {
                    if (node.Name == "desc")
                    {
                        aggr.desc = node.InnerText;
                    }
                    if (node.Name == "gateErrorCode")
                    {
                        aggr.gateErrorCode = node.InnerText;
                    }
                    if (node.Name == "mobile")
                    {
                        aggr.mobile = node.InnerText;
                    }
                    if (node.Name == "orderId")
                    {
                        aggr.orderId = node.InnerText;
                    }
                    if (node.Name == "orderType")
                    {
                        aggr.orderType = node.InnerText;
                    }
                    if (node.Name == "packCode")
                    {
                        aggr.packCode = node.InnerText;
                    }
                    if (node.Name == "result")
                    {
                        aggr.result = node.InnerText;
                    }
                }
            }
            return aggr;
        }



        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private ILog LogMsg;
    }
}