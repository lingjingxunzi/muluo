using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.Sys
{
    public class PushResultRecords : ModelBase
    {
        public string PushResultRecordTempKey { get; set; }
        public string PushUrl { get; set; }
        public string Result { get; set; }
        public string Msg { get; set; }
        public string OrderKey { get; set; }
        public DateTime CreateTime { get; set; }
        public string BatchNo { get; set; }
    }
}
