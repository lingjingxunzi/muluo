using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using log4net;

namespace MONO.Distribution.UI.Ashx.Order
{
    /// <summary>
    /// GetCTBDResultHandler 的摘要说明
    /// </summary>
    public class GetCTBDResultHandler : IHttpHandler
    {
        public GetCTBDResultHandler()
        {
            LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            LogMsg.Info(context.Request.Url);
            context.Response.Write("ok");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private ILog LogMsg;

    }
}