using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using MONO.Distribution.Model.BaseInfo;

namespace MONO.Distribution.BLL.Interface.BaseInfo
{
    public interface IFlowBaseInfoService : IService<FlowBaseInfo>
    {
        FlowBaseInfo SelectFlowBaseInfoByFlowCode(string PlatformCode);
        IList<FlowBaseInfo> SelectFlowType(FlowBaseInfo info);
    }
}
