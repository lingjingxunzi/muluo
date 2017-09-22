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
    /// <summary>
    /// 四川移动
    /// </summary>
    public partial class CMCallBack : System.Web.UI.Page
    {
        public CMCallBack()
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
                var url = ConfigurationSettings.AppSettings["SXDDisUrl"] + "?passParm=" + models.SerialNum + "&serialNo=" + models.SystemNum + "&result=" + (models.Status.Equals("3") ? "0" : models.Status) + "&msg=" + models.Description;
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
        private CM023NewCallBack InitBaseInfo(string str)
        {
            var cm023 = new CM023NewCallBack();
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(str);
            var selectSingleNode = xmlDoc.SelectSingleNode("//Request//Record");
            if (selectSingleNode != null)
            {
                XmlNodeList xn0 = selectSingleNode.ChildNodes;
                foreach (XmlNode node in xn0)
                {
                    if (node.Name == "Description")
                    {
                        cm023.Description = node.InnerText;
                    }
                    if (node.Name == "Mobile")
                    {
                        cm023.Mobile = node.InnerText;
                    }
                    if (node.Name == "SerialNum")
                    {
                        cm023.SerialNum = node.InnerText;
                    }
                    if (node.Name == "SystemNum")
                    {
                        cm023.SystemNum = node.InnerText;
                    }
                    if (node.Name == "Status")
                    {
                        cm023.Status = node.InnerText;
                    }
                }
            }
            return cm023;
        }

        private ILog LogMsg;
    }
}