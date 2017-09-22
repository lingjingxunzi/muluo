using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.Model.Agent;

namespace MONO.Distribution.Test
{
    public partial class ChannelMsgTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          IFlowActiveHistoriesService _flowActiveHistoriesService = new FlowActiveHistoriesService();
          var item = new FlowActiveHistories{ FlowActiveHistoryKey = "qxcxf28020170815104502", DistributionRecordKey = "67f2718d-b3a7-4298-8214-d1e28335ff12" };
            _flowActiveHistoriesService.Test(item);
        }
    }
}