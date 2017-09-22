using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderService.Models.CallBackModels
{
    public class AggregationFjCallBackModel
    {
        public string orderId { get; set; }
        public string orderType { get; set; }
        public string packCode { get; set; }
        public string mobile { get; set; }
        public string result { get; set; }
        public string desc { get; set; }
        public string gateErrorCode { get; set; }
    }
}