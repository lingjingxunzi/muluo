using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Sys;

namespace MONO.Distribution.UI.Ashx.Login
{
    /// <summary>
    /// GetCurrentAccountHandler 的摘要说明
    /// </summary>
    public class GetCurrentAccountHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            user = context.Session["USER"] as SystemUsers;
            context.Response.ContentType = "text/plain";
            if (user != null)
            {
                var userInfo = _systemUsersService.SelectByAccount(user.Account);
                context.Response.Write(userInfo.SystemAccount.LeftAccount);
            }
            else
            {
                context.Response.Write("0");
            }
           
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private SystemUsers user = null;
        private ISystemUsersService _systemUsersService = new SystemUsersService();
    }
}