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

namespace MONO.Distribution.UI.Sys
{
    public partial class SystemBackupList : ListPageBase
    {
        public SystemBackupList()
        {
            _dataBackupsService = new DataBackupsService();
            _enumerationService = new EnumerationService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindQueryData();
                BindData();
            }
        }



        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnPage_Click(object sender, EventArgs e)
        {
            PageHelper.SetPageIndex(int.Parse(hidePage.Value));
            BindData();
        }


        private void BindData()
        {
            var condition = GetQueryCondition();
            SetPager(_dataBackupsService.GetCount(condition), 10);
            var list = _dataBackupsService.FindAll(condition);
            this.gvBackupList.DataSource = list;
            this.gvBackupList.DataBind();
        }

        private DataBackups GetQueryCondition()
        {
            return new DataBackups
            {
                IsStartPager = true,
                StartRecordIndex = PageHelper.GetStartIndex(),
                EndRecordIndex = PageHelper.GetEndIndex() < PageHelper.GetPageTotal()
                        ? PageHelper.GetPageTotal()
                        : PageHelper.GetEndIndex(),
                BackStyle = ddlStyle.SelectedValue,
                Cycle = ddlclycle.SelectedValue
            };
        }

        private void BindQueryData()
        {
            var clycleList = _enumerationService.SelectEnumerationsByTypeName("Backupclycle");
            this.ddlclycle.DataSource = clycleList;
            this.ddlclycle.DataTextField = "EnumValue";
            this.ddlclycle.DataValueField = "EnumKey";
            this.ddlclycle.DataBind();
            this.ddlclycle.Items.Insert(0, new ListItem("请选择", ""));
            var styleList = _enumerationService.SelectEnumerationsByTypeName("BackupStyles");
            this.ddlStyle.DataSource = styleList;
            this.ddlStyle.DataTextField = "EnumValue";
            this.ddlStyle.DataValueField = "EnumKey";
            this.ddlStyle.DataBind();
            this.ddlStyle.Items.Insert(0, new ListItem("请选择", ""));
        }


        private IDataBackupsService _dataBackupsService;
        private IEnumerationService _enumerationService;
    }
}