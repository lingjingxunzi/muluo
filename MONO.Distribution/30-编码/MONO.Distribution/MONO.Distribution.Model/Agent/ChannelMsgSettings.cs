using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.Agent
{
    public class ChannelMsgSettings:ModelBase
    {
        public int ChannelMsgSettingKey { get; set; }
        public string ChannelName { get; set; }
        public string MsgTemp { get; set; }
        public string Status { get; set; }
    }
}
