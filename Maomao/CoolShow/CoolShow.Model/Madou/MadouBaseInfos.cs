using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoolShow.Model.Madou
{
    public class MadouBaseInfos : ModelBase
    {
        public int MadouBaseInfoKey { get; set; }
        public string Nick { get; set; }
        public string AgeRange { get; set; }
        public string Occupation { get; set; }
        public string ImageStyle { get; set; }
        public string JoinDate { get; set; }
        public string ExpectedSalary { get; set; }
        public string Remark { get; set; }
        public string Wechart { get; set; }
    }
}
