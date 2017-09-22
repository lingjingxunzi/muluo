using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.BaseInfo
{
    public class Discounts : ModelBase
    {
        public virtual int DiscountKey { get; set; }
        public virtual decimal Deduction { get; set; }
        public virtual string Status { get; set; }
    }
}
