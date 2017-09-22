using System;
using System.Collections.Generic;
using System.Configuration;
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
    public partial class SystemBackupEdit : EditPageBase
    {
        public SystemBackupEdit()
        {
            _dataBackupsService = new DataBackupsService();
            _enumerationService = new EnumerationService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBaseInfo();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            if (ValidateInfo()) return;
            var info = new DataBackups();
            GetSettingValue(info);
            ResultMessage = _dataBackupsService.Insert(info);
            OperationEnd("备份设置", "备份新增-" + info.BackNumber);
        }
        
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            if (ValidateInfo()) return;
            var info = _dataBackupsService.FindById(Id);
            GetSettingValue(info);
            ResultMessage = _dataBackupsService.Insert(info);
            OperationEnd("备份设置", "备份设置-" + info.BackNumber + "修改");
        }


        private void GetSettingValue(DataBackups info)
        {
            info.BackStyle = styleAll.Checked ? "BackupAll" : "BackupSome";
            info.BackNumber = txtNumber.Text.Trim();
            info.BackupTime = Convert.ToDateTime(txtTime.Text);
            info.BackupUrl = txtPath.Text;
            info.Cycle = ddlClycle.SelectedValue;
            info.FileFolder = ConfigurationManager.AppSettings["BackupFolder"];
            info.TableName = ddlTables.SelectedValue;
        }
        private bool ValidateInfo()
        {
            if (styleSome.Checked && string.IsNullOrEmpty(ddlTables.SelectedValue))
            {
                lblError.Text = "*备份表未选择！";
                lblError.Visible = true;
                return true;
            }
            if (string.IsNullOrEmpty(txtNumber.Text.Trim()))
            {
                lblError.Text = "*备份编号不能为空！";
                lblError.Visible = true;
                return true;
            }
            if (string.IsNullOrEmpty(ddlClycle.SelectedValue))
            {
                lblError.Text = "*备份类型未选择！";
                lblError.Visible = true;
                return true;
            }

            if (string.IsNullOrEmpty(txtTime.Text.Trim()))
            {
                lblError.Text = "*首次备份日期不能为空！";
                lblError.Visible = true;
                return true;
            }
            return false;
        }


        private void BindBaseInfo()
        {
            var tableList = _dataBackupsService.SelectTableNames(new DataBackups());
            foreach (var name in tableList)
            {
                ddlTables.Items.Add(new ListItem(name, name));
            }
            ddlTables.Items.Insert(0, new ListItem("请选择", ""));
            var clycleList = _enumerationService.SelectEnumerationsByTypeName("Backupclycle");
            this.ddlClycle.DataSource = clycleList;
            this.ddlClycle.DataTextField = "EnumValue";
            this.ddlClycle.DataValueField = "EnumKey";
            this.ddlClycle.DataBind();
            this.ddlClycle.Items.Insert(0, new ListItem("请选择", ""));
        }

        private IEnumerationService _enumerationService;
        private IDataBackupsService _dataBackupsService;
    }
}