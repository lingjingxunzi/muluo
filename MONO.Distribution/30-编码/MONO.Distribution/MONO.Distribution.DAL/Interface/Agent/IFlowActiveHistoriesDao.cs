using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.Model.Agent;

namespace MONO.Distribution.DAL.Interface.Agent
{
    public interface IFlowActiveHistoriesDao : IDao<FlowActiveHistories>
    {
        FlowActiveHistories FindById(string transKey);

        FlowActiveHistories SelectFlowActiveHistoriesByOrderId(string orders);
    }
}
