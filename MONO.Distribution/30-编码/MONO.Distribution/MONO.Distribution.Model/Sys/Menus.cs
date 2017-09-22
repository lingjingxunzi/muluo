using System.Collections.Generic;

namespace MONO.Distribution.Model.Sys
{
    public class Menus : ModelBase
    {
        public virtual int MenuKey { get; set; }
        public virtual int ParentMenuKey { get; set; }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public virtual string Path { get; set; }
        public virtual string Target { get; set; }
        public virtual string Status { get; set; }
        public virtual int Order { get; set; }
        public virtual string Flag { get; set; }


        public virtual IList<Menus> ChildrenMenus { get; set; }
    }
}

