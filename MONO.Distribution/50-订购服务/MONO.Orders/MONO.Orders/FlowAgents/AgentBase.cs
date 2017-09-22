using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Orders.Models;

namespace MONO.Orders.FlowAgents
{
    public abstract class AgentBase
    {
        public abstract string AgentRequest(AgentParamBase agentParamBase);

        public string RequestUrl { get; set; }
        public string App { get; set; }
        public string AppSec { get; set; }
    }
}
