using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.Model.Sys;

namespace MONO.Distribution.DAL.Interface.Sys
{
    public interface IRechargeRecordsDao : IDao<RechargeRecords>
    {
        RechargeRecords FindById(string RechargeKey);
    }
}
