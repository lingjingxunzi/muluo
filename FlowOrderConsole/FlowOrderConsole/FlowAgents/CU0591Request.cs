using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using FlowOrderConsole.Models;
using FlowOrderConsole.Tools;
using FlowOrderConsole.Tools.RequestUrl;

namespace FlowOrderConsole.FlowAgents
{
    public class CU0591Request : AgentBase
    {
        public CU0591Request()
        {
            ResType = "114";
            logName = "dongyitong";
            psd = "dyt9856";
            App = "PECwrHLgsUbpTf9Qlov531FJdDpGzFOD";
            AppSec = "jaqEGGyNrx7oNH7wdU6BXW7jfzhy1iJNtSAhEsyDrXPhl4MJh8Y3yLqSvaabCIgp";
            RequestUrl = "https://220.249.191.215:7002/route/route/rest2?";
            method = "com.fjunicom.WX10080";
            session = "wyT2Vl5fkZC1sDZpZJt4g7bmSuEbzig176GOoNJ8d9gJITxCeniWaVXD9VV7yEdS";
        }


        public override string AgentRequest(AgentParamBase agentParamBase)
        {
            var msg = GetMsg(agentParamBase);
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var sign = Md5Encoding(GetSecretStr(AppSec, App, session, method, msg, timestamp)).ToLower();
            var url = GenUrl(AppSec, App, session, method, msg, timestamp, sign);
            var json = HttpWebRequestTools.GetRequestByHttpWebDefault(url);
            return GetResultStr(json);
        }
        public string GenUrl(string secret, string appkey, string session, string method, string msg, string timestamp, string sign)
        {
            msg = msg.Replace("<", "%3C").Replace("/", "%2F").Replace(">", "%3E");
            timestamp = timestamp.Replace(" ", "+").Replace(":", "%3a");

            string url = RequestUrl + "app_key=" + appkey
                         + "&method=" + method
                         + "&msg=" + msg
                         + "&session=" + session
                         + "&sign=" + sign
                         + "&sign_method=MD5"
                         + "&timestamp=" + timestamp
                         + "&v=2.0";
            return url;
        }

        public string GetSecretStr(string secret, string appkey, string session, string method, string msg,
            string timestamp)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(secret)
                .Append("app_key").Append(appkey)
                .Append("&method").Append(method)
                .Append("&msg").Append(msg)
                .Append("&session").Append(session)
                .Append("&sign_methodMD5&timestamp").Append(timestamp)
                .Append("&v2.0")
                .Append(secret);
            return sb.ToString();
        }



        public string GetMsg(AgentParamBase agentParamBase)
        {
            string msg = "<Request>" +
                "<LoginName>" + logName + "</LoginName>" +
                "<Password>" + psd + "</Password>" +
                "<ResType>" + ResType + "</ResType>" +
                "<SvcNum>" + agentParamBase.PakgeSize + "</SvcNum>" +
                "<FlowNum>" + agentParamBase.MobilePhone + "</FlowNum>" +
                "</Request>";
            return msg;
        }

        public string Md5Encoding(string txt)
        {
            byte[] result = Encoding.GetEncoding("GBK").GetBytes(txt);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");
        }
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

        private string method;
        private string session;
        private string logName;
        private string psd;
        private string ResType;

    }
}
