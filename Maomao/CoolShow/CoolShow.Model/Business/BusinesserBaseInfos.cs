using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoolShow.Model.Business
{
    public class BusinesserBaseInfos : ModelBase
    {
        public int BusinesserBaseInfoKey { get; set; }
        public string WeChart { get; set; }
        public string MobilePhone { get; set; }
        public string IdentifyNum { get; set; }
        public string StoreUrl { get; set; }
        public DateTime JoinDate { get; set; }
        public string QQNumber { get; set; }
        /// <summary>
        /// 账户状态 0、1、2
        /// </summary>
        public int Status { get; set; }
    }
}
