using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using log4net;

namespace FlowOrderConsole.Tools.RequestUrl
{
    public class HttpWebRequestTools
    {
        static ILog httpLogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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

        /// <summary>
        /// 讯众请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="jsonData"></param>
        /// <param name="authorization"></param>
        /// <returns></returns>
        public static string SendRequest(string url, string jsonData, string authorization)
        {
            //、将参数转化为assic码
            byte[] postBytes = Encoding.UTF8.GetBytes(jsonData);
            HttpWebRequest caaSRequest = null;
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            //初始化新的webRequst
            caaSRequest = (HttpWebRequest)WebRequest.Create(url);
            caaSRequest.Method = "POST";
            caaSRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            string AuthorizationCode = authorization;
            caaSRequest.Headers.Set("Authorization", AuthorizationCode);
            caaSRequest.ContentLength = postBytes.Length;
            using (Stream reqStream = caaSRequest.GetRequestStream())
            {
                reqStream.Write(postBytes, 0, postBytes.Length);
                reqStream.Close();
            }
            string content = "";
            Stream resStream = null;
            try
            {
                HttpWebResponse caaSResponse = (HttpWebResponse)caaSRequest.GetResponse();
                resStream = caaSResponse.GetResponseStream();
                using (StreamReader sr = new StreamReader(resStream))
                {
                    content = sr.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse wr = (WebResponse)ex.Response;
                resStream = wr.GetResponseStream();
                using (StreamReader sr = new StreamReader(resStream))
                {
                    content = sr.ReadToEnd();
                }
            }
            return content;
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受     
        }


        public static string AggregationRequest(string Url, string param)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Url);
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

        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static string Base64EnCode(string Message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(Message);
            return Convert.ToBase64String(bytes);
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

        public static string CM023NewHttpPost(string url, string param, string token, string Signature = "")
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Headers["4GGOGO-Auth-Token"] = token;
            request.Headers["HTTP-X-4GGOGO-Signature"] = Signature;
            request.Method = "POST";
            request.ContentType = "application/xml";
            request.Accept = "*/*";
            request.Timeout = 60000;
            request.AllowAutoRedirect = false;
            request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
            StreamWriter requestStream = null;
            WebResponse response = null;
            string responseStr = null;
            try
            {
                requestStream = new StreamWriter(request.GetRequestStream());
                requestStream.Write(param);
                requestStream.Close();
                //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                response = request.GetResponse();
                if (response != null)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    responseStr = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                BaseCode.WriteLog(ex.Message);
                return "";
            }
            finally
            {
                request = null;
                requestStream = null;
                response = null;
            }

            return responseStr;
        }


        public static string CM023NewAuthHttpPost(string url, string param)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/xml";
            request.Accept = "*/*";
            request.Timeout = 60000;
            request.AllowAutoRedirect = false;
            request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
            //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            StreamWriter requestStream = null;
            WebResponse response = null;
            string responseStr = null;
            try
            {
                requestStream = new StreamWriter(request.GetRequestStream());

                requestStream.Write(param);
                requestStream.Close();
                
                try
                {
                    var type = (SecurityProtocolType)3072;
                    ServicePointManager.SecurityProtocol = type;
                    httpLogMsg.Info(type);
                    ServicePointManager.SecurityProtocol = new SecurityProtocolType();

                }
                catch (Exception ex1)
                {
                    httpLogMsg.Info(ex1);
                }
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                httpLogMsg.Info("SecurityProtocol:" + ServicePointManager.SecurityProtocol);
                response = request.GetResponse();
                if (response != null)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    responseStr = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                httpLogMsg.Info(ex);
                BaseCode.WriteLog(ex.ToString());
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

        public static string CM023NewAuthHttpPost0915(string url, string param)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/xml";
            request.Accept = "*/*";
            request.Timeout = 60000;
            request.AllowAutoRedirect = false;
            request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
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
            catch (Exception ex)
            {
                httpLogMsg.Info(ex);
                BaseCode.WriteLog(ex.ToString());
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
            request.Timeout = 100000;
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
        public static string RequestToCM023(string serverUrl, string postData, string time)
        {
            var dataArray = Encoding.UTF8.GetBytes(postData);
            //创建请求  
            var request = (HttpWebRequest)HttpWebRequest.Create(serverUrl);
            request.Method = "POST";
            request.ContentLength = dataArray.Length;
            //设置上传服务的数据格式  
            request.ContentType = "text/plain";
            //请求的身份验证信息为默认  
            request.Credentials = CredentialCache.DefaultCredentials;
            //请求超时时间  
            request.Timeout = 100000;
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
                BaseCode.WriteLog("请求超时，订单号：" + time);
                var app = "2308142192340";
                var appSec = "3c4c2ef43f1a42d6b82a1a1dbdcc9e58";
                var requestUrl = "http://183.230.97.113/cq-web/open/ChargeRecord";
                var signStr = GetQuerySignStr(time);
                var signbefore = signStr + appSec;
                var sign = CarrierCharManipulation.GetMd5(32, signbefore).ToLower();
                var param = "<?xml version='1.0' encoding='utf-8' ?>"
                    + "<AdvPay><PubInfo><Version>1</Version>"
                    + "<EnterpriseCode>" + app + "</EnterpriseCode>"
                    + "<VerifyCode>" + sign + "</VerifyCode>"
                    + "</PubInfo>" + signStr + "</AdvPay>";
                return CM023Query(requestUrl, param);
            }
            return res;
        }


        public static string RequestToCM023_02(string serverUrl, string postData, string time)
        {
            var dataArray = Encoding.UTF8.GetBytes(postData);
            //创建请求  
            var request = (HttpWebRequest)HttpWebRequest.Create(serverUrl);
            request.Method = "POST";
            request.ContentLength = dataArray.Length;
            //设置上传服务的数据格式  
            request.ContentType = "text/plain";
            //请求的身份验证信息为默认  
            request.Credentials = CredentialCache.DefaultCredentials;
            //请求超时时间  
            request.Timeout = 100000;
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
                BaseCode.WriteLog("请求超时，订单号：" + time);
                var app = "2308148751936";
                var appSec = "9f5e7478bb054f6399d33d5d046e45ac";
                var requestUrl = "http://183.230.97.113/cq-web/open/ChargeRecord";
                var signStr = GetQuerySignStr(time);
                var signbefore = signStr + appSec;
                var sign = CarrierCharManipulation.GetMd5(32, signbefore).ToLower();
                var param = "<?xml version='1.0' encoding='utf-8' ?>"
                    + "<AdvPay><PubInfo><Version>1</Version>"
                    + "<EnterpriseCode>" + app + "</EnterpriseCode>"
                    + "<VerifyCode>" + sign + "</VerifyCode>"
                    + "</PubInfo>" + signStr + "</AdvPay>";
                return CM023Query(requestUrl, param);
            }
            return res;
        }

        public static string RequestToCM023_03(string serverUrl, string postData, string time)
        {
            var dataArray = Encoding.UTF8.GetBytes(postData);
            //创建请求  
            var request = (HttpWebRequest)HttpWebRequest.Create(serverUrl);
            request.Method = "POST";
            request.ContentLength = dataArray.Length;
            //设置上传服务的数据格式  
            request.ContentType = "text/plain";
            //请求的身份验证信息为默认  
            request.Credentials = CredentialCache.DefaultCredentials;
            //请求超时时间  
            request.Timeout = 100000;
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
                BaseCode.WriteLog("请求超时，订单号：" + time);
                var app = "2308146526317";
                var appSec = "a3b8fd8ba4864ea9a67442cd3e4bc851";
                var requestUrl = "http://183.230.97.113/cq-web/open/ChargeRecord";
                var signStr = GetQuerySignStr(time);
                var signbefore = signStr + appSec;
                var sign = CarrierCharManipulation.GetMd5(32, signbefore).ToLower();
                var param = "<?xml version='1.0' encoding='utf-8' ?>"
                    + "<AdvPay><PubInfo><Version>1</Version>"
                    + "<EnterpriseCode>" + app + "</EnterpriseCode>"
                    + "<VerifyCode>" + sign + "</VerifyCode>"
                    + "</PubInfo>" + signStr + "</AdvPay>";
                return CM023Query(requestUrl, param);
            }
            return res;
        }


        private static string CM023Query(string serverUrl, string postData)
        {
            var dataArray = Encoding.UTF8.GetBytes(postData);
            //创建请求  
            var request = (HttpWebRequest)HttpWebRequest.Create(serverUrl);
            request.Method = "POST";
            request.ContentLength = dataArray.Length;
            //设置上传服务的数据格式  
            request.ContentType = "text/plain";
            //请求的身份验证信息为默认  
            request.Credentials = CredentialCache.DefaultCredentials;
            //请求超时时间  
            request.Timeout = 100000;
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
                return res;
            }
            catch (Exception ex)
            {
                return "";
            }
        }


        private static string GetQuerySignStr(string time)
        {
            return "<BusiData>"
                   + "<CreateTime>" + time + "</CreateTime>"
                   + "</BusiData>";
        }


        public static string CU051HttpPost(string url, string param, string custId, string timestamp)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Headers["custid"] = custId;
            request.Headers["timestamp"] = timestamp;
            request.Headers["datatype"] = param;
            request.Method = "POST";
            request.ContentType = "text/plain";
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
            catch (Exception ex)
            {
                return "{\"error\":\"connectToServer\",\"error_description\":\"" + ex.Message + "\"}";//连接服务器失败  
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
