using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using MONO.Distribution.Model.Sys;

namespace MONO.Distribution.Model.Customers
{
    public class CompanyAccountAddApplys : ModelBase
    {
        public int AccountAddApplyKey { get; set; }
        public int CompanyKey { get; set; }
        public int SysUserKey { get; set; }
        public int AccountIntegrel { get; set; }
        public DateTime CreateTime { get; set; }
        public string Remark { get; set; }
        public string ApplyStatus { get; set; }

        public IList<AccountApplyAtts> AccountApplyAttses { get; set; }
        public SystemUsers ApplyUser { get; set; }
        public SystemUsers BeApplyUser { get; set; }
        public Enumerations EnumStatus { get; set; }
    }
}
