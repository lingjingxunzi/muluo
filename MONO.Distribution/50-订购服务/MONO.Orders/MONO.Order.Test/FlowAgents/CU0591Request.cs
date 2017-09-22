using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Order.Test.Models;
using MONO.Order.Test.Tools;

namespace MONO.Order.Test.FlowAgents
{
    public class CU0591Request : AgentBase
    {
        public CU0591Request()
        {
            App = "123456";
            AppSec = "123456";
            RequestUrl = "https://220.249.191.215:17002/route/route/rest2?";
            method = "com.fjunicom.WX10080";
            session = "";
        }
        public override string AgentRequest(AgentParamBase agentParamBase)
        {

            var time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var msg = GetMsgStr(agentParamBase);
            var sigStr = GetSignStr(time, msg);
            var sign = CarrierCharManipulation.GetMd5(32, sigStr);
            var url = RequestUrl + "app_key=" + App + "&method=" + method + "&msg=" + msg + "&session=" + session + "&sign=" + sign + "&sign_method=MD5&timestamp=" + time + "&v=2.0";
            var result = HttpWebRequestTools.GetRequestByHttpWebDefault(url);
            return result;
        }

        private string GetMsgStr(AgentParamBase agentParamBase)
        {
            return "<Request><LoginName>" + App + "</LoginName>" +
                       "<Password>" + AppSec + "</Password>" +
                       "<ResType>" + agentParamBase.ProductId + "</ResType><SvcNum>" + agentParamBase.MobilePhone + "</SvcNum>" +
                       "<FlowNum>" + agentParamBase.PakgeSize + "</FlowNum></Request>";
        }

        private string GetSignStr(string time, string msg)
        {
            var str = new StringBuilder();
            str.Append(AppSec).Append("app_key").Append(App)
                .Append("&method").Append(method).Append("&msg")
                .Append(msg).Append("&session").Append(session)
                .Append("&sign_methodMD5&timestamp").Append(time)
                .Append("&v2.0").Append(AppSec);
            return str.ToString();
        }


        private string method;
        private string session;

        public override string GetResultStr(string str)
        {
            try
            {
                var cu0591result = new CU0591ResultModel();
                cu0591result.InitInstance(str);
                return "{\"RspCode\":\"" + cu0591result.RspCode + "\",\"RspInfo\":\"" + cu0591result.RspInfo + "\"}";
            }
            catch (Exception ex)
            {
                return "{\"RspCode\":\"\",\"RspInfo\":\"\"}";
            }
        }
    }
}
