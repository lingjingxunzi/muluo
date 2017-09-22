using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.BaseInfo;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.BLL.Interface.BaseInfo;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.Utility;

namespace MONO.Distribution.UI.Ashx.ComPage
{
    /// <summary>
    /// ActiveAgainHandler 的摘要说明
    /// </summary>
    public class ActiveAgainHandler : IHttpHandler
    {
        public ActiveAgainHandler()
        {
            _flowCodeService = new FlowCodeService();
            _flowDistributionRecordsService = new FlowDistributionRecordsService();
        }
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json;charset=UTF-8";
            var key = context.Request["Key"];
            var disInfo = _flowDistributionRecordsService.FindById(key);
            if (disInfo != null && disInfo.OrderStatus.Equals("Temp"))
            {
                disInfo.OrderStatus = "Again";
                var list = _flowCodeService.FindAll(new FlowCode { FlowKey = disInfo.SystemFlowPackets.FlowPacketKey });
                if (list.Any())
                {
                    var hisInfo = new FlowActiveHistories
                    {
                        Carrier = list.First().Carrier,
                        Code = list.First().ProductCode,
                        DistributionRecordKey = disInfo.DistributionRecordKey,
                        FlowActiveHistoryKey ="D-"+ GetGuidStrHandler.GenerateStringID()
                    };
                    _flowActiveHistoriesService.Insert(hisInfo);
                    _flowDistributionRecordsService.Update(disInfo);
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
        private IFlowActiveHistoriesService _flowActiveHistoriesService;
        private IFlowCodeService _flowCodeService;
    }
}