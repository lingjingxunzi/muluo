using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using MONO.Distribution.Model.Sys;

namespace MONO.Distribution.Model.Agent
{
    public class FlowDistributionRecords : ModelBase
    {
        public string DistributionRecordKey { get; set; }
        public int SysUserKey { get; set; }
        public int CompanyFlowPacketKey { get; set; }
        public string MobilePhone { get; set; }
        public string OrderStatus { get; set; }
        public string OrderNo { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Code { get; set; }
        public string Carrier { get; set; }
        public string ResultMsg { get; set; }
        public string BatchNo { get; set; }
        public string CallBackUrl { get; set; }
        public string PushTo { get; set; }
        public string PushToKey { get; set; }
        public string DistributionType { get; set; }
        public string OrderType { get; set; }
        public string BackUrl { get; set; }

        public IList<int> SystemUserList { get; set; }

        public SystemFlowPackets SystemFlowPackets { get; set; }
        public SystemUsers SystemUsers { get; set; }
        public Enumerations EnumStatus { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public SystemAccountLog SystemAccountLog { get; set; }

        public string QueryStartTime { get; set; }
        public string QueryEndTime { get; set; }

    }
}
