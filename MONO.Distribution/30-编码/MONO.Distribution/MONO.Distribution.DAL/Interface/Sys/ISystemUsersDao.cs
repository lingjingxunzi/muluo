﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.Model.Sys;

namespace MONO.Distribution.DAL.Interface.Sys
{
    public interface ISystemUsersDao : IDao<SystemUsers>
    {
        SystemUsers SelectByAccount(string userAccount);

        IList<int> SelectSystemChildrensKey(SystemUsers systemUsers);

        IList<SystemUsers> SelectSystemChildrensKeyForAllInfo(SystemUsers systemUsers);

        IList<SystemUsers> SelectSystemUserListForReport(SystemUsers condition);

        int SelectSystemUserCountForReport(SystemUsers condition);

        void UpdateSystemUserCode(SystemUsers condition);

        IList<SystemUsers> SelectSystemUserListForMonthReport(SystemUsers condition);

        IList<decimal> SelectSystemUserListForMonthList(SystemUsers condition);

        IList<string> SelectDateForEveryDate(SystemUsers condition);
    }
}
