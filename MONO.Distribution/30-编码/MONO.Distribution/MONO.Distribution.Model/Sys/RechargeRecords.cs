using System;

namespace MONO.Distribution.Model.Sys
{
    public class RechargeRecords : ModelBase
    {
        public virtual Guid RechargeKey { get; set; }

        public virtual decimal Amount { get; set; }
        /// <summary>
        /// 商户Key 
        /// </summary>
        public virtual int SysUserKey { get; set; }
        public virtual DateTime PayDate { get; set; }
        public virtual string Status { get; set; }
        public virtual string OperatorId { get; set; }
        public virtual string Seq { get; set; }
        public virtual string Remark { get; set; }
        public virtual int RechargeTo { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public virtual string CostType { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }
        public string IsAlipay { get; set; }

        public string QueryMonth { get; set; }

        public SystemUsers SystemUsers { get; set; }

        public virtual SystemUsers ToSystemUser { get; set; }

        public virtual Enumerations EnumStatus { get; set; }

    }
}

