using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.FlowAgentViewModels
{
    public class XZCommitViewModel : VatResultBase
    {
        public string statusCode { get; set; }
        public string statusMsg { get; set; }
        public string requestId { get; set; }

        public override string GetTransNo()
        {
            return requestId;
        }

        public override string GetResult()
        {
            return statusCode.Equals("0") ? "0001" : statusCode;
        }

        public override string GetOrders()
        {
            return requestId;
        }
    }
}
