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
using OrderService.Models.CallBackModels;
using OrderService.Tools;

namespace OrderService.CallBack
{
    public partial class CmAllCallBack : Page
    {
        public CmAllCallBack()
        {
            LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    LogMsg.Info(Request.Url);
                    var str = GetJsonStr();
                    LogMsg.Info(str);
                    var result = new CmWholeCallBackModels();
                    try
                    {
                        result = new JavaScriptSerializer().Deserialize<CmWholeCallBackModels>(str);
                        LogMsg.Info("OrderStatus:" +result.status);
                        if (result.third_no.Contains("D-"))
                        {
                            var url = ConfigurationSettings.AppSettings["SXDDisUrl"] + "?passParm=" + result.third_no + "&serialNo=" + result.order_no+ "&result=" + result.GetResult() + "&msg=" + result.reason;
                            LogMsg.Info(url);
                            HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                        }
                        else
                        {
                            var url = ConfigurationSettings.AppSettings["SXDHomeUrl"] + "?passParm=" + result.third_no + "&serialNo=" + result.order_no + "&result=" + result.GetResult() + "&msg=" + result.reason;
                            LogMsg.Info(url);
                            HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                        }
                        LogMsg.Info("FlowKey:" + result.third_no);
                    }
                    catch (Exception ex)
                    {
                        LogMsg.Info(ex.Message);
                    }
                    Response.Expires = -1;
                    Response.Clear();
                    Response.ContentEncoding = Encoding.UTF8;
                    Response.ContentType = "application/json";
                    Response.Write("{\"msg\":\"接收成功\",\"code\":0}");
                    Response.End();

                }
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