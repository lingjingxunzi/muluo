using System;
using FlowOrderConsole.Models;
using FlowOrderConsole.Tools;
using FlowOrderConsole.Tools.RequestUrl;

namespace FlowOrderConsole.FlowAgents
{
    public class XyxlRequest : AgentBase
    {
        public XyxlRequest()
        {
            App = "TS160816152509824";
            AppSec = "E00B538103AB02FE";
            RequestUrl = "http://119.10.46.47:8999/order";
        }
        public override string AgentRequest(AgentParamBase agentParamBase)
        {
            var dattime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var token = GetToken(agentParamBase, dattime);
            var param = GetOrderParam(agentParamBase, dattime, token);
            var results = HttpWebRequestTools.HttpPostConnectToServer(RequestUrl, param);
            return results;
        }

        private string GetOrderParam(AgentParamBase agentParamBase, string dattime, string token)
        {
            return "appkey=" + App + "&phone=" + agentParamBase.MobilePhone + "&productid=" + agentParamBase.ProductId + "&sign=" + token + "&time=" + dattime + "&tradeno=" + agentParamBase.HistoriesKey;
        }

        private string GetToken(AgentParamBase agentParamBase, string dattime)
        {
            return CarrierCharManipulation.GetMd5(32, App + agentParamBase.MobilePhone + agentParamBase.ProductId + dattime + agentParamBase.HistoriesKey + AppSec);
        }

        public override string GetResultStr(string str)
        {
            return str;
        }
    }
}
