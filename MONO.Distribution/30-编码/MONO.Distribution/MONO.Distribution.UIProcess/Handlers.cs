using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace MONO.Distribution.UIProcess
{
    public class Handlers : IHttpHandler, IReadOnlySessionState
    {
        bool IHttpHandler.IsReusable
        {
            get { return true; }
        }

        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            if (context.Session["User"] == null)
            {
                context.Response.Redirect("http://www.baidu.com");
            }
        }
    }
}
