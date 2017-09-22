using System.Collections.Generic;

namespace MONO.Distribution.Model.Sys
{
    public class MenuGroups : ModelBase
    {
        public virtual int MenuGroupKey { get; set; }
        public virtual int GroupKey { get; set; }
        public virtual int MenuKey { get; set; }
        public virtual IList<Menus> Menus { get; set; }
    }
}

