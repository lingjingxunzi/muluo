using System;

namespace MONO.Distribution.Model.Sys
{
    public class BusinessIPBind:ModelBase
    {
        public int IPKey { get; set; }
        public int SysUserKey { get; set; }
        public string IP { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
