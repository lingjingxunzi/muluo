using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.BaseInfoViewModel
{
    public class CarrieroperatorViewModel
    {

        public string Name
        {
            get
            {
                switch (Key)
                {
                    case "CM":
                        return "移动";
                    case "CT":
                        return "电信";
                    case "CU":
                        return "联通";
                    default:
                        return "未知";
                }
                 
            } 
            set{}
        }

        public string Key { get; set; }
        
        
    }
}
