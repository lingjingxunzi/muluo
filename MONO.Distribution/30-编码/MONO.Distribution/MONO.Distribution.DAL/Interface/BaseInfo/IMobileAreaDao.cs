using System.Collections.Generic;
using MONO.Distribution.Model.BaseInfo;

namespace MONO.Distribution.DAL.Interface.BaseInfo
{
    public interface IMobileAreaDao : IDao<MobileArea>
    {

        MobileArea SelectMobileAreaByHead(string MobileHead);

        IList<string> ExecGetFlowCodeByMobile(MobileArea conditon);



        string ExecGetMobileFrom(string mobile);
    }
}

