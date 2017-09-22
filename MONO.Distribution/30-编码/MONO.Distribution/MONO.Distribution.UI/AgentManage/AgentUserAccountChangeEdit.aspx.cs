using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.Alipay;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.AlipayViewModel;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.UIProcess;

namespace MONO.Distribution.UI.AgentManage
{
    public partial class AgentUserAccountChangeEdit : EditPageBase
    {
        public AgentUserAccountChangeEdit()
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
            this.txtName.Text = accountInfo.SystemUsers.Account;
            this.txtLeft.Text = accountInfo.LeftAccount.ToString();
            this.txtTotal.Text = accountInfo.TotalAccount.ToString();
            var curr = _systemAccountService.SelectSystemAccountByUserKey(CurrentUser.SysUserKey);
            txtCurrentLeft.Text = curr == null ? "0" : curr.LeftAccount.ToString();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            if (ValidateInfo()) return;
            var code = Guid.NewGuid().ToString();
            ResultMessage = _systemAccountService.SystemAccountChange(int.Parse(Request.QueryString["UserKey"]), code, -int.Parse(txtTurnOut.Text), "ZC");
            if (ResultMessage.IsOk)
            {
                ResultMessage = _systemAccountService.SystemAccountChange(CurrentUser.SysUserKey, code, int.Parse(txtTurnOut.Text), "ZC");
                ResetCurrentInfo();
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script language=javascript>this.parent.parent.window.document.getElementById('topFrame').contentWindow.updateAccount();</script>");
            }
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