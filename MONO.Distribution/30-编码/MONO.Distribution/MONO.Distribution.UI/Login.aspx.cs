using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Common;
using MONO.Distribution.Model.Sys;

namespace MONO.Distribution.UI
{
    public partial class Login : Page
    {
        public Login()
        {
            _systemUsersService = new SystemUsersService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //var flag = Request.QueryString[ConfigurationSettings.AppSettings["LoginOutName"]];
                //if (!string.IsNullOrEmpty(flag) && flag.Equals(ConfigurationSettings.AppSettings["LoginOutKey"]))
                //{
                //    var admin = _systemUsersService.SelectByAccount("admin");
                //    LoginSetCookie(admin);
                //    SetContext(admin);
                //    SaveSession(admin);
                //    Response.Redirect("Default.aspx");
                //}
            }
        }


        private void LoginSetCookie(SystemUsers user)
        {
            if (!string.IsNullOrEmpty(Cookie.GetCookie("username")))
            {
                Cookie.DelCookie("username");
            }
            if (!string.IsNullOrEmpty(Cookie.GetCookie("userpwd")))
            {
                Cookie.DelCookie("userpwd");
            }
            Cookie.SetCookie("username", user.Account, 0);
            Cookie.SetCookie("userpwd", user.PWD, 0);
        }

        private static void SaveSession(SystemUsers user)
        {
            HttpContext.Current.Session["USER"] = user;     //

        }

        protected void SetContext(SystemUsers user)
        {
            Thread.SetData(Thread.GetNamedDataSlot(MyContext.Instance.USER), user);
            Thread.SetData(Thread.GetNamedDataSlot(MyContext.Instance.USER_ID), user.SysUserKey);
            Thread.SetData(Thread.GetNamedDataSlot(MyContext.Instance.USER_NAME), (user.SysUserInfos == null) ? user.Account : user.SysUserInfos.Name);
            Thread.SetData(Thread.GetNamedDataSlot(MyContext.Instance.Enter_Type), "M");
        }

        private ISystemUsersService _systemUsersService;
    }
}