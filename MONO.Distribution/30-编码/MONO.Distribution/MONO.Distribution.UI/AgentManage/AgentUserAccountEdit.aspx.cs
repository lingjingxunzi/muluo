using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.UIProcess;

namespace MONO.Distribution.UI.AgentManage
{
    public partial class AgentUserAccountEdit : EditPageBase
    {
        public AgentUserAccountEdit()
        {
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
            base.SetUpdate();
            BindBaseInfo();
        }

        private void BindBaseInfo()
        {
            var accountInfo = _systemAccountService.SelectSystemAccountByUserKey(int.Parse(Request.QueryString["UserKey"]));
            this.txtName.Text = accountInfo.SystemUsers.Account;
            this.txtLeft.Text = accountInfo.LeftAccount.ToString();
            this.txtTotal.Text = accountInfo.TotalAccount.ToString();
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var account = _systemAccountService.SelectSystemAccountByUserKey(int.Parse(Request.QueryString["UserKey"]));
            var changeLeft = int.Parse(txtLeft.Text) - account.LeftAccount;
            ResultMessage = _systemAccountService.SystemAccountChange(CurrentUser.SysUserKey, Guid.NewGuid().ToString(), changeLeft, "XG");
            ResetCurrentInfo();
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script language=javascript>this.parent.parent.window.document.getElementById('topFrame').contentWindow.updateAccount();</script>");
            if (ResultMessage.IsOk)
            {
                var accountTotal = _systemAccountService.SelectSystemAccountByUserKey(int.Parse(Request.QueryString["UserKey"]));
                accountTotal.TotalAccount = int.Parse(txtTotal.Text);
                ResultMessage = _systemAccountService.Update(accountTotal);
            }
            OperationEnd("用户账户", "账户修改-" + txtName.Text + "账户，总积分为：" + txtTotal.Text + " 剩余积分为：" + txtLeft.Text);
        }

        private ISystemAccountService _systemAccountService;


    }
}