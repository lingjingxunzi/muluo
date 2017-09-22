using System.Collections.Generic;
using MONO.Distribution.Model.BaseInfo;

namespace MONO.Distribution.BLL.Interface.BaseInfo
{
    public interface IMobileAreaService : IService<MobileArea>
    {
        MobileArea SelectMobileAreaByHead(string MobileHead);
        IList<string> ExecGetFlowCodeByMobile(MobileArea conditon);
        string ExecGetMobileFrom(string mobile);
       
    }
}

