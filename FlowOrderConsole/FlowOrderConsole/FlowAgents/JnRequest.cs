using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowOrderConsole.Models;
using FlowOrderConsole.Tools;
using FlowOrderConsole.Tools.RequestUrl;

namespace FlowOrderConsole.FlowAgents
{
    public class JnRequest : AgentBase
    {
        public JnRequest()
        {
            App = "qxqg1";
            AppSec = "4e95e920682843bfa177ad7701152e3d";
            RequestUrl = "http://121.40.211.78:8083/api.aspx?v=1.1&Action=charge&";
        }

        public override string AgentRequest(AgentParamBase agentParamBase)
        {
            var dis = GetParamData(agentParamBase);
            var signStr = GetSignStr(dis).ToLower();
            var sign = CarrierCharManipulation.GetMd5ForJn(32, signStr).ToLower();
            var url = RequestUrl+"OutTradeNo=" + agentParamBase.HistoriesKey + "&" + signStr + "&sign=" + sign;
            var json = HttpWebRequestTools.GetRequestByHttpWebDefault(url);
            return json;
        }


        private   string GetSignStr(IDictionary<string, string> param)
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

            return sb + "key=" + AppSec;

        }


        private   IDictionary<string, string> GetParamData(AgentParamBase agentParamBase)
        {
            IDictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("mobile", agentParamBase.MobilePhone);
            dic.Add("package", agentParamBase.ProductId);
            dic.Add("account", App);
            return dic;
        }
        
        public override string GetResultStr(string str)
        {
            return str;
        }
    }
}
