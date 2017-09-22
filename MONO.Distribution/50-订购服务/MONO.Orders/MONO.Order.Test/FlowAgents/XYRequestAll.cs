using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Order.Test.Models;
using MONO.Order.Test.Tools;

namespace MONO.Order.Test.FlowAgents
{
    public class XYRequestAll : AgentBase
    {
        public XYRequestAll()
        {
            App = "810810178078";
            AppSec = "9ddc4557210de7b3aec0fc8f39975836";
            RequestUrl = "http://www.xiangyuntiandi.com/api/recharge";
        }
        public override string AgentRequest(AgentParamBase agentParamBase)
        {
            var timestamp = ((long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds) / 1000;
            var signStrs = GetSignStr(agentParamBase, timestamp);
            var signStr = "appid=" + App + "&orderid=" + agentParamBase.HistoriesKey + "&mobile=" +
                          agentParamBase.MobilePhone + "&pid=" + agentParamBase.ProductId + "&timestamp=" + timestamp;
            var sign = CarrierCharManipulation.SHA1(signStrs).ToLower();
            var urlPath = signStr + "&sign=" + sign;
            var json = HttpWebRequestTools.HttpPostConnectToServer(RequestUrl, urlPath);
            return json;
        }


        public string GetRequestUrl(string p, string p_2)
        {
            return RequestUrl;
        }

        private string GetSignStr(AgentParamBase agentParamBase, long time)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            list.Add("appid", App);
            list.Add("timestamp", time + "");
            list.Add("orderid", agentParamBase.HistoriesKey);
            list.Add("mobile", agentParamBase.MobilePhone);
            list.Add("pid", agentParamBase.ProductId);

            var lists = list.OrderBy(x => x.Key);
            var str = new StringBuilder();
            foreach (var item in lists)
            {
                str.Append(item.Key);
                str.Append("=");
                str.Append(item.Value);
                str.Append("&");
            }
            var strAll = str.ToString().TrimEnd('&') + "&key=" + AppSec;
            return strAll;
        }



        public override string GetResultStr(string str)
        {
            return str;
        }
    }
}