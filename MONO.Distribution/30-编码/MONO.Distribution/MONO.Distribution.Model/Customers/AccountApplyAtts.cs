using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.Customers
{
    public class AccountApplyAtts : ModelBase
    {
        public int AccountApplyAttKey { get; set; }
        public int AccountAddApplyKey { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
    }
}
