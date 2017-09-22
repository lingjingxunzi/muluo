﻿using System;
using FlowOrderConsole.Models;
using FlowOrderConsole.Tools;
using FlowOrderConsole.Tools.RequestUrl;

namespace FlowOrderConsole.FlowAgents
{
    public class WholeCmRequest : AgentBase
    {
        public WholeCmRequest()
        {
            App = "qxcxzs";
            AppSec = "dsf^*51jkFDS#klH";
            agent_id = "110";
            RequestUrl = "http://dev.seecom.com.cn/buy_flow";
        }
        public override string AgentRequest(AgentParamBase agentParamBase)
        {
            InitParamInfo(agentParamBase);
            var result = HttpWebRequestTools.HttpPostConnectToServer(RequestUrl, GetJsonStr());
            return result;
        }

        private void InitParamInfo(AgentParamBase agentParamBase)
        {
            models = new WholeCmParam();
            models.agent_id = agent_id;
            models.user = App;
            models.mobile = agentParamBase.MobilePhone;
            models.flow_id = agentParamBase.ProductId;
            models.third_no = agentParamBase.HistoriesKey;
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            models.nonce = Convert.ToInt64(ts.TotalSeconds).ToString();
            models.used = "resale";
            models.mode = "2";
            var key = AppSec;
            var sinStr = "agent_id=" + models.agent_id + "&nonce=" + models.nonce + "&user=" + models.user + "&key=" + key;
            models.sign = CarrierCharManipulation.GetStrByMd5(sinStr).ToLower();

        }

        private string GetJsonStr()
        {
            return "{\"agent_id\":\"" + models.agent_id + "\",\"flow_id\":\"" + models.flow_id + "\",\"mobile\":\"" + models.mobile
                + "\",\"mode\":\"" + models.mode + "\",\"nonce\":\"" + models.nonce + "\",\"sign\":\"" + models.sign + "\",\"third_no\":\"" + models.third_no + "\",\"used\":\"" +
                models.used + "\",\"user\":\"" + models.user + "\"}";
        }

        public WholeCmParam models { get; set; }
        public string agent_id { get; set; }

        public override string GetResultStr(string str)
        {
            return str;
        }

       
    }
}