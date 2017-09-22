using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace MONO.Distribution.UI.Ashx.Agent
{
    /// <summary>
    /// FilterUserPhoneHandler 的摘要说明
    /// </summary>
    public class FilterUserPhoneHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json;charset=UTF-8";
            context.Response.Write(GetUserPhone(context));
        }

        private string GetUserPhone(HttpContext context)
        {
            var sb = new StringBuilder();
            IList<string> userphones = new List<string>();
            var str = context.Request["txtPhone"];
            if (string.IsNullOrEmpty(str)) return new JavaScriptSerializer().Serialize("");
            var strArr = str.Split(';');
            foreach (var s in strArr)
            {
                if (userphones.Where(m => m.Equals(s)).Count() == 0)
                    userphones.Add(s);
            }
            foreach (var userphone in userphones)
            {
                sb.Append(userphone + ";");
            }
            return new JavaScriptSerializer().Serialize(sb.ToString().TrimEnd(';'));
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