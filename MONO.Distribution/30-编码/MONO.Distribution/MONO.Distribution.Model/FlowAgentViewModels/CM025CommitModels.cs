using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.FlowAgentViewModels
{
    public class CM025CommitModels : VatResultBase
    {
        public string Code { get; set; }
        public string Message { get; set; }

        public override string GetResult()
        {
            return Code.Equals("0")?"0001":Code;
        }

        public override string GetOrders()
        {
            return "";
        }

        public override string GetTransNo()
        {
            return "";
        }

        public override string GetMsg()
        {
            return "";
        }


        
    }
}
