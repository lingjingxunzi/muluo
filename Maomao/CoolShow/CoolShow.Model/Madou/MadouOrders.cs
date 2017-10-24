using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CoolShow.Model.Madou
{
    public class MadouOrders : ModelBase
    {
        public int MadouOrderKey { get; set; }
        public string OrderDate { get; set; }
        public string OrderAmout { get; set; }
        public string StoreName { get; set; }
        public string OrderNumber { get; set; }
        public string OrderStatus { get; set; }
    }
}
