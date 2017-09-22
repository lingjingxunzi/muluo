using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowOrderConsole.Models
{
    public class OrderModels
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string Code { get; set; }
        public string Mobile { get; set; }
        public string HisKey { get; set; }
        public string BackUrl { get; set; }
        public string Carrier { get; set; }
        public string FaceValue { get; set; }
        public OrderModels(string name, string size, string code, string mobile, string hisKey, string backUrl, string carrier, DateTime createtime, string faceValue = "")
        {
            this.Name = name;
            this.Size = size;
            this.Code = code;
            this.Mobile = mobile;
            this.HisKey = hisKey;
            this.BackUrl = backUrl;
            this.Carrier = carrier;
            this.CreateTime = createtime;
            this.FaceValue = faceValue;
        }


        public DateTime CreateTime { get; set; }

    }
}
