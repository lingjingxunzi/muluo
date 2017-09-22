using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.FlowAgentViewModels
{
    public class CM023NewResultViewModel : VatResultBase
    {
        public string Result { get; set; }
        public string Code { get; set; }
        public string SerialNum { get; set; }
        public string SystemNum { get; set; }


        public override string GetMsg()
        {
            return Result;
        }

        public override string GetOrders()
        {
            return SystemNum;
        }

        public override string GetTransNo()
        {
            return SerialNum;
        }

        public override string GetResult()
        {
            return Code;
        }
    }
}
