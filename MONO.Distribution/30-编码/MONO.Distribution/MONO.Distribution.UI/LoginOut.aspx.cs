using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.UIProcess;

namespace MONO.Distribution.UI
{
    public partial class LoginOut : ListPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = (SystemUsers)HttpContext.Current.Session["USER"];
                WriteLog("退出系统", user.Account + "于" + DateTime.Now + "退出系统", "");
                HttpContext.Current.Session.Remove("USER");
                Response.Redirect("/Login.aspx");
            }
        }
    }
}