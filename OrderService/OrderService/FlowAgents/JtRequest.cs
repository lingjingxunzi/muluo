using System;
using System.Linq;
using OrderService.Models;
using OrderService.Tools;

namespace OrderService.FlowAgents
{
    public class JtRequest : AgentBase
    {
        public JtRequest()
        {
            App = "0204";
            AppSec = "ZgwqWgwPyODC";
            RequestUrl = "http://apll.bm724.com/SkyHandler.ashx";
        }
        public override string AgentRequest(AgentParamBase agentParamBase)
        {
            var token = GetToken();
            var param = GetOrderParam(agentParamBase);
            var requestUrl = GetRequestUrl("", "");
            var sign = CarrierCharManipulation.GetStrByMd5(param);
            var results = HttpWebRequestTools.JTHttpPost(requestUrl, param, sign, token);
            return results;
        }

        public string GetToken()
        {
            var r = string.Format("{{\"Action\":\"{0}\",\"Version\":\"{1}\",\"MerChant\":\"{2}\" ,\"ClientID\":\"{3}\",\"VerifyCode\":\"{4}\"}}", "GetNewToken", "V1.0", "9dcd865f-dc0e-4719-b03b-41f800e5d0d3", App, GetVerifyCode());
            var sign = CarrierCharManipulation.GetStrByMd5(r);
            var s = HttpWebRequestTools.JTHttpPost(RequestUrl, r, sign);
            return s;
        }

        private string GetVerifyCode()
        {
            var verCode = string.Format("{0}+{1}-{2}+{3}", MerChant, App, AppSec, DateTime.Now.Day);
            var sum = verCode.Sum(t => (int)t) % 4 + 4;
            for (var i = 0; i < sum; i++)
            {
                verCode = CarrierCharManipulation.GetStrByMd5(verCode);
            }
            return verCode;
        }

        public string GetRequestUrl(string p, string p_2)
        {
            return RequestUrl;
        }

        public string GetOrderParam(AgentParamBase agentParamBase)
        {
            var rr = string.Format("{{\"Action\":\"{0}\",\"Version\":\"{1}\",\"MerChant\":\"{2}\",\"Product\":\"{3}\",\"Mobile\":\"{4}\",\"PayPwd\":\"{5}\",\"FlowKey\":\"{6}\"}}", "SendOrder", "V1.0", MerChant, agentParamBase.ProductId, agentParamBase.MobilePhone, "", agentParamBase.HistoriesKey);
            return rr;
        }

        public string MerChant = "9dcd865f-dc0e-4719-b03b-41f800e5d0d3";

    }
}
