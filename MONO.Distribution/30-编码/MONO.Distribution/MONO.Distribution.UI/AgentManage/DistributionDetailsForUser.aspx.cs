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

namespace MONO.Distribution.UI.AgentManage
{
    public partial class DistributionDetailsForUser : ListPageBase
    {
        public DistributionDetailsForUser()
        {
            _flowDistributionRecordsService = new FlowDistributionRecordsService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtStartQueryDateTime.Text = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd");
                this.txtEndQueryDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
            var condtion = GetQueryCondition();
            SetPager(_flowDistributionRecordsService.GetCount(condtion),10);
            var list = _flowDistributionRecordsService.SelectDistributionRecordListForQueryBySysUserKey(condtion);
            this.gvDisList.DataSource = list;
            this.gvDisList.DataBind();
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
                SysUserKey = int.Parse(Request.QueryString["UserKey"]),
                StartTime = txtStartQueryDateTime.Text,
                EndTime =  txtEndQueryDateTime.Text
            };
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }


        private IFlowDistributionRecordsService _flowDistributionRecordsService;


        
    }
}