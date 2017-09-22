using System;
using System.Collections.Generic;
using MONO.Distribution.Model.Agent;

namespace MONO.Distribution.Model.Sys
{
    public class SystemUsers : ModelBase
    {
        public virtual int SysUserKey { get; set; }
        public virtual int GroupKey { get; set; }
        public virtual string Account { get; set; }
        public virtual string PWD { get; set; }
        public virtual string Status { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual Byte[] UpdateTime { get; set; }
        public virtual int Flag { get; set; }
        public virtual string Nick { get; set; }
        public int ParentKey { get; set; }
        public string AgentSec { get; set; }
        public string BackUrl { get; set; }
        public string Remark { get; set; }
        public string VerCode { get; set; }

        public virtual int CurrentUserId { get; set; }

        public virtual SystemUsers ParentSystemUsers { get; set; }
        public virtual string DisAccount { get; set; }


        public virtual SysUserInfos SysUserInfos { get; set; }
        public virtual SysUserGroups SysUserGroups { get; set; }
        public virtual SystemAccount SystemAccount { get; set; }
        public virtual SystemSetting SystemSetting { get; set; }
        public virtual IList<SystemFlowPackets> SystemFlowPacketses { get; set; }
        public virtual IList<SystemMsgTemplates> SysterMsgTemplateses { get; set; }
        //public virtual FB_Enumeration StatusEnum { get; set; }

        public IList<int> SysUserKeyList { get; set; }

        public string QueryDate { get; set; }
        public string QueryName { get; set; }





        public int ActiveCostCount { get; set; }

        public int WaittingCount { get; set; }

        public int FaildCount { get; set; }

        public int SussessCount { get; set; }

        public int TotalCount { get; set; }
    }
}

