using System.Collections.Generic;
using MONO.Distribution.Model.BaseInfo;

namespace MONO.Distribution.DAL.Interface.BaseInfo
{
    public interface IFlowBaseInfoDao : IDao<FlowBaseInfo>
    {
        FlowBaseInfo SelectFlowBaseInfoByFlowCode(string PlatformCode);

       IList<FlowBaseInfo> SelectFlowType(FlowBaseInfo info);
    }
}
