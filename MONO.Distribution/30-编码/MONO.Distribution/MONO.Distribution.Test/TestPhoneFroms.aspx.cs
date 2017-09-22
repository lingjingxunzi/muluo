using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Utility;

namespace MONO.Distribution.Test
{
    public partial class TestPhoneFroms : System.Web.UI.Page
    {
        IFlowActiveHistoriesService _flowActiveHistoriesService = new FlowActiveHistoriesService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               //var instance = _flowActiveHistoriesService.Update(new FlowActiveHistories() { Carrier = "CU023", Code = "123456", FlowActiveHistoryKey = "446056bb-250f-48ad-bf3e-0687524dd743", DistributionRecordKey = "db66494f-83f8-41dc-b4ec-faf41d3d45df", FlowStatus = "0", Orders = "2016062201", Results = "成功" });
            }
        }
    }
}