using System;
using FlowOrderConsole.Models;
using FlowOrderConsole.Tools;
using FlowOrderConsole.Tools.RequestUrl;

namespace FlowOrderConsole.FlowAgents
{
    public class CU0531Request : AgentBase
    {
        public CU0531Request()
        {
            App = "100038525";
            AppSec = "2993822400392426";
            RequestUrl = "http://api.qwllqb.com/access/service/api/recharge/rechargeByShopId";
        }

        public override string AgentRequest(AgentParamBase agentParamBase)
        {
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var param = CarrierCharManipulation.Encrypt_Cu0531(GetSignStr(agentParamBase), AppSec);
            var json = HttpWebRequestTools.CU051HttpPost(RequestUrl, param, App, timestamp);
            return json;
        }

        private string GetSignStr(AgentParamBase agentParamBase)
        {
            return "{\"custId\":" + App + ",\"shopProductId\":" + agentParamBase.ProductId + ",\"telPhone\":" + agentParamBase.MobilePhone + ",\"requestNo\":\"" + agentParamBase.HistoriesKey + "\"}";
        }

        public override string GetResultStr(string str)
        {
            return str;
        }
    }
}
