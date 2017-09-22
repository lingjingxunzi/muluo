using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.Sys
{
    public class SystemLock
    {
        public Int64 SysLockKey { get; set; }
        public string Account { get; set; }
        public string IP { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
