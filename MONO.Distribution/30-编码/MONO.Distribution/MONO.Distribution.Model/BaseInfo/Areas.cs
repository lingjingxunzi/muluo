using System;

namespace MONO.Distribution.Model.BaseInfo
{
    public class Areas : ModelBase
    {
        public string AreaKey { get; set; }
        public string Name { get; set; }
        public string ParentKey { get; set; }

        public Areas ParentArea { get; set; }
    }
}
