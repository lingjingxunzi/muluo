using System;
using System.Collections.Generic;

namespace MONO.Distribution.Model.Sys
{
    public class SystemLogs : ModelBase
    {
        public virtual Guid SystemLogKey { get; set; }
        public virtual int SysUserKey { get; set; }
        public virtual string IP { get; set; }
        public virtual DateTime InsertTime { get; set; }
        public virtual string Module { get; set; }
        public virtual string Content { get; set; }
        public virtual string Level { get; set; }

        public virtual SystemUsers User { get; set; }

        public virtual string StartTime { get; set; }
        public virtual string EndTime { get; set; }
        public virtual string Account { get; set; }
        public IList<int> SysUserKeyList { get; set; }
    }
}

