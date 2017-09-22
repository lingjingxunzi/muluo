using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using FlowOrderConsole.Models;
using FlowOrderConsole.Tools.RequestUrl;

namespace FlowOrderConsole.FlowAgents
{
    public class TestAgent : AgentBase
    {
        public override string AgentRequest(AgentParamBase agentParamBase)
        {
            var url = "http://localhost:9270/Index.aspx?carrier" + agentParamBase.Carrier + "&mobile=" + agentParamBase.MobilePhone + "&hisKey=" + agentParamBase.HistoriesKey;
            var json = HttpWebRequestTools.GetRequestByHttpWebDefault(url);
            return json;
        }

        public override string GetResultStr(string str)
        {
            return "";
        }
    }
}
