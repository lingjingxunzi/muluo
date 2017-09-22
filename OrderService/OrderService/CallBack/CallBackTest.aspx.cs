using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using OrderService.Models.CallBackModels;
using OrderService.Tools;

namespace OrderService.CallBack
{
    public partial class CallBackTest : Page
    {
        public CallBackTest()
        {
            LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LogMsg.Info(Request.Url);
                var str = GetJsonStr();
                LogMsg.Info("json：" + str);
                if (String.IsNullOrEmpty(str)) return;
                var models = new JavaScriptSerializer().Deserialize<CallBackModels>(GetJsonStr());
                if (models.tradeno.Contains("D-"))
                {
                    var url = "http://113.207.124.164/Order/SxdCallBack.aspx?serialNo=" + models.orderid + "&passParm=" + models.tradeno + "&result=" + models.status + "&msg="+models.message;
                    var result = HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                    LogMsg.Info(result);
                }
                else
                {
                    var url = "http://www.5liuba.net/ActiveInterface/SxdCallBack.aspx?serialNo=" + models.orderid + "&passParm=" + models.tradeno + "&result=" + models.status + "&msg=" + models.message;
                    var result = HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                    LogMsg.Info(result);
                }
            }
        }
        private string GetJsonStr()
        {
            string result = "";
            string jsonStr = "", line;
            try
            {
                var streamResponse = Request.InputStream;
                var streamRead = new StreamReader(streamResponse, Encoding.UTF8);
                while ((line = streamRead.ReadLine()) != null)
                {
                    jsonStr += line;
                }
                streamResponse.Close();
                streamRead.Close();
                result = jsonStr;
            }
            catch (Exception ex)
            {
                result = "msg-数据发布（In）异常：" + ex.Message;
            }
            return result;
        }
        private ILog LogMsg;
    }
}