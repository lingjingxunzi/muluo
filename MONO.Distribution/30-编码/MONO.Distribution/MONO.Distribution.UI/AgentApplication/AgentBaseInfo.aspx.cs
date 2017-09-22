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
using MONO.Distribution.Utility;

namespace MONO.Distribution.UI.AgentApplication
{
    public partial class AgentBaseInfo : ListPageBase
    {
        public AgentBaseInfo()
        {
            _sytSystemUsersService = new SystemUsersService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBaseInfo();
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var systemUser = GetCurrentBaseInfo();
            var result = _sytSystemUsersService.Update(systemUser);
            if (result.IsOk)
            {
                WriteLog("用户个人信息", "修改成功-帐号：" + systemUser.Account, "");
            }
            else
            {
                WriteLog("用户个人信息", "修改失败-帐号：" + systemUser.Account + "错误原因：" + GetNotice(result), "");
            }
        }

        private SystemUsers GetCurrentBaseInfo()
        {
            CurrentUser.Account = txtAccount.Text.Trim();
            //CurrentUser.PWD = txtPwd.Text.Trim();
            CurrentUser.Nick = txtNick.Text.Trim();
            return CurrentUser;
        }


        private void BindBaseInfo()
        {
            txtAccount.Text = CurrentUser.Account;
            //txtPwd.Text = CurrentUser.PWD;
            txtNick.Text = CurrentUser.Nick;
            txtSec.Text = CurrentUser.AgentSec;
            txtUrl.Text = CurrentUser.BackUrl;
        }


        protected void btnUpdateSec_OnClick(object sender, EventArgs e)
        {
             GetGuidStrHandler.GenerateStringID();
        }
        private ISystemUsersService _sytSystemUsersService;
    }
}