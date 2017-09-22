using System.Collections;
using System.Collections.Generic;
using MONO.Distribution.Model.BaseInfo;

namespace MONO.Distribution.Model.Sys
{
    public class Enumerations : ModelBase
    {
        public virtual string EnumKey { get; set; }
        public virtual string EnumParent { get; set; }
        public virtual string EnumValue { get; set; }
        public virtual string Status { get; set; }
        public virtual string Remark { get; set; }

        public virtual Enumerations ParentEnums { get; set; }
        public string ParentName
        {
            get
            {
                if (EnumParent.Equals("0"))
                {
                    return "";
                }
                else
                {
                    return ParentEnums == null ? "" : ParentEnums.EnumValue;
                }
            }
            set { }
        }


        public IList<FlowCode> Carriers { get; set; }
    }
}

