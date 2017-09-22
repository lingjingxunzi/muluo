
using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace MONO.Distribution.Common
{
    /// <summary>
    /// IP信息辅助类
    /// </summary>
    public class IPUtil
    {
        /// <summary>
        /// 得到站点用户IP, IpSTR = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString()
        /// </summary>
        /// <returns></returns>
        public static string GetUserIP()
        {
            //解决代理访问时获取ip不对的问题
            if (HttpContext.Current == null)
                return null;

            string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(result))
            {
                //可能有代理 
                if (result.IndexOf(".", StringComparison.Ordinal) == -1)    //没有“.”肯定是非IPv4格式 
                    result = null;
                else
                {
                    if (result.IndexOf(",", StringComparison.Ordinal) != -1)
                    {
                        //有“,”，估计多个代理。取第一个不是内网的IP。 
                        result = result.Replace(" ", "").Replace("’", "");
                        string[] temparyip = result.Split(",;".ToCharArray());
                        foreach (string t in temparyip)
                        {
                            if (IsIPAddress(t)
                                && t.Substring(0, 3) != "10."
                                && t.Substring(0, 7) != "192.168"
                                && t.Substring(0, 7) != "172.16.")
                            {
                                return t;    //找到不是内网的地址 
                            }
                        }
                    }
                    else if (IsIPAddress(result)) //代理即是IP格式 
                        return result;
                    else
                        result = null;    //代理中的内容 非IP，取IP 
                }
            }

            result = string.IsNullOrEmpty(result) ? HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] : HttpContext.Current.Request.UserHostAddress;

            return result;
        }
        /// <summary>
        /// 判断是否是IP地址格式 0.0.0.0
        /// </summary>
        /// <param name="str1">待判断的IP地址</param>
        /// <returns>true or false</returns>
        /// 
        public static bool IsIPAddress(string str1)
        {
            if (string.IsNullOrEmpty(str1) || str1.Length < 7 || str1.Length > 15) return false;

            const string regformat = @"^\d{1,3}[\.]\d{1,3}[\.]\d{1,3}[\.]\d{1,3}$";
            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);
            return regex.IsMatch(str1);
        }

        /// <summary>
        /// 根据IP地址，获取对应的物理地址。如IP（113.204.192.29）对应的物理地址为：重庆市 联通
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <returns>物理地址</returns>
        public static string GetPhysicalAddressByIp(string ip)
        {
            string url = string.Format("http://ip138.com/ips138.asp?ip={0}", ip);

            var html = GetResponseHtmlByUrl(url);

            var reg1 = @"<(strong) .{1,}>查{1,}.*?</\1>";
            const string REG2 = @"<(li)>本站{1,}.*?</\1>";

            Regex regex = new Regex(REG2, RegexOptions.IgnoreCase);
            MatchCollection matchCollection = regex.Matches(html);
            var matchCount = matchCollection.Count;
            if (matchCount == 0)
            {
                log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType).Error("没有找到匹配的数据");
                return "";
            }
            if (matchCount > 1)
            {
                log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType).Warn(string.Format("找到匹配数据有{0}条，数据异常！", matchCount));
            }

            //var temArray = Regex.Replace(matchCollection[0].Value, @"<(strong).*?>|</(strong)>", "").Split('>');
            //var result = temArray[temArray.Length - 1];
            var result = Regex.Replace(matchCollection[0].Value, @"<li>|</li>|本站主数据：", "");
            return result;
        }

        private static string GetResponseHtmlByUrl(string url)
        {
            try
            {
              return  GetHtml(url, Encoding.GetEncoding(GetEncoding(url)));
            }
            catch (Exception ex)
            {
                log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType).Error(string.Format("获取指定地址({0})的html发生异常：{1}", url, ex.Message));
                return "";
            }
        }

        private static string GetEncoding(string url)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 20000;
                request.AllowAutoRedirect = false;

                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK && response.ContentLength < 1024 * 1024)
                {
                    if (response.ContentEncoding != null && response.ContentEncoding.Equals("gzip", StringComparison.InvariantCultureIgnoreCase))
                        reader = new StreamReader(new GZipStream(response.GetResponseStream(), CompressionMode.Decompress));
                    else
                        reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII);

                    string html = reader.ReadToEnd();

                    Regex reg_charset = new Regex(@"charset\b\s*=\s*(?<charset>[^""]*)");
                    if (reg_charset.IsMatch(html))
                    {
                        return reg_charset.Match(html).Groups["charset"].Value;
                    }
                    else if (response.CharacterSet != string.Empty)
                    {
                        return response.CharacterSet;
                    }
                    else
                        return Encoding.Default.BodyName;
                }
            }
            catch
            {
            }
            finally
            {

                if (response != null)
                {
                    response.Close();
                    response = null;
                }
                if (reader != null)
                    reader.Close();

                if (request != null)
                    request = null;

            }

            return Encoding.Default.BodyName;
        }

        /// <summary> 
        /// 获取源代码 
        /// </summary> 
        /// <param name="url"></param> 
        /// <returns></returns> 
        private static string GetHtml(string url, Encoding encoding)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 20000;
                request.AllowAutoRedirect = false;

                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK && response.ContentLength < 1024 * 1024)
                {
                    if (response.ContentEncoding != null && response.ContentEncoding.Equals("gzip", StringComparison.InvariantCultureIgnoreCase))
                        reader = new StreamReader(new GZipStream(response.GetResponseStream(), CompressionMode.Decompress), encoding);
                    else
                        reader = new StreamReader(response.GetResponseStream(), encoding);
                    string html = reader.ReadToEnd();

                    return html;
                }
            }
            catch
            {
            }
            finally
            {

                if (response != null)
                {
                    response.Close();
                    response = null;
                }
                if (reader != null)
                    reader.Close();

                if (request != null)
                    request = null;

            }

            return string.Empty;
        }
    }

}
