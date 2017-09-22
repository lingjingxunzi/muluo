using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.FlowAgentViewModels
{
    public class CU0531CommitModels : VatResultBase
    {
        public string code { get; set; }
        public string errorcode { get; set; }
        public IList<CU0531MessageModel> message { get; set; }
        public string sequence { get; set; }
        public int successcount { get; set; }
        public override string GetResult()
        {
            return code.Equals("1") ? "0001" : code;
        }


        public override string GetMsg()
        {
            return errorcode;
        }

        public override string GetOrders()
        {
            return (message != null && message.Count() > 0) ? message[0].orderId : "";
        }
    }
}
