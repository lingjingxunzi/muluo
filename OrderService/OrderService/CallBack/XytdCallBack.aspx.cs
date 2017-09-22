using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web.Script.Serialization;
using log4net;
using OrderService.Models.CallBackModels;
using OrderService.Tools;

namespace OrderService.CallBack
{
    public partial class XytdCallBack : System.Web.UI.Page
    {
        public XytdCallBack()
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

                var result = new JavaScriptSerializer().Deserialize<XYCallBackModels>(GetJsonStr());

                LogMsg.Info("FlowKey:" + result.o_id);
                LogMsg.Info("OrderStatus:" + result.status);
                if (result.o_id.Contains("D-"))
                {
                    var url = ConfigurationSettings.AppSettings["XYDisUrl"] + "?FlowKey=" + result.o_id + "&OrderKey=" + result.xy_order + "&OrderStatus=" + result.status + "&FailReason=" + result.msg;
                    LogMsg.Info(url);
                    HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                }
                else
                {
                    var url = ConfigurationSettings.AppSettings["XYHomeUrl"] + "?FlowKey=" + result.o_id + "&OrderKey=" + result.xy_order + "&OrderStatus=" + result.status + "&FailReason=" + result.msg;
                    LogMsg.Info(url);
                    HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                }
                Response.Expires = -1;
                Response.Clear();
                Response.ContentEncoding = Encoding.UTF8;
                Response.ContentType = "application/json";
                Response.Write("0000");
                Response.End();
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