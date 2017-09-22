using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace MONO.Distribution.Model.Sys
{
    public class MessageTemplate : ModelBase
    {
        public int MessageTemplateKey { get; set; }
        public string Content { get; set; }
        public int Price { get; set; }
        public string MsgType { get; set; }
        public string IndentifyCode { get; set; }
    }
}
