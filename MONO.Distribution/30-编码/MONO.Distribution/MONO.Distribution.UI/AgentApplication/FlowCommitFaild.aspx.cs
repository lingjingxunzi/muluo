using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.UIProcess;

namespace MONO.Distribution.UI.AgentApplication
{
    public partial class FlowCommitFaild : ListPageBase
    {
        public FlowCommitFaild()
        {
            _distributionRecordsService = new FlowDistributionRecordsService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblBatch.InnerText = Request.QueryString["transNo"];
                BindData();
            }
        }

        protected void btnPage_Click(object sender, EventArgs e)
        {
            PageHelper.SetPageIndex(int.Parse(hidePage.Value));
            BindData();
        }

        private void BindData()
        {
            var condition = GetQueryCondition();
            SetPager(_distributionRecordsService.GetCount(condition), 10);
            var list = _distributionRecordsService.FindAll(condition);
            this.gvList.DataSource = list;
            this.gvList.DataBind();
        }

        private FlowDistributionRecords GetQueryCondition()
        {
            return new FlowDistributionRecords
            {
                IsStartPager = true,
                StartRecordIndex = PageHelper.GetStartIndex(),
                EndRecordIndex = PageHelper.GetEndIndex() < PageHelper.GetPageTotal()
                        ? PageHelper.GetPageTotal()
                        : PageHelper.GetEndIndex(),
                BatchNo = Request.QueryString["transNo"]
            };
        }
        private IFlowDistributionRecordsService _distributionRecordsService;
    }
}