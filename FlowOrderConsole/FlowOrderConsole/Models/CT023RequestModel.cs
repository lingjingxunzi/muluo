using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowOrderConsole.Models
{
    public  class CT023RequestModel
    {
        public CT023RequestModel()
        {
            service_code = "FS0001";
            effect_type = "0";
            order_type = "1";
        }

        
        public string request_no { get; set; }
        public string service_code { get; set; }
        public string contract_id { get; set; }

        public string activity_id { get; set; }
        public string order_type { get; set; }
        public string phone_id { get; set; }
        public string plat_offer_id { get; set; }
        public string effect_type { get; set; }
    }
}
