using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.UIProcess;

namespace MONO.Distribution.UI.Sys
{
    public partial class BusinessDiscountList : ListPageBase
    {
        public BusinessDiscountList()
        {
            _systemFlowPacketsService = new SystemFlowPacketsService();
            _systemUsersService = new SystemUsersService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUser();
                BindData();
            }
        }

        private void BindUser()
        {
            var user = _systemUsersService.FindAll(new SystemUsers());
            foreach (var item in user)
            {
                ddlSysuserKey.Items.Add(new ListItem() {  Value= item.SysUserKey.ToString(),Text =item.Nick });
            }
            ddlSysuserKey.Items.Insert(0,new ListItem("请选择","0"));
        }

        private void BindData()
        {
            var conditon = GetQueryCondtion();
            SetPager(conditon);
            IList<SystemFlowPackets> userList = _systemFlowPacketsService.SelectSystemFlowPacketForBusinessList(conditon);
            gvUserList.DataSource = userList;
            gvUserList.DataBind();
        }


        private void SetPager(SystemFlowPackets user)
        {
            SetPager(_systemFlowPacketsService.SelectSystemFlowPacketForBusinessCount(user), 10);
        }

        private SystemFlowPackets GetQueryCondtion()
        {
            return new SystemFlowPackets
            {
                IsStartPager = true,
                StartRecordIndex = PageHelper.GetStartIndex(),
                EndRecordIndex = PageHelper.GetEndIndex() < PageHelper.GetPageTotal()
                        ? PageHelper.GetPageTotal()
                        : PageHelper.GetEndIndex(),
                FlowName = txtName.Text.Trim(),
                SysUserKey = int.Parse(this.ddlSysuserKey.SelectedValue)
            };
        }

        protected void btnPage_Click(object sender, EventArgs e)
        {
            PageHelper.SetPageIndex(int.Parse(hidePage.Value));
            BindData();
        }



        protected void gvUserList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private ISystemFlowPacketsService _systemFlowPacketsService;
        private ISystemUsersService _systemUsersService;
    }
}