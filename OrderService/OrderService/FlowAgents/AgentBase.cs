using OrderService.Models;

namespace OrderService.FlowAgents
{
    public abstract class AgentBase
    {
        public abstract string AgentRequest(AgentParamBase agentParamBase);

        public string RequestUrl { get; set; }
        public string App { get; set; }
        public string AppSec { get; set; }
    }
}
