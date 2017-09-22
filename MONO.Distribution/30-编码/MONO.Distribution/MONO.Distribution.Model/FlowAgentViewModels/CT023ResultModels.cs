using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.FlowAgentViewModels
{
    public class CT023ResultModels : VatResultBase
    {
        public string rescode { get; set; }
        public string resmsg { get; set; }
        public string transId { get; set; }
        public string FlowDisKey { get; set; }

        public override string GetTransNo()
        {
            return FlowDisKey;
        }

        public override string GetResult()
        {
            return rescode.Equals("9006") ? "0001" : rescode;
        }

        public override string GetOrders()
        {
            return transId;
        }
    }
}
