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

namespace MONO.Distribution.UI.AgentApplication
{
    public partial class AgentBrowseLogList : ListPageBase
    {
        public AgentBrowseLogList()
        {
            _systemLogsService = new SystemLogsService();
            _enumerationService = new EnumerationService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDdlData();
                BindLogData();
            }
        }

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





        private void BindLogData()
        {
            var user = GetQueryCondition();
            SetPager(user);
            var userList = _systemLogsService.FindAll(user);
            gvSystemLogList.DataSource = userList;
            gvSystemLogList.DataBind();

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
                //StartTime = txtStartQueryDateTime.Text,
                //EndTime = txtEndQueryDateTime.Text,
                SysUserKey = CurrentUser.SysUserKey
            };
        }

        private void BindDdlData()
        {
            var enums = _enumerationService.SelectEnumerationsByTypeName("ModualName");
            this.ddlLogModual.DataSource = enums;
            this.ddlLogModual.DataTextField = "EnumValue";
            this.ddlLogModual.DataValueField = "EnumKey";
            this.ddlLogModual.DataBind();
            this.ddlLogModual.Items.Insert(0, new ListItem("请选择", ""));
        }



        private readonly ISystemLogsService _systemLogsService;
        private IEnumerationService _enumerationService;
    }
}