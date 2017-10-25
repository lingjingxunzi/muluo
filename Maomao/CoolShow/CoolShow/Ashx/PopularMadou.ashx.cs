using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolShow.UI.Ashx
{
    /// <summary>
    /// PopularMadou 的摘要说明
    /// </summary>
    public class PopularMadou : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json;charset=UTF-8";
            context.Response.Write(GetPopular());
        }

        private string GetPopular()
        {
            return "0";
        }

        

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}