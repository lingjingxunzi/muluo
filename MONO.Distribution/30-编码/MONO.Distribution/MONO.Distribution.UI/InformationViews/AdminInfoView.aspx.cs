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

namespace MONO.Distribution.UI.InformationViews
{
    public partial class AdminInfoView : EditPageBase
    {
        public AdminInfoView()
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            var info = _systemUsersService.SelectByAccount("admin");
            this.txtNick.Text = info.Account;
            this.txtAccount.Text = info.Nick;
            this.txtPwd.Text = info.PWD;
        }
    }
}