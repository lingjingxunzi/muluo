using System;
using System.Collections;
using System.Collections.Generic;
using MONO.Distribution.Model.Sys;

namespace MONO.Distribution.Model.BaseInfo
{
    public class FlowCode : ModelBase
    {
        public int FlowCodeKey { get; set; }
        public int FlowKey { get; set; }
        public string From { get; set; }
        public string Carrier { get; set; }
        public string ProductCode { get; set; }
        public string Area { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; }
        public int DiscountKey { get; set; }
        public decimal PurchasePrice { get; set; }
        public string FromRanges { get; set; }
        public string Name { get; set; }

        public Discounts Discounts { get; set; }
        public Enumerations EnumCarrier { get; set; }
        public Enumerations EnumFrom { get; set; }
        public Enumerations EnumFromRanges { get; set; }
        public Areas AreaName { get; set; }
        public FlowBaseInfo FlowBaseInfo { get; set; }

        public IList<string> AreaStr { get; set; }

        public string FlowCodeName
        {
            get { return (EnumCarrier == null ? "" : EnumCarrier.EnumValue) + "." + (EnumFrom == null ? "" : EnumFrom.EnumValue) + "." + (AreaName == null ? "" : AreaName.Name); }
            set { }
        }


        public string UserPhone { get; set; }
        public string ActiveRecordKey { get; set; }

        public IList<int> FlowKeyListForQuery { get; set; }
    }
}
