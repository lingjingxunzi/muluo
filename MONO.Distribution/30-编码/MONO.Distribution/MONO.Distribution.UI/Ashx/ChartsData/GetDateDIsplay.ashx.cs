using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Sys;

namespace MONO.Distribution.UI.Ashx.ChartsData
{
    /// <summary>
    /// GetDateDIsplay 的摘要说明
    /// </summary>
    public class GetDateDIsplay : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json;charset=UTF-8";
            context.Response.CacheControl = "no-cache";
            context.Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1);
            context.Response.Write(GetData(context));
        }

        private string GetData(HttpContext context)
        {
            var name = context.Request["dates"];
            var list = _systemUsersService.SelectDateForEveryDate(new SystemUsers() { QueryDate = name });
            return new JavaScriptSerializer().Serialize(list); ;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        private ISystemUsersService _systemUsersService = new SystemUsersService();
    }
}