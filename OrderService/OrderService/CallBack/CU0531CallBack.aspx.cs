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
    public partial class CU0531CallBack : System.Web.UI.Page
    {
        public CU0531CallBack()
        {
            LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var resultStr = "success";
                LogMsg.Info(Request.Url);
                var str = GetJsonStr();
                LogMsg.Info(str);
                if (string.IsNullOrEmpty(str))
                {
                    resultStr = "未获取参数信息";
                    return;
                }
                var infoArr = str.Split('&');
                IDictionary<string, string> _dic = new Dictionary<string, string>();
                try
                {

                    foreach (var item in infoArr)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Contains("="))
                        {
                            LogMsg.Info(item.Split('=')[0] + "," + item.Split('=')[1]);
                            _dic.Add(item.Split('=')[0], item.Split('=')[1]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogMsg.Error(ex.Message);    
                }
                try
                {
                    var param = "?serialNo=" + _dic["orderId"] + "&result=" + (_dic["resCode"].Equals("1") ? "0" : "1") + "&msg=" + _dic["errCode"];
                    var url = "http://113.207.124.143/Order/CU0531CallBack.aspx" + param;
                    LogMsg.Info(url);
                    HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                }
                catch (Exception ex)
                {
                    Response.Expires = -1;
                    Response.Clear();
                    Response.ContentEncoding = Encoding.UTF8;
                    Response.ContentType = "application/json";
                    Response.Write("err");
                    Response.End();
                }
                Response.Expires = -1;
                Response.Clear();
                Response.ContentEncoding = Encoding.UTF8;
                Response.ContentType = "application/json";
                Response.Write(resultStr);
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