using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.UIProcess;

namespace MONO.Distribution.UI.AgentManage
{
    public partial class AgentUserAccountList : ListPageBase
    {
        public AgentUserAccountList()
        {
            _systemUsersService = new SystemUsersService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDdlUsers();
                BindData();
            }
        }

        private void BindDdlUsers()
        {
            var userList = _systemUsersService.SelectSystemChildrensKeyForAllInfo(new SystemUsers { SysUserKey = CurrentUser.SysUserKey });
            this.ddlUsers.DataSource = userList;
            this.ddlUsers.DataTextField = "Account";
            this.ddlUsers.DataValueField = "SysUserKey";
            this.ddlUsers.DataBind();
            this.ddlUsers.Items.Insert(0, new ListItem("请选择", "0"));
        }
        
        
        protected void btnPage_Click(object sender, EventArgs e)
        {

            PageHelper.SetPageIndex(int.Parse(hidePage.Value));
            BindData();
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
            WriteLog("账户管理", "账户查询", "");
        }

        protected void gvUserList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }


        private void BindData()
        {
            var condition = GetQueryCondition();
            SetPager(_systemUsersService.GetCount(condition), 10);
            var userList = _systemUsersService.FindAll(condition);
            this.gvUserList.DataSource = userList;
            this.gvUserList.DataBind();
        }

        private SystemUsers GetQueryCondition()
        {
            return new SystemUsers
            {
                IsStartPager = true,
                StartRecordIndex = PageHelper.GetStartIndex(),
                EndRecordIndex = PageHelper.GetEndIndex() < PageHelper.GetPageTotal()
                        ? PageHelper.GetPageTotal()
                        : PageHelper.GetEndIndex(),
                SysUserKeyList = ddlUsers.SelectedValue.Equals("0") ? _systemUsersService.SelectSystemChildrensKey(CurrentUser) : null,
                SysUserKey = int.Parse(ddlUsers.SelectedValue)
            };
        }

       

        private ISystemUsersService _systemUsersService;
    }
}