using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.FB.Models.ViewModel
{
    public class JTCallBackModel
    {
        public string FlowKey { get; set; }

        public string OrderKey { get; set; }

        public string Phone { get; set; }

        public string OrderStatus { get; set; }

        public string FailReason { get; set; }

        public string VerifyCode { get; set; }
    }
}
