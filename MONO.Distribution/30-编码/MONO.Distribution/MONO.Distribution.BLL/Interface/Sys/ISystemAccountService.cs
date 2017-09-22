using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.Interface.Sys
{
    public interface ISystemAccountService : IService<SystemAccount>
    {
        ResultMessage SystemAccountChange(int systemKey, string transNo, decimal charges, string chargeType);
        SystemAccount SelectSystemAccountByUserKey(int SysUserKey);
        ResultMessage ExecUpdateCompanyAccount(SystemAccount condition);
        void UpdateSystemAccountForBond(SystemAccount condition);
        void UpdateSystemAccountForDraft(SystemAccount condition);
    }
}
