using System.Web;

namespace MONO.Distribution.Utility
{
    public class GetIPHelper
    {
        public static string GetIP()
        {
            HttpRequest request = HttpContext.Current.Request;
            string result = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result))
            {
                result = request.ServerVariables["REMOTE_ADDR"];
            }
            if (string.IsNullOrEmpty(result))
            {
                result = request.UserHostAddress;
            }
            if (string.IsNullOrEmpty(result))
            {
                result = "0.0.0.0";
            }
            if (!string.IsNullOrEmpty(result) && result.Equals("::1"))
            {
                result = "127.0.0.1";
            }
            return result;
        }
    }
}
