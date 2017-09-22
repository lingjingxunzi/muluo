using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.FlowAgentViewModels
{
    public class AggregationCommitViewModel : VatResultBase
    {
        public string Code { get; set; }
        public string Result { get; set; }
        public virtual string GetResult()
        {
            return Code;
        }

        public virtual string GetOrders()
        {
            return "";
        }

        public virtual string GetTransNo()
        {
            return "";
        }

        public virtual string GetMsg()
        {
            return Result;
        }
    }
}
