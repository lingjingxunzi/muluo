using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderService.Models.CallBackModels
{
    public class CM025BackModels
    {
        public int TaskID { get; set; }
        public string Mobile { get; set; }
        public int Status { get; set; }
        public string ReportTime { get; set; }
        public string ReportCode { get; set; }
        public string OutTradeNo { get; set; }
        public string Sign { get; set; }


        public string GetResult()
        {
            return Status == 4 ? "0" : "1";
        }
    }
}