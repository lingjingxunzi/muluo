using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using MONO.Order.Test.Models;
using MONO.Order.Test.Tools;

namespace MONO.Order.Test.FlowAgents
{
    public class SxdRequest : AgentBase
    {
        public SxdRequest()
        {
            App = "100150";
            AppSec = "pJvCEo0CcEHJ1FLgQ_kZbg";
            RequestUrl = "http://webapi.liulianginn.com/webapi-scheme-200/api4partner/trade/partnerCash2MobileFlow";
        }
        public override string AgentRequest(AgentParamBase agentParamBase)
        {
            GetUrlParamStr(agentParamBase);
            var signStr = GetMd5Str();
            var sig = CarrierCharManipulation.GetStrByMd5(signStr).ToLower();
            var urlPath = RequestUrl + "?partnerId=" + App + "&productId=" + agentParamBase.ProductId + "&phone=" +
                          agentParamBase.MobilePhone + "&amount=" + agentParamBase.PakgeSize + "&event=&partnerOrderId=" +
                          agentParamBase.HistoriesKey + "&unixTime=" + param["unixTime"] + "&nonce=" + param["nonce"] + "&sign=" + sig;
            var result = HttpWebRequestTools.GetRequestByHttpWebDefault(urlPath);
            return result;
        }
        
        private void GetUrlParamStr(AgentParamBase agentParamBase)
        {
            param.Add("partnerId", App);
            param.Add("productId", agentParamBase.ProductId);
            param.Add("phone", agentParamBase.MobilePhone);
            param.Add("amount", agentParamBase.PakgeSize.ToString());
            param.Add("event", "");
            param.Add("partnerOrderId", agentParamBase.HistoriesKey);
            param.Add("unixTime", CarrierCharManipulation.GetTimeStamp());
            param.Add("nonce", Guid.NewGuid().ToString());
        }

        private string GetMd5Str()
        {
            var order = param.OrderBy(m => m.Key);
            var str = AppSec;
            foreach (var item in order)
            {
                str += "|" + item.Value;
            }
            return str;
        }
        private IDictionary<string, string> param = new Dictionary<string, string>();

        public override string GetResultStr(string str)
        {
            return str;
        }
    }
}
