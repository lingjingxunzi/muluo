using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.FlowAgentViewModels
{
    public class YtkCommitReuslt : VatResultBase
    {
        public string code { get; set; }
        public string message { get; set; }
        public string respCode { get; set; }
        public string orderId { get; set; }

        public override string GetMsg()
        {
            return message;
        }

        public override string GetResult()
        {
            return string.IsNullOrEmpty(respCode) ? "-1" : (respCode.Equals("0000") ? "0001" : respCode);
        }

        public override string GetOrders()
        {
            return orderId;
        }

    }


}
