using System;
using System.IO;
using System.Net;
using System.Text;

namespace FB_FlowAgent_Test
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

        public static string HttpPostConnectToServer(string serverUrl, string postData)
        {
            var dataArray = Encoding.UTF8.GetBytes(postData);
            //创建请求  
            var request = (HttpWebRequest)HttpWebRequest.Create(serverUrl);
            request.Method = "POST";
            request.ContentLength = dataArray.Length;
            //设置上传服务的数据格式  
            request.ContentType = "application/x-www-form-urlencoded";
            //请求的身份验证信息为默认  
            request.Credentials = CredentialCache.DefaultCredentials;
            //请求超时时间  
            request.Timeout = 10000;
            //创建输入流  
            Stream dataStream;

            try
            {
                dataStream = request.GetRequestStream();
            }
            catch (Exception)
            {
                return null;//连接服务器失败  
            }
            //发送请求  
            dataStream.Write(dataArray, 0, dataArray.Length);
            dataStream.Close();
            //读取返回消息  
            string res;
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                res = reader.ReadToEnd();
                reader.Close();
            }
            catch (Exception ex)
            {
                return "{\"error\":\"connectToServer\",\"error_description\":\"" + ex.Message + "\"}";//连接服务器失败  
            }
            return res;
        }
    }
}
