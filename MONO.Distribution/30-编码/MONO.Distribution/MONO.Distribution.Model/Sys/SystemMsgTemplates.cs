using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.Sys
{
    public class SystemMsgTemplates : ModelBase
    {
        public int MsgTemplateKey { get; set; }
        public int SysUserKey { get; set; }
        public int MessageTemplateKey { get; set; }
        public MessageTemplate MessageTemplate { get; set; }
    }
}
