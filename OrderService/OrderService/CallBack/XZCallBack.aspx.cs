using System;
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
    public partial class XZCallBack : System.Web.UI.Page
    {
        public XZCallBack()
        {
            LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LogMsg.Info(Request.Url);
            if (!IsPostBack)
            {
                LogMsg.Info("XZCallBack start");
                var str = GetJsonStr();
                if (string.IsNullOrEmpty(str)) return;
                var result = new JavaScriptSerializer().Deserialize<XZCommitViewModel>(str);
                LogMsg.Info("FlowKey:" + result.customParm);
                LogMsg.Info("OrderStatus:" + result.trafficSts);
                var url = ConfigurationSettings.AppSettings["SXDDisUrl"] + "?passParm=" + result.customParm + "&serialNo=" + result.requestId + "&result=" + (result.trafficSts.Equals("1") ? "0" : result.trafficSts.Equals("0") ? "0001" : result.trafficSts) + "&msg=" + result.trafficSts;
                LogMsg.Info(url);
                HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                LogMsg.Info("XZCallBack end");
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