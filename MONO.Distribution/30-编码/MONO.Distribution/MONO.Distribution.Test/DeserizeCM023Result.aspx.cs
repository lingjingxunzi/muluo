using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Model.FlowAgentViewModels;
using MONO.Distribution.Model.Sys;

namespace MONO.Distribution.Test
{
    public partial class DeserizeCM023Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           IFlowDistributionRecordsService _flowDistributionRecordsService = new FlowDistributionRecordsService();
            IFlowActiveHistoriesService _flowActiveHistoriesService = new FlowActiveHistoriesService();
            IPushResultRecordService _pushResultRecordService = new PushResultRecordService();
            var dis = _flowDistributionRecordsService.FindById("6dd7d67d-1eda-470f-a2e7-f3357bd57c36");
            if (!string.IsNullOrEmpty(dis.OrderType) && dis.OrderType.Equals("Inter") && !string.IsNullOrEmpty(dis.BackUrl))
            {
                try
                {
                    var pushInfo = new PushResultRecords
                    {
                        Msg = dis.ResultMsg,
                        OrderKey = dis.DistributionRecordKey,
                        PushResultRecordTempKey = Guid.NewGuid().ToString(),
                        PushUrl = dis.BackUrl,
                        Result = dis.OrderStatus,
                        BatchNo = dis.BatchNo

                    };
                    _pushResultRecordService.Insert(pushInfo);
                }
                catch (Exception ex)
                {
                   // LogMsg.Error(ex.Message + "推送数据写入失败！推送单号：" + dis.DistributionRecordKey);
                }
                //var url = dis.BackUrl + "?orderId=" + dis.DistributionRecordKey + "&result=" + dis.OrderStatus + "&msg=" + dis.ResultMsg + "&transNo=" + dis.BatchNo;
                //LogMsg.Info("回调地址：" + url);
                //var json = HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                //LogMsg.Info("回调返回：" + json);
            }
        }
    }
}