using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Customers;
using MONO.Distribution.BLL.Interface.Customers;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Customers;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.UIProcess;

namespace MONO.Distribution.UI.CustomerManage
{
    public partial class CompanyAccountApplyEdit : EditPageBase
    {
        public CompanyAccountApplyEdit()
        {
            _companyAccountAddApplysService = new CompanyAccountAddApplysService();
            _systemUsersService = new SystemUsersService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDdlData();
            }
        }

        private void BindDdlData()
        {
            var systemUserList = _systemUsersService.FindAll(new SystemUsers());
            foreach (var systemUserse in systemUserList)
            {
                ddlCompany.Items.Add(new ListItem(systemUserse.Account + systemUserse.Nick, systemUserse.SysUserKey.ToString()));
            }
            ddlCompany.Items.Insert(0, new ListItem("请选择", "0"));
        }

        protected override void SetInsert()
        {
            btnUpdate.Visible = false;
            btnCreate.Visible = true;
        }

        protected override void SetUpdate()
        {
            btnUpdate.Visible = true;
            btnCreate.Visible = false;
        }

        protected void btnCreate_OnClick(object sender, EventArgs e)
        {
            var models = new CompanyAccountAddApplys();
            GetCompanyAccountModels(models);
            ResultMessage = _companyAccountAddApplysService.Insert(models);
            OperationEnd("账户申请", "账户" + ddlCompany.Text + "申请上账" + txtApplyInter + "积分，操作人账号：" + CurrentUser.Account);
        }


        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {

        }


        private CompanyAccountAddApplys GetCompanyAccountModels(CompanyAccountAddApplys models)
        {
            models.AccountIntegrel = int.Parse(txtApplyAcc.Value) * 100;
            models.ApplyStatus = "ApplyDSH";
            models.SysUserKey = this.CurrentUser.SysUserKey;
            models.Remark = txtRemark.Text;
            models.CompanyKey = int.Parse(ddlCompany.SelectedValue);
            models.AccountApplyAttses = new List<AccountApplyAtts>();
            var atts = new AccountApplyAtts();
            string uploadName = InputFile.Value;
            if (string.IsNullOrEmpty(InputFile.Value)) return models;
            if (InputFile.Value != "")
            {
                int idx = uploadName.LastIndexOf(".");
                string suffix = uploadName.Substring(idx);//获得上传的图片的后缀名
                atts.Name = DateTime.Now.Ticks + suffix;
            }
            try
            {
                if (!string.IsNullOrEmpty(uploadName))
                {
                    string path = Server.MapPath("~/ApplyImages/");
                    atts.ImagePath = ConfigurationManager.AppSettings["AccApplyImageUrl"] + atts.Name; ;
                    InputFile.PostedFile.SaveAs(path + atts.Name);
                }
                models.AccountApplyAttses.Add(atts);
            }
            catch (Exception ex)
            {
                LogMsg.Info(ex.Message);
            }
            return models;
        }


        private ICompanyAccountAddApplysService _companyAccountAddApplysService;

        private ISystemUsersService _systemUsersService;

    }
}