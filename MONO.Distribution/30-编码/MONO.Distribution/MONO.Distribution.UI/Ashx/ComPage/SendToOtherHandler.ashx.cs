using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.Model.Agent;

namespace MONO.Distribution.UI.Ashx.ComPage
{
    /// <summary>
    /// SendToOtherHandler 的摘要说明
    /// </summary>
    public class SendToOtherHandler : IHttpHandler
    {
        public SendToOtherHandler()
        {
            _flowDistributionRecordsService = new FlowDistributionRecordsService();
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json;charset=UTF-8";
            var key = context.Request["Key"];
            var toPhone = context.Request["Phone"];
            var disInfo = _flowDistributionRecordsService.FindById(key);
            if (disInfo != null && disInfo.OrderStatus.Equals("Temp"))
            {
                var newDisInfo = new FlowDistributionRecords();
                disInfo.OrderStatus = "Out";
                disInfo.PushTo = toPhone;
                newDisInfo.DistributionRecordKey = Guid.NewGuid().ToString();
                newDisInfo.CompanyFlowPacketKey = disInfo.CompanyFlowPacketKey;
                newDisInfo.OrderStatus = "WaitActive";
                newDisInfo.SysUserKey = disInfo.SysUserKey;
                newDisInfo.MobilePhone = toPhone;
                newDisInfo.CompanyFlowPacketKey = disInfo.CompanyFlowPacketKey;
                newDisInfo.BatchNo = Guid.NewGuid().ToString().Replace('-', ' ').Trim().Substring(4, 12);
                newDisInfo.DistributionType = "Donation";
                disInfo.PushToKey = newDisInfo.DistributionRecordKey;
                var result = _flowDistributionRecordsService.Update(disInfo);
                if (result.IsOk)
                {
                    result = _flowDistributionRecordsService.Insert(newDisInfo);
                }
            }
            context.Response.Write("0");
        }




        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        private IFlowDistributionRecordsService _flowDistributionRecordsService;
    }
}