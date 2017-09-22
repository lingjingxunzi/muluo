using System;
using System.Collections.Generic;
using System.Security;

namespace MONO.Distribution.Model.Sys
{
    public class SysUserGroups : ModelBase
    {
        public virtual int GroupKey { get; set; }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public virtual string Status { get; set; }
        public virtual Byte[] UpdateTime { get; set; }
        public virtual int SysUserKey { get; set; }
        public virtual int Flag { get; set; }
        public virtual int Levels { get; set; }

        public virtual IList<MenuGroups> MenuGroups { get; set; }

        public virtual string IsJurisdiction { get; set; }

    }
}

