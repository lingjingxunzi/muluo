using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.Model.Sys;

namespace MONO.Distribution.Model.Agent
{
    public class FlowActiveCard : ModelBase
    {
        public string TransNo { get; set; }
        public int Numbers { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime OverdueTime { get; set; }
        public string Status { get; set; }
        public int SysUserKey { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int SystemFlowPacketKey { get; set; }


        public Enumerations EnumStatus { get; set; }
        public SystemFlowPackets SystemFlowPackets { get; set; }
         
    }
}
