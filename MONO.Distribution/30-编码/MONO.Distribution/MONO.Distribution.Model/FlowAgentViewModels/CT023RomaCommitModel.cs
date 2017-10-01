using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.FlowAgentViewModels
{
    public class CT023RomaCommitModel : VatResultBase
    {
        public string request_no { get; set; }
        public string result_code { get; set; }
        public string HistoryKey { get; set; }


        public override string GetTransNo()
        {
            return request_no;
        }

        public override string GetResult()
        {
            return result_code.Equals("00000") ? "0001" : result_code;
        }

        public override string GetOrders()
        {
            return request_no;
        }
    }
}
