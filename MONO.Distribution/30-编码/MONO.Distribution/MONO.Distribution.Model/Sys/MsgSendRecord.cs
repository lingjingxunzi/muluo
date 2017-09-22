using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.Sys
{
    public class MsgSendRecord
    {
        public string MsgSendRecordkey { get; set; }
        public int SysUserKey { get; set; }
        public string Content { get; set; }
        public string UserPhone { get; set; }
        public DateTime CreateTime { get; set; }
        public string Status { get; set; }
    }
}
