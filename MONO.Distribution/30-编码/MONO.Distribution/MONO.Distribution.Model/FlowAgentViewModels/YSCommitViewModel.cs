using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.FlowAgentViewModels
{
    public class YSCommitViewModel : VatResultBase
    {
        public string status { get; set; }
        public string msg { get; set; }
        public string srvDateTime { get; set; }
        public string termTransID { get; set; }
        public string transID { get; set; }
        public string sign { get; set; }

        public override string GetMsg()
        {
            return msg;
        }

        public override string GetResult()
        {
            return string.IsNullOrEmpty(status) ? "-1" : (status.Equals("0000") ? "0001" : (status.Equals("0001")?"-0001":status));
        }

        public override string GetOrders()
        {
            return transID;
        }
    }
}
