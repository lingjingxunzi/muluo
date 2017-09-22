using System;
using System.Collections.Generic;

namespace OrderService.FlowAgents
{
    public class AgentManager
    {
        public AgentManager()
        {
            agentDictionary.Add("CU023", new Cu023Request());
            agentDictionary.Add("JT", new JtRequest());
            agentDictionary.Add("SXD", new SxdRequest());
            agentDictionary.Add("YTK", new YtkRequest());
            agentDictionary.Add("XYA",new XYRequestAll());
            agentDictionary.Add("XYP",new XYRequestPro());
        }
        public static AgentBase GetAgentInstance(string key)
        {
            try
            {
                if (agentDictionary == null)
                {

                    agentDictionary = new Dictionary<string, AgentBase>
                    {
                        {"CU023", new Cu023Request()},
                        {"JT", new JtRequest()},
                        {"SXD", new SxdRequest()},
                        {"YTK", new YtkRequest()},
                        {"XYP",new XYRequestPro()},
                        {"XYA",new XYRequestAll()}
                    };
                }
                return agentDictionary[key];
            }
            catch (Exception ex)
            {
                return agentDictionary["JT"];
            }
        }

        private static IDictionary<string, AgentBase> agentDictionary = null;
    }
}
