using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.Model.Sys;

namespace MONO.Distribution.Model.Agent
{
    public class FlowActiveCardDetails : ModelBase
    {
        public string CardID { get; set; }
        public string TransNo { get; set; }
        public string Serect { get; set; }
        public string Status { get; set; }
        public string MobilePhone { get; set; }
        public int FlowPakegeKey { get; set; }
        public DateTime RechargeTime { get; set; }

        public FlowActiveCard FlowActiveCard { get; set; }

        public FlowBaseInfo FlowPaBaseInfo { get; set; }

        public Enumerations EnumStatus { get; set; }
    }
}
