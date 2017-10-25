using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using CoolShow.BLL.Business;
using CoolShow.BLL.Interface.Business;
using CoolShow.Common;
using CoolShow.Model.Business;

namespace CoolShow.UI.Ashx
{
    /// <summary>
    /// BusinessLoginHandler 的摘要说明
    /// </summary>
    public class BusinessLoginHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json;charset=UTF-8";

            context.Response.Write(LoginSetting(context));
        }

        private string LoginSetting(HttpContext context)
        {
            var info = _businesserBaseInfosService.FindAll(new BusinesserBaseInfos()
            {
                MobilePhone = context.Request["mobile"],
                StoreUrl = context.Request["storeName"]
            });
            if (info == null ||info.Count ==0)
            {
                return "-1";
            }
            LoginSetCookie(info.First());
            SaveSession(info.First());
            return "0";
        }


        private void CheckRepeatedlyLogin(HttpContext context)
        {
            //var account = context.Request["txtAccount"];
            //var ip = GetIPHelper.GetIP();
            //var lockCount = _systemLockService.GetCount(new SystemLock { Account = account, IP = ip });
            //if (lockCount > 0)
            //    throw new HttpException("500");
            //var errCount = _systemErrLoginRecordService.GetCount(new SystemErrLoginRecord() { Account = account, IP = ip });
            //if (errCount > 5)
            //    throw new HttpException("500");
        }





        private static void SaveSession(BusinesserBaseInfos user)
        {
            HttpContext.Current.Session["BusinessUser"] = user.BusinesserBaseInfoKey;     //
            HttpContext.Current.Session["BusinessCode"] = user.LoginCode;
            HttpContext.Current.Session["UserType"] = "B";
        }


        /// <summary>
        /// 登录时设置cookie
        /// </summary>
        /// <param name="user"></param>
        private void LoginSetCookie(BusinesserBaseInfos user)
        {
            if (!string.IsNullOrEmpty(Cookie.GetCookie("businessKey")))
            {
                Cookie.DelCookie("businessKey");
            }
            if (!string.IsNullOrEmpty(Cookie.GetCookie("code")))
            {
                Cookie.DelCookie("code");
            }
            Cookie.SetCookie("businessKey", user.BusinesserBaseInfoKey.ToString(), 0);
            Cookie.SetCookie("code", user.LoginCode, 0);
        }

        IBusinesserBaseInfosService _businesserBaseInfosService = new BusinesserBaseInfosService();

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}