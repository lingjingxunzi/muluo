using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.AlipayViewModel
{
    public class AlipayParamModels
    {
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
        public string OrderName { get; set; }
        public string Describe { get; set; }
    }
}
