using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Customers;
using MONO.Distribution.BLL.Interface.Customers;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.UIProcess;

namespace MONO.Distribution.UI.FinanceManage
{
    public partial class AccountApplyReviewEdit : EditPageBase
    {
        public AccountApplyReviewEdit()
        {
            _systemAccountLogService = new SystemAccountLogService();
            _companyAccountAddApplysService = new CompanyAccountAddApplysService();
            _systemAccountService = new SystemAccountService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected override void SetUpdate()
        {

            var companyInfo = _companyAccountAddApplysService.FindById(Id);
            if (companyInfo.ApplyStatus.Equals("ApplyDSH"))
            {
                this.btnCreate.Visible = true;
                this.btnUpdate.Visible = true;
            }
            else
            {
                this.btnCreate.Visible = false;
                this.btnUpdate.Visible = false;
            }
            this.txtApplyAccName.Text = companyInfo.BeApplyUser.Account + (string.IsNullOrEmpty(companyInfo.BeApplyUser.Nick) ? "" : ("(" + companyInfo.BeApplyUser.Nick + ")"));
            this.txtAmount.Text = (companyInfo.AccountIntegrel / 100).ToString("N2");
            this.txtRemark.Text = companyInfo.Remark;
            this.txtApplyUserName.Text = companyInfo.ApplyUser.Nick;
            this.imgs.ImageUrl = (companyInfo.AccountApplyAttses != null && companyInfo.AccountApplyAttses.Count > 0) ? companyInfo.AccountApplyAttses.First().ImagePath : "";
        }

        protected void btnRefused_OnClick(object sender, EventArgs e)
        {
            var companyInfo = _companyAccountAddApplysService.FindById(Id);
            companyInfo.ApplyStatus = "ApplyJJ";
            ResultMessage = _companyAccountAddApplysService.Update(companyInfo);
            OperationEnd("上账审核", "审核拒绝");
        }

        protected void btnAgree_OnClick(object sender, EventArgs e)
        {
            var companyInfo = _companyAccountAddApplysService.FindById(Id);
            companyInfo.ApplyStatus = "ApplySHTG";
            var accountInfo = _systemAccountService.SelectSystemAccountByUserKey(companyInfo.CompanyKey);
            ResultMessage = _companyAccountAddApplysService.Update(companyInfo);
            _systemAccountLogService.Insert(new SystemAccountLog
            {
                Seq = companyInfo.AccountAddApplyKey.ToString(),
                AccountLogKey = Guid.NewGuid(),
                CompanyAccountKey = accountInfo.CompanyAccountKey,
                Integral = companyInfo.AccountIntegrel,
                OperaType = "SHSZ" //审核上账
            });
            OperationEnd("上账审核", "审核通过");
        }

        private ICompanyAccountAddApplysService _companyAccountAddApplysService;
        private ISystemAccountLogService _systemAccountLogService;
        private ISystemAccountService _systemAccountService;
    }
}