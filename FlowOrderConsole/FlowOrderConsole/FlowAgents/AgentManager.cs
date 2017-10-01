using System;
using System.Collections.Generic;
using FlowOrderConsole.MappingModels;

namespace FlowOrderConsole.FlowAgents
{
    public class AgentManager
    {
        public AgentManager()
        {

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
                        {"CM025",new CM025Request()},
                        {"CMWhole",new WholeCmRequest()},
                        {"CT023_A",new CT023DiffRequest()} ,
                        {"CT023_A_O",new CT023_PRequest()},
                        {"CM023New",new CM023NewRequest()},
                        {"CM023",new CM023Request()},
                        {"XZ",new XZWholeCMRequest()},
                        {"FJJH",new AggregationRequest()},//福建聚合,
                        {"CU023YTK",new CU023RomaRequest()},
                        {"YS",new YSRequest()},
                        {"JN",new JnRequest()},
                        {"CM028",new CM028Request()}
                    };
                }
                return agentDictionary[key];
            }
            catch (Exception ex)
            {
                return agentDictionary["SXD"];
            }
        }

        private static IDictionary<string, AgentBase> agentDictionary = null;
    }
}
