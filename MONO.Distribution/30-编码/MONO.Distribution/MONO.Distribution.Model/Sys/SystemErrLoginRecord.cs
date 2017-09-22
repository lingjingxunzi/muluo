using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace MONO.Distribution.Model.Sys
{
    public class SystemErrLoginRecord
    {
        public int SysLoginRecordKey { get; set; }
        public string Account { get; set; }
        public string IP { get; set; }
        public string PWD { get; set; }
        public DateTime LoginDate { get; set; }
    }
}
