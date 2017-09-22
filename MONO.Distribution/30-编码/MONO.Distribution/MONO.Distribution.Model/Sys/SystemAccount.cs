using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Model.Sys
{
    public class SystemAccount : ModelBase
    {
        public int CompanyAccountKey { get; set; }
        public int SysUserKey { get; set; }
        public decimal TotalAccount { get; set; }
        public decimal LeftAccount { get; set; }
        /// <summary>
        /// 保证金
        /// </summary>
        public decimal Bond { get; set; }
        /// <summary>
        /// 允许透支额度（积分）
        /// </summary>
        public decimal OverDraft { get; set; }
        public SystemUsers SystemUsers { get; set; }
    }
}
