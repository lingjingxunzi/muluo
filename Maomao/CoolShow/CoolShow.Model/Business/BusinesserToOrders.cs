using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoolShow.Model.Business
{
    public class BusinesserToOrders : ModelBase
    {
        public string BusinesserToOrderKey { get; set; }
        public string OrderDate { get; set; }
        public int OrderNum { get; set; }
        public string OrderType { get; set; }
        public string Remark { get; set; }
        public string MaUrl { get; set; }
        public string TaoPwd { get; set; }
        public string ShortUrl { get; set; }
        public string IsCompare { get; set; }
        public string IsCollection { get; set; }
        public string IsCart { get; set; }
        public string ImageRemark { get; set; }
        public string FirstImage { get; set; }
        public string Keyword { get; set; }
        public string ImagePlace { get; set; }
        public string MadouRemark { get; set; }
        public string BackAddr { get; set; }
    }
}
