using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.ViewModel
{
    public class FlowAssignedViewModel
    {

        public virtual bool IsExists { get; set; }
        public string SettingPrice { get; set; }
        public string DiscountValue { get; set; }
        public int SystemFlowPacketKey { get; set; }
        public string FlowName { get; set; }
        public decimal StandardPrice { get; set; }
        public int FlowKey { get; set; }
        public string RangeName { get; set; }
        public decimal MyDis { get; set; }
    }
}
