using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderService.Models.CallBackModels
{
    public class CM023NewCallBack
    {
        public string SerialNum { get; set; }
        public string SystemNum { get; set; }
        public string Mobile { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}