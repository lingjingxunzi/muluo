using System;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.UIProcess;

namespace MONO.Distribution.UI.Sys
{
    public partial class SystemUserLogList : ListPageBase
    {
        public SystemUserLogList()
        {
            _systemLogsService = new SystemLogsService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                SysUserKey = CurrentUser.SysUserKey
            };
        }

        private void BindDdlData()
        {

        }



        private readonly ISystemLogsService _systemLogsService;
    }
}