using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Orders.Models;
using MONO.Orders.Tools;

namespace MONO.Orders.FlowAgents
{
    public class YtkRequest : AgentBase
    {
        public YtkRequest()
        {
            App = "9d1cc32e18054817bcb19f00cc75807a";
            AppSec = "68996109";
            RequestUrl = "http://113.57.230.9:91/flowAgent";
        }
        public override string AgentRequest(AgentParamBase agentParamBase)
        {
            var dic = GetParamData(agentParamBase);
            var sign = GetSign(dic);
            dic.Add("appSecret", AppSec);
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
            var signStr = App + sb + AppSec;
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



    }
}
