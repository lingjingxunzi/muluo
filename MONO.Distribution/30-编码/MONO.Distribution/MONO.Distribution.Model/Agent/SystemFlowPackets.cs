using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.Model.Sys;

namespace MONO.Distribution.Model.Agent
{
    public class SystemFlowPackets : ModelBase
    {
        public int SystemFlowPacketKey { get; set; }
        public int SysUserKey { get; set; }
        public int FlowPacketKey { get; set; }
        public int DiscountKey { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }

        public FlowBaseInfo FlowBaseInfo { get; set; }
        public Discounts Discounts { get; set; }
        public SystemUsers SystemUsers { get; set; }


        public string Froms { get; set; }

        public string Name { get; set; }

        public string FlowName { get; set; }
    }

}
