using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderService.Models.CallBackModels
{
    public class CmWholeCallBackModels
    {
        public string status { get; set; }
        public string report_time { get; set; }
        public string third_no { get; set; }
        public string order_no { get; set; }
        public string mobile { get; set; }
        public string reason { get; set; }

        internal string GetResult()
        {
            return status.ToLower().Equals("y") ? "0" : status;
        }
    }
}