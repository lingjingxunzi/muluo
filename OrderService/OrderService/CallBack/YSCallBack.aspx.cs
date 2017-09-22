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
using log4net;
using OrderService.Tools;

namespace OrderService.CallBack
{
    public partial class YSCallBack : System.Web.UI.Page
    {
        public YSCallBack()
        {
            LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LogMsg.Info(Request.Url);
                var passParm = Request.QueryString["transID"];
                var result = Request.QueryString["result"];
                var termTransID = Request.QueryString["termTransID"];
                var url = ConfigurationSettings.AppSettings["SXDDisUrl"] + "?passParm=" + passParm + "&serialNo=" + termTransID + "&result=" + result + "&msg=" + result;
                LogMsg.Info(url);
                HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                Response.Expires = -1;
                Response.Clear();
                Response.ContentEncoding = Encoding.UTF8;
                Response.ContentType = "application/json";
                Response.Write("SUCCESS");
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