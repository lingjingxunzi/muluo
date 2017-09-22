using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.BaseInfo;
using MONO.Distribution.BLL.Interface.BaseInfo;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.UIProcess;

namespace MONO.Distribution.UI.BaseInfo
{
    public partial class FlowCodeReviewList : ListPageBase
    {
        public FlowCodeReviewList()
        {
            _flowCodeService = new FlowCodeService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            SetPager(_flowCodeService.GetCount(condition), 10);
            var list = _flowCodeService.FindAll(condition);
            this.gvFlowPacketList.DataSource = list;
            this.gvFlowPacketList.DataBind();
        }

        private FlowCode GetQueryCondition()
        {
            return new FlowCode { FlowKey = string.IsNullOrEmpty(Request.QueryString["FlowKey"]) ? 0 : int.Parse(Request.QueryString["FlowKey"]), AreaStr = null, FromRanges =""};
        }


        private IFlowCodeService _flowCodeService;
    }
}