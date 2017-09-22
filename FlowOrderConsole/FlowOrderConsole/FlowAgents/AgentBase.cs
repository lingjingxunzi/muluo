﻿using FlowOrderConsole.Models;

namespace FlowOrderConsole.FlowAgents
{
    public abstract class AgentBase
    {
        public abstract string AgentRequest(AgentParamBase agentParamBase);
        public abstract string GetResultStr(string str);
        public string RequestUrl { get; set; }
        public string App { get; set; }
        public string AppSec { get; set; }
    }
}