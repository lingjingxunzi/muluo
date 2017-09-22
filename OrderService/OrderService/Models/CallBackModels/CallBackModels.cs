using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderService.Models.CallBackModels
{
    public class CallBackModels
    {
        public string orderid { get; set; }
        public string tradeno { get; set; }
        public string status { get; set; }
        public string message { get; set; }
    }
}