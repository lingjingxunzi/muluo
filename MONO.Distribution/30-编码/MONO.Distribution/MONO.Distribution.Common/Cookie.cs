using System;

namespace MONO.Distribution.Common
{
    /// <summary>
    /// Cookie操作类
    /// </summary>
    public class Cookie
    {
        /// <summary>
        /// 判断是否有这个Cookie名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool CheckCookie(string name)
        {
            if (System.Web.HttpContext.Current.Request.Cookies[name] == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 读取Cookie值
        /// </summary>
        /// <param name="name">要读读取的Cookie的键</param>
        /// <returns></returns>
        public static string GetCookie(string name)
        {
            if (System.Web.HttpContext.Current.Request.Cookies[name] == null)
                return null;
            else
                return System.Web.HttpContext.Current.Request.Cookies[name].Value;
        }

        /// <summary>
        /// 读取Cookie下指定的subCookie值（子Cookie的值）
        /// </summary>
        /// <param name="name">父Cookie的键</param>
        /// <param name="subname">子Cookie的键</param>
        /// <returns>返回子Cookie的值，如果没有则返回null</returns>
        public static string GetCookie(string name, string subname)
        {
            if (name != null || subname != null)
            {
                if (System.Web.HttpContext.Current.Request.Cookies[name] == null)
                    return null;
                else
                    return System.Web.HttpContext.Current.Request.Cookies[name][subname];
            }
            else
                return null;
        }

        /// <summary>
        /// 创建新Cookie
        /// </summary>
        /// <param name="strname">键</param>
        /// <param name="strvalue">值</param>
        /// <param name="Minute">有效分钟数，小于0则随浏览器进程(关闭时cookie失效)</param>
        public static void SetCookie(string strname, string strvalue, int Minute)
        {
            try
            {
                System.Web.HttpCookie cookie = new System.Web.HttpCookie(strname, strvalue);
                if (Minute > 0)
                    cookie.Expires = DateTime.Now.AddMinutes(Minute);
                System.Web.HttpContext.Current.Response.AppendCookie(cookie);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 创建新子Cookie
        /// </summary>
        /// <param name="strname">父Cookie的键</param>
        /// <param name="strsubname">子cookie的键</param>
        /// <param name="strvalue">子cookie的值</param>
        public static void SetSubCookie(string strname, string strsubname, string strvalue)
        {
            try
            {
                if (System.Web.HttpContext.Current.Request.Cookies[strname] != null)
                {
                    System.Web.HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies[strname];
                    cookie.Values.Set(strsubname, strvalue);
                    System.Web.HttpContext.Current.Request.Cookies.Set(cookie);
                    System.Web.HttpContext.Current.Response.AppendCookie(cookie);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 删除Cookie
        /// </summary>
        /// <param name="strname"></param>
        public static void DelCookie(string strname)
        {
            if (System.Web.HttpContext.Current.Request.Cookies[strname] != null)
            {
                System.Web.HttpContext.Current.Response.Cookies.Remove(strname);
            }
        }
    }
}
