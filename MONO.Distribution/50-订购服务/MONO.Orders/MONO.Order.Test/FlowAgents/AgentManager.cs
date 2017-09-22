using System;
using System.Collections.Generic;

namespace MONO.Order.Test.FlowAgents
{
    public class AgentManager
    {
        public AgentManager()
        {
            agentDictionary.Add("CU023", new Cu023Request());
            agentDictionary.Add("JT", new JtRequest());
            agentDictionary.Add("SXD", new SxdRequest());
            agentDictionary.Add("YTK", new YtkRequest());
            agentDictionary.Add("XYP", new XYRequestPro());
            agentDictionary.Add("XYA", new XYRequestAll());
            agentDictionary.Add("XYXL", new XyxlRequest());
            agentDictionary.Add("CU0531",new CU0531Request());
            agentDictionary.Add("CM025",new CM025Request());
            agentDictionary.Add("CMWhole", new WholeCmRequest());
            agentDictionary.Add("CM023",new CM023Request());
            agentDictionary.Add("CU0591",new CU0591Request());
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
                        {"XYA",new XYRequestAll()},
                        {"XYP",new XYRequestPro()},
                        {"XYXL", new XyxlRequest()},
                        {"CU0531",new CU0531Request()},
                        {"CM025",new CM025Request()},
                        {"CMWhole",new WholeCmRequest()},
                        {"CM023",new CM023Request()},
                        {"CU0591",new CU0591Request()}
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
