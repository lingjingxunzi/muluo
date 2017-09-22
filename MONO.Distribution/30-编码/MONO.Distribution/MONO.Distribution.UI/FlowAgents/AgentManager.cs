using System;
using System.Collections.Generic;

namespace MONO.Distribution.UI.FlowAgents
{
    public class AgentManager
    {
        private IDictionary<string, AgentBase> _Dictionary = new Dictionary<string, AgentBase>();

        public AgentManager()
        {
            _Dictionary.Add("orderPkg".ToLower(), new OrderPackge());
            _Dictionary.Add("orderBce".ToLower(), new OrderBalance());
            _Dictionary.Add("orderQuery".ToLower(), new OrderQuery());
            _Dictionary.Add("orderquerytrans".ToLower(), new OrderQueryTrans());

        }

        public AgentBase GetAgentInstance(string key)
        {
            try
            {
                return _Dictionary[key.ToLower()];
            }
            catch (Exception ex)
            {
                throw new Exception("未注册该功能！");
            }
        }
    }
}