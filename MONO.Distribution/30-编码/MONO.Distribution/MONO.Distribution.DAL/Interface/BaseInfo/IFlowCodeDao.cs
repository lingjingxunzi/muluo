using System.Collections.Generic;
using MONO.Distribution.Model.BaseInfo;

namespace MONO.Distribution.DAL.Interface.BaseInfo
{
    public interface IFlowCodeDao : IDao<FlowCode>
    {
        IList<FlowCode> ExecGetFlowActiveLaunchInfo(FlowCode condition);

        IList<FlowCode> SelectFlowCodeByDistinctList(FlowCode condition);

        int SelectFlowCodeByDistinctCount(FlowCode condition);
    }
}
