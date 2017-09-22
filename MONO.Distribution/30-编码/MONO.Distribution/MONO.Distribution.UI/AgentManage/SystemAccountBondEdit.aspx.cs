using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.UIProcess;
using MONO.Distribution.Utility;

namespace MONO.Distribution.UI.AgentManage
{
    public partial class SystemAccountBondEdit : EditPageBase
    {
        public SystemAccountBondEdit()
        {
            _systemAccountService = new SystemAccountService();
            _rechargeRecordsService = new RechargeRecordsService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected override void SetUpdate()
        {
            base.SetUpdate();
            this.tr_turnout.Visible = true;
            name = "转出";
            BindBaseInfo();
        }

        private void BindBaseInfo()
        {
            var accountInfo = _systemAccountService.SelectSystemAccountByUserKey(int.Parse(Request.QueryString["UserKey"]));
            if (accountInfo == null) return;
            this.txtName.Text = accountInfo.SystemUsers.Account;
            this.txtLeft.Text = accountInfo.LeftAccount.ToString();
            this.txtTotal.Text = accountInfo.TotalAccount.ToString();
            txtCurrentLeft.Text = accountInfo.Bond.ToString();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            //if (ValidateInfo()) return;
            var code = Guid.NewGuid().ToString();
            var sysAccount = _systemAccountService.SelectSystemAccountByUserKey(int.Parse(Request.QueryString["UserKey"]));
            sysAccount.Bond = int.Parse(txtTurnOut.Text.Trim());
            _systemAccountService.UpdateSystemAccountForBond(sysAccount);
            ResultMessage = new ResultMessage();
            OperationEnd("用户账户", "账户" + name + "-" + txtName.Text + "账户，" + name + "金额为" + txtTurnOut.Text);
        }

        private bool ValidateInfo()
        {
            var account = _systemAccountService.SelectSystemAccountByUserKey(int.Parse(Request.QueryString["UserKey"]));
            if (account != null && account.LeftAccount >= Convert.ToInt32(txtTurnOut.Text.Trim()))
            {
                return false;
            }
            lblError.Visible = true;
            lblError.Text = "账户余额不足！";
            return true;
        }

        private ISystemAccountService _systemAccountService;
        private string name;
        private IRechargeRecordsService _rechargeRecordsService;
    }
}