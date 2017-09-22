using System;
using System.IO;
using System.Net;
using System.Text;

namespace MONO.Orders.Tools
{
    public class HttpWebRequestTools
    {
        public static string GetRequestByHttpWeb(string url)
        {
            try
            {
                HttpWebRequest http;
                HttpWebResponse response;
                http = WebRequest.Create(url) as HttpWebRequest;
                http.Method = "POST";
                http.ContentType = "application/json;charset=UTF-8";
                using (response = (HttpWebResponse)http.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        string josn = reader.ReadToEnd();
                        http.Abort();
                        return josn;
                    }
                }
            }
            catch (Exception ex)
            {

                return "";
            }
        }


        public static string GetRequestByHttpWebDefault(string url)
        {
            try
            {
                HttpWebRequest http;
                HttpWebResponse response;
                http = WebRequest.Create(url) as HttpWebRequest;
                using (response = (HttpWebResponse)http.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        string josn = reader.ReadToEnd();
                        http.Abort();
                        return josn;
                    }
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }


        public static string JTHttpPost(string url, string param, string sign, string token = "")
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Headers["sign"] = sign;
            request.Headers["token"] = token;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.Timeout = 60000;
            request.AllowAutoRedirect = false;

            StreamWriter requestStream = null;
            WebResponse response = null;
            string responseStr = null;
            try
            {
                requestStream = new StreamWriter(request.GetRequestStream());
                requestStream.Write(param);
                requestStream.Close();
                response = request.GetResponse();
                if (response != null)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    responseStr = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                request = null;
                requestStream = null;
                response = null;
            }

            return responseStr;
        }
    }
}
