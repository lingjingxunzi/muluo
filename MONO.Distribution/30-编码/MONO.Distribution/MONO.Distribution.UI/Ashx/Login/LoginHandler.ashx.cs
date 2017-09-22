using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using log4net;
using log4net.Core;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Common;
using MONO.Distribution.Common.Log;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Model.ViewModel;
using MONO.Distribution.UIProcess;
using MONO.Distribution.Utility;

namespace MONO.Distribution.UI.Ashx.Login
{
    /// <summary>
    /// MerchantLoginHandler 的摘要说明
    /// </summary>
    public class LoginHandler : IHttpHandler, IRequiresSessionState
    {
        public LoginHandler()
        {
            LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _systemLogsService = new SystemLogsService();
            _verCodeRecordService = new VerCodeRecordService();
            _systemErrLoginRecordService = new SystemErrLoginRecordService();
            _systemLockService = new SystemLockService();
        }
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json;charset=UTF-8";
            var str = CheckLogin(context);
            context.Response.Write(str);
        }

        private string CheckLogin(HttpContext context)
        {
            if (CheckBeforeLogin(context)) return new JavaScriptSerializer().Serialize(new LoginResult { Result = 3, Message = "验证码错误！" });
            CheckRepeatedlyLogin(context);

            var results = loginByAcccountAndPwd(context.Request["txtAccount"], context.Request["txtPwd"]);
            return new JavaScriptSerializer().Serialize(results);
        }

        private void CheckRepeatedlyLogin(HttpContext context)
        {
            var account = context.Request["txtAccount"];
            var ip = GetIPHelper.GetIP();
            var lockCount = _systemLockService.GetCount(new SystemLock{ Account = account, IP = ip });
            if (lockCount > 0)
                throw new HttpException("500");
            var errCount =_systemErrLoginRecordService.GetCount(new SystemErrLoginRecord(){Account = account,IP = ip});
            if(errCount >5)
                throw new HttpException("500");
        }


        private bool CheckBeforeLogin(HttpContext context)
        {
            if (!CheckUserIp())
            {
                var ip = GetIPHelper.GetIP();
                var o = _verCodeRecordService.FindAll(new VerCodeRecords { IP = ip, VerCodeKey = context.Request["txtVerification"] });
                if (o.Count == 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 验证用户帐户
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        private LoginResult loginByAcccountAndPwd(string account, string password)
        {
            try
            {
                ISystemUsersService userService = new SystemUsersService();
                LogMsg.Info(new LogMessage(string.Format("登录：使用账号【{0}】发起登录操作。", account)) { IP = IPUtil.GetUserIP(), UserId = "", UserName = "" });
                var ip = GetIPHelper.GetIP();
                LogMsg.Info(GetIPHelper.GetIP());
                int userCount = userService.GetCount(new SystemUsers { Account = account });
                if (userCount == 0) return new LoginResult { Result = 1, Message = "账户不存在！" };
                SystemUsers user = userService.Login(account, password);
                if (user == null)
                {
                    _systemErrLoginRecordService.Insert(new SystemErrLoginRecord { Account = account, IP = ip, PWD = password });
                    return new LoginResult { Result = 1, Message = "用户名或密码错误！" };
                }
                else
                {
                    LoginSetCookie(user);
                    SetContext(user);
                    SaveSession(user);
                    _systemLogsService.Insert(new SystemLogs
                    {
                        SysUserKey = user.SysUserKey,
                        Content = string.Format("登录：使用账号【{0}】发起登录操作。", account),
                        IP = GetIPHelper.GetIP(),
                        Level = "1",
                        Module = "系统登录",
                        SystemLogKey = Guid.NewGuid()
                    });
                    FormsAuthentication.RedirectFromLoginPage(user.Account, false);
                    return new LoginResult { Result = 0, Message = "登录成功！" };

                }
            }
            catch (Exception err)
            {
                return new LoginResult { Result = 2, Message = err.Message };
            }
        }

        private static void SaveSession(SystemUsers user)
        {
            HttpContext.Current.Session["USER"] = user;     //
            HttpContext.Current.Session["Type"] = "M";
        }


        /// <summary>
        /// 登录时设置cookie
        /// </summary>
        /// <param name="user"></param>
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





        private bool CheckUserIp()
        {
            string ip = IPUtil.GetUserIP();
            var blackList = new List<string> { "202.109.166.212", "117.136.79.176" };
            if (blackList.Contains(ip))
            {
                throw new HttpException("500");
            }
            return false;
        }



        protected void SetContext(SystemUsers user)
        {
            Thread.SetData(Thread.GetNamedDataSlot(MyContext.Instance.USER), user);
            Thread.SetData(Thread.GetNamedDataSlot(MyContext.Instance.USER_ID), user.SysUserKey);
            Thread.SetData(Thread.GetNamedDataSlot(MyContext.Instance.USER_NAME), (user.SysUserInfos == null) ? user.Account : user.SysUserInfos.Name);
            Thread.SetData(Thread.GetNamedDataSlot(MyContext.Instance.Enter_Type), "M");
        }

        private ISystemLogsService _systemLogsService;
        private ILog LogMsg;

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private IVerCodeRecordService _verCodeRecordService;
        private ISystemErrLoginRecordService _systemErrLoginRecordService;
        private ISystemLockService _systemLockService;
    }
}