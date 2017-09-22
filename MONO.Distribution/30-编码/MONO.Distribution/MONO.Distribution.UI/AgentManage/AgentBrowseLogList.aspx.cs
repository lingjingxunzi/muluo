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
    public partial class AgentBrowseLogList : ListPageBase
    {
        public AgentBrowseLogList()
        {
            _systemLogsService = new SystemLogsService();
            _enumerationService = new EnumerationService();
            _systemUsersService = new SystemUsersService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindQueryData();
                BindLogData();
            }
        }



        #region
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindLogData();
            WriteLog("系统日志管理", "日志查询", "");
        }

        protected void gvSystemLogList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }


        protected void btnPage_Click(object sender, EventArgs e)
        {
            PageHelper.SetPageIndex(int.Parse(hidePage.Value));
            BindLogData();
        }


        #endregion


        private void BindLogData()
        {
            var user = GetQueryCondition();
            SetPager(user);
            var userList = _systemLogsService.FindAll(user);
            gvSystemLogList.DataSource = userList;
            gvSystemLogList.DataBind();
        }


        private void BindQueryData()
        {
            var enums = _enumerationService.SelectEnumerationsByTypeName("ModualName");
            this.ddlLogModual.DataSource = enums;
            this.ddlLogModual.DataTextField = "EnumValue";
            this.ddlLogModual.DataValueField = "EnumKey";
            this.ddlLogModual.DataBind();
            this.ddlLogModual.Items.Insert(0, new ListItem("请选择", ""));
            var userList = _systemUsersService.SelectSystemChildrensKeyForAllInfo(new SystemUsers { SysUserKey = CurrentUser.SysUserKey });
            this.ddlUsers.DataSource = userList;
            this.ddlUsers.DataTextField = "Account";
            this.ddlUsers.DataValueField = "SysUserKey";
            this.ddlUsers.DataBind();
            this.ddlUsers.Items.Insert(0, new ListItem("请选择", "0"));
        }
        private void SetPager(SystemLogs user)
        {
            SetPager(_systemLogsService.GetCount(user), 10);
        }

        private SystemLogs GetQueryCondition()
        {
            return new SystemLogs
            {
                IsStartPager = true,
                StartRecordIndex = PageHelper.GetStartIndex(),
                EndRecordIndex = PageHelper.GetEndIndex() < PageHelper.GetPageTotal()
                        ? PageHelper.GetPageTotal()
                        : PageHelper.GetEndIndex(),
                StartTime = txtStartQueryDateTime.Text,
                EndTime = txtEndQueryDateTime.Text,
                SysUserKey = int.Parse(ddlUsers.SelectedValue),
                SysUserKeyList = ddlUsers.SelectedValue.Equals("0") ? _systemUsersService.SelectSystemChildrensKey(new SystemUsers { SysUserKey = CurrentUser.SysUserKey }) :null,
                Module = string.IsNullOrEmpty(ddlLogModual.SelectedValue) ? "" : ddlLogModual.SelectedItem.Text
            };
        }



        private IEnumerationService _enumerationService;
        private ISystemUsersService _systemUsersService;
        private readonly ISystemLogsService _systemLogsService;
    }
}