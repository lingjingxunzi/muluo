using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Orders.Models
{
    public class AgentParamBase
    {
        public string ProductId { get; set; }
        public string Carrier { get; set; }
        public string MobilePhone { get; set; }
        public int PakgeSize { get; set; }

        public string HistoriesKey { get; set; }
        public string TimeStamp { get; set; }
        public string ActionName { get; set; }
    }
}
