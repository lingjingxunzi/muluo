using System;

namespace MONO.Distribution.Model.BaseInfo
{
    public class MobileArea : ModelBase
    {
        public int MobileAreaKey { get; set; }
        public string AreaKey { get; set; }
        public string MobileHead { get; set; }
        public string AreaCode { get; set; }
        public Areas MobileAras { get; set; }


        public Int64 flowKey { get; set; }

        public string mobile { get; set; }
    }
}

