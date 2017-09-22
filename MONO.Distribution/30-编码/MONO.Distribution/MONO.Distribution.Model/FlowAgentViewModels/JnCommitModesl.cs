using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MONO.Distribution.Model.FlowAgentViewModels
{
    public class JnCommitModesl : VatResultBase
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string TaskID { get; set; }

        public override string GetOrders()
        {
            return TaskID;
        }


        public override string GetMsg()
        {
            return Message;
        }

        public override string GetResult()
        {
            return string.IsNullOrEmpty(Code) ? "99999" : (Code.Equals("0") ? "0001" : Code);
        }

         
    }
}
