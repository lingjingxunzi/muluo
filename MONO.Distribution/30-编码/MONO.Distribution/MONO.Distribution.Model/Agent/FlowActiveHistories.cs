using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.Agent
{
    public class FlowActiveHistories : ModelBase
    {
        public string FlowActiveHistoryKey { get; set; }
        public string DistributionRecordKey { get; set; }
        public string Carrier { get; set; }
        public string Code { get; set; }
        public string Orders { get; set; }
        public string Results { get; set; }
        public string FlowStatus { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
