using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using System.Reflection;
using System.IO;
using System.Text;
using System.Configuration;
using OrderService.Tools;
using System.Web.Script.Serialization;
using OrderService.Models.CallBackModels;

namespace OrderService.CallBack
{
    public partial class CT023CallBack : System.Web.UI.Page
    {
        public CT023CallBack()
        {
            LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LogMsg.Info(Request.Url);
                var str = GetJsonStr();
                var CT023BackModel = new JavaScriptSerializer().Deserialize<CT023BackModel>(str);

                var param = "?serialNo=" + CT023BackModel.request_no + "&result=" + (CT023BackModel.result_code.Equals("00000") ? "0" : CT023BackModel.result_code) + "&msg=" + CT023BackModel.msg_id;
                var url = "http://113.207.124.143/Order/CU0531CallBack.aspx" + param;
                LogMsg.Info(url);
                HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                Response.Expires = -1;
                Response.Clear();
                Response.ContentEncoding = Encoding.UTF8;
                Response.ContentType = "application/json";
                Response.Write("1");
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