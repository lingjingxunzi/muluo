using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.FlowAgentViewModels
{
    public class WholeCMCommit : VatResultBase
    {
        public string msg { get; set; }
        public string code { get; set; }
        public WholeCmCommitItem data { get; set; }

        public override string GetResult()
        {
            return code.Equals("0") ? "0001" : code;
        }

        public override string GetOrders()
        {
            return data == null ? "" : data.order_no;
        }

        public override string GetTransNo()
        {
            return "";
        }

        public override string GetMsg()
        {
            return msg;
        }
    }
}
