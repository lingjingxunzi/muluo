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
    public partial class AgentAccountLogList : ListPageBase
    {
        public AgentAccountLogList()
        {
            _systemAccountLogService = new SystemAccountLogService();
            _enumerationService = new EnumerationService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDdlData();
                BindData();
            }
        }

        private void BindDdlData()
        {
            var enums = _enumerationService.SelectEnumerationsByTypeName("LogType");
            this.ddlChargeType.DataSource = enums;
            this.ddlChargeType.DataTextField = "EnumValue";
            this.ddlChargeType.DataValueField = "EnumKey";
            this.ddlChargeType.DataBind();
            this.ddlChargeType.Items.Insert(0, new ListItem("请选择", ""));
        }



        protected void btnPage_Click(object sender, EventArgs e)
        {
            PageHelper.SetPageIndex(int.Parse(hidePage.Value));
            BindData();
        }

        protected void gvSystemLogList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
            WriteLog("账户管理", "账户查询", "");
        }



        private void BindData()
        {
            var condition = GetQueryCondition();
            SetPager(_systemAccountLogService.GetCount(condition), 10);
            var list = _systemAccountLogService.FindAll(condition);
            this.gvSystemLogList.DataSource = list;
            this.gvSystemLogList.DataBind();
        }

        private SystemAccountLog GetQueryCondition()
        {
            return new SystemAccountLog
            {
                IsStartPager = true,
                StartRecordIndex = PageHelper.GetStartIndex(),
                EndRecordIndex = PageHelper.GetEndIndex() < PageHelper.GetPageTotal()
                    ? PageHelper.GetPageTotal()
                    : PageHelper.GetEndIndex(),
                CompanyAccountKey = CurrentUser.SystemAccount.CompanyAccountKey,
                StartTime = txtStartQueryDateTime.Text,
                EndTime = txtEndQueryDateTime.Text,
                OperaType = ddlChargeType.SelectedValue
            };
        }

        private ISystemAccountLogService _systemAccountLogService;
        private IEnumerationService _enumerationService;
    }
}