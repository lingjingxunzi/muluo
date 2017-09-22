using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.Interface.Agent
{
    public interface IFlowActiveCardService : IService<FlowActiveCard>
    {
        FlowActiveCard FindById(string id);

        ResultMessage FlowCardBatchCreate(FlowActiveCard info);
    }
}
