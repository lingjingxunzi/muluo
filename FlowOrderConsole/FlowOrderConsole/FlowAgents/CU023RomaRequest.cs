using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowOrderConsole.Models;
using FlowOrderConsole.Tools;
using FlowOrderConsole.Tools.RequestUrl;

namespace FlowOrderConsole.FlowAgents
{
    public class CU023RomaRequest : AgentBase
    {
        public CU023RomaRequest()
        {
            App = "96d6ae1392974c9d949e01470184d02d";
            AppSec = "sr666666";
            RequestUrl = "http://61.50.245.139/flowAgent";
        }

        public override string AgentRequest(AgentParamBase agentParamBase)
        {
            agentParamBase.ActionName = "orderPkg";
            agentParamBase.BackUrl = "http://17liu.cn/CallBack/CU023CallBack.aspx";
            agentParamBase.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var dic = GetParamData(agentParamBase);
            var sign = GetSign(dic);
            dic.Add("sign", sign);
            var urlPath = RequestUrl + "?" + GetUrlParams(dic);
            var json = HttpWebRequestTools.GetRequestByHttpWeb(urlPath);
            return json;
        }


        private string GetSign(IDictionary<string, string> param)
        {
            var sb = new StringBuilder();
            var dic = param.OrderBy(m => m.Key);
            foreach (var o in dic.Where(o => !string.IsNullOrEmpty(o.Value)))
            {
                sb.Append(o.Key);
                sb.Append(o.Value);
            }
            var signStr = AppSec + sb + AppSec;
            return CarrierCharManipulation.SHA1(signStr);
        }


        private IDictionary<string, string> GetParamData(AgentParamBase agentParamBase)
        {
            IDictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("action", agentParamBase.ActionName);
            dic.Add("appKey", App);
            dic.Add("phoneNo", agentParamBase.MobilePhone);
            dic.Add("pkgNo", agentParamBase.ProductId);
            dic.Add("transNo", agentParamBase.HistoriesKey);
            dic.Add("timeStamp", agentParamBase.TimeStamp);
            dic.Add("backUrl", StringToBase64(agentParamBase.BackUrl));
            return dic;
        }


        private string GetUrlParams(IDictionary<string, string> param)
        {
            var sb = new StringBuilder();
            var dic = param.OrderBy(m => m.Key);
            foreach (var o in dic.Where(o => !string.IsNullOrEmpty(o.Value)))
            {
                sb.Append(o.Key);
                sb.Append("=");
                sb.Append(o.Value);
                sb.Append("&");
            }
            return sb.ToString().TrimEnd('&');
        }

        public string StringToBase64(string str)
        {
            Encoding encode = Encoding.ASCII;
            byte[] bytedata = encode.GetBytes(str);
            return Convert.ToBase64String(bytedata, 0, bytedata.Length);
        }


        public override string GetResultStr(string str)
        {
            return str;
        }
    }
}
