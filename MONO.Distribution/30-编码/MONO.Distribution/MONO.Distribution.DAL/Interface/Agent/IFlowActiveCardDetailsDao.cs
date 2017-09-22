using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.Model.Agent;

namespace MONO.Distribution.DAL.Interface.Agent
{
    public interface IFlowActiveCardDetailsDao : IDao<FlowActiveCardDetails>
    {
        FlowActiveCardDetails FindById(string p);
    }
}
