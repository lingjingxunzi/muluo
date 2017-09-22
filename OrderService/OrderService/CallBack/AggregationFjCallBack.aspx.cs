using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using log4net;
using OrderService.Models.CallBackModels;
using OrderService.Tools;

namespace OrderService.CallBack
{
    public partial class AggregationFjCallBack : System.Web.UI.Page
    {
        public AggregationFjCallBack()
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
                var models = InitBaseInfo(str);
                var url = ConfigurationSettings.AppSettings["SXDDisUrl"] + "?passParm=" + models.orderId + "&serialNo=&result=" + (models.result.Equals("0000") ? "0" : models.result) + "&msg=" + models.desc;
                LogMsg.Info(url);
                HttpWebRequestTools.GetRequestByHttpWebDefault(url);
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

        private ILog LogMsg;
    }
}