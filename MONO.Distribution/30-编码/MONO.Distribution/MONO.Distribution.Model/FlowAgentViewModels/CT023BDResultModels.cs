using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.FlowAgentViewModels
{
    public class CT023BDResultModels : VatResultBase
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string ExchangeId { get; set; }
        public string OrderId { get; set; }


        public override string GetTransNo()
        {
            return ExchangeId;
        }

        public override string GetResult()
        {
            return string.IsNullOrEmpty(Code) ? "-1" : (Code.Equals("0000") ? "0" : Code);
        }

        public override string GetMsg()
        {
            return Message;
        }

        public override string GetOrders()
        {
            return ExchangeId;
        }
    }
}
