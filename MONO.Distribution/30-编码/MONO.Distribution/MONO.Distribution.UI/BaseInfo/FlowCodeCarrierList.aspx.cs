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
    public partial class FlowCodeCarrierList : ListPageBase
    {
        public FlowCodeCarrierList()
        {
            _flowCodeService =new FlowCodeService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }



        protected void btnQuery_Click(object sender, EventArgs e)
        {

        }

        protected void gvFlowPacketList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnPage_Click(object sender, EventArgs e)
        {

        }

        private void BindData()
        {
            var condition = GetQueryCondition();
            SetPager(_flowCodeService.SelectFlowCodeByDistinctCount(condition),10);
            var data = _flowCodeService.SelectFlowCodeByDistinctList(condition);
            this.gvFlowPacketList.DataSource = data;
            this.gvFlowPacketList.DataBind();
        }

        private FlowCode GetQueryCondition()
        {
            return new FlowCode();
        }

        private IFlowCodeService _flowCodeService;

    }
}