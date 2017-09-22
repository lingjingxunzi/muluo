using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace MONO.Distribution.Model.FlowAgentViewModels
{
    public class XYCommitResultModels : VatResultBase
    {
        public string err_code { get; set; }
        public string err_msg { get; set; }
        public XYCommitDataModels data { get; set; }

        public override string GetResult()
        {
            return err_code.Equals("0000") ? "0001" : err_code;
        }


        public override string GetMsg()
        {
            return err_msg;
        }
    }
}
