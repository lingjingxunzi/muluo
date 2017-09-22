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
    public partial class CU023CallBack : System.Web.UI.Page
    {
        public CU023CallBack()
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
                var strArr = str.Split('&');
                var url = ConfigurationSettings.AppSettings["SXDDisUrl"] + "?passParm=" + strArr[2].Split('=')[1] + "&serialNo=" + strArr[0].Split('=')[1] + "&result=" + ((strArr[1].Split('=')[1].Equals("0000")) ? "0" : strArr[1].Split('=')[1]) + "&msg=" + strArr[1].Split('=')[1];
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


        private ILog LogMsg;
    }
}