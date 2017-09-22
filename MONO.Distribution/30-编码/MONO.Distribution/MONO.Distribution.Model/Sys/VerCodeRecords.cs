using System;

namespace MONO.Distribution.Model.Sys
{
    public class VerCodeRecords : ModelBase
    {
        public string VerCodeKey { get; set; }
        public DateTime CreateTime { get; set; }
        public string IP { get; set; }
    }
}
