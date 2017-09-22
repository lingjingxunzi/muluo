using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.Agent
{
    public class CarrierMaintainDetails : ModelBase
    {
        public string CarrierMaintainDetailKey { get; set; }
        public int CarrierMaintainRecordKey { get; set; }
        public int FlowKey { get; set; }
    }
}
