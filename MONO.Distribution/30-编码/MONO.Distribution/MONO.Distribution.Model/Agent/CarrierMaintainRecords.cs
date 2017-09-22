using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.Agent
{
    public class CarrierMaintainRecords : ModelBase
    {
        public int CarrierMaintainRecordKey { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RecoveryStatus { get; set; }

        public IList<CarrierMaintainDetails> CarrierMaintainDetailses { get; set; }

        public string IsQueryInTime { get; set; }
    }
}
