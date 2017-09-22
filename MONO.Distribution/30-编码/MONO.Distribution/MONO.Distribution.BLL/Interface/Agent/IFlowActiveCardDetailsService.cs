using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.Model.Agent;

namespace MONO.Distribution.BLL.Interface.Agent
{
    public interface IFlowActiveCardDetailsService : IService<FlowActiveCardDetails>
    {
        FlowActiveCardDetails FindById(string p);
    }
}
