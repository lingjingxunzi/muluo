using System.Collections.Generic;
using MONO.Distribution.Model.AlipayViewModel;

namespace MONO.Distribution.Alipay
{
    public class AlipayHelper
    {
        public static string AlipayOrder(AlipayParamModels model)
        {
            //支付类型
            string payment_type = "1";
            //必填，不能修改
            //服务器异步通知页面路径
            string notify_url = "http://113.207.124.164/AlipayCallBack/RechargeNotifyUrl.aspx";
            //需http://格式的完整路径，不能加?id=123这类自定义参数

            //页面跳转同步通知页面路径
            string return_url = "http://113.207.124.164/AlipayCallBack/RechargeReturnUrl.aspx";
            //需http://格式的完整路径，不能加?id=123这类自定义参数，不能写成http://localhost/



            //string body = WIDbody.Text.Trim();
            ////商品展示地址
            //string show_url = WIDshow_url.Text.Trim();
            //需以http://开头的完整路径，例如：http://www.商户网址.com/myorder.html

            //防钓鱼时间戳
            string anti_phishing_key = Submit.Query_timestamp();
            //若要使用请调用类文件submit中的query_timestamp函数

            //客户端的IP地址
            string exter_invoke_ip = "123.147.190.232";
            //非局域网的外网IP地址，如：221.0.0.1


            ////////////////////////////////////////////////////////////////////////////////////////////////

            //把请求参数打包成数组
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("partner", Config.Partner);
            sParaTemp.Add("seller_email", Config.Seller_email);
            sParaTemp.Add("_input_charset", Config.Input_charset.ToLower());
            sParaTemp.Add("service", "create_direct_pay_by_user");
            sParaTemp.Add("payment_type", payment_type);
            sParaTemp.Add("notify_url", notify_url);
            sParaTemp.Add("return_url", return_url);
            sParaTemp.Add("out_trade_no", model.OrderId);
            sParaTemp.Add("subject", model.OrderName);
            sParaTemp.Add("total_fee", model.Amount.ToString());
            //sParaTemp.Add("body", body);
            //sParaTemp.Add("show_url", show_url);
            sParaTemp.Add("anti_phishing_key", anti_phishing_key);
            sParaTemp.Add("exter_invoke_ip", exter_invoke_ip);

            //建立请求
            string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");
            return sHtmlText;

            //Response.Write(sHtmlText);
        }
    }
}
