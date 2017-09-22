using System.Collections.Generic;
using MONO.Distribution.Model.BaseInfo;

namespace MONO.Distribution.BLL.Interface.BaseInfo
{
    public interface IFlowCodeService : IService<FlowCode>
    {
        IList<FlowCode> ExecGetFlowActiveLaunchInfo(FlowCode condition);
        IList<FlowCode> SelectFlowCodeByDistinctList(FlowCode condition);
        int SelectFlowCodeByDistinctCount(FlowCode condition);
    }
}
