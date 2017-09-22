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

namespace MONO.Distribution.UI
{
    public partial class Top : ListPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtAccount.Text = CurrentUser.Account;
                var accounts =  _systemUsersService.SelectByAccount(CurrentUser.Account);
                bb.InnerText = accounts.SystemAccount == null ? "0" : accounts.SystemAccount.LeftAccount.ToString();
            }
        }

        protected void btnLogOut_OnClick(object sender, EventArgs e)
        {
           
        }


         private ISystemUsersService _systemUsersService = new SystemUsersService();
    }
}