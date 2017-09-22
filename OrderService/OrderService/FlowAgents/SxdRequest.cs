using System;
using System.IO;
using System.Net;
using System.Text;
using OrderService.Models;
using OrderService.Tools;

namespace OrderService.FlowAgents
{
    public class SxdRequest : AgentBase
    {
        public SxdRequest()
        {
            App = "110032";
            AppSec = "cqmn!@#$";
            RequestUrl = "http://123.57.36.148:10000/sxd-api-unit/api/order";
        }
        public override string AgentRequest(AgentParamBase agentParamBase)
        {
            var url_parm = GetUrlParamStr(agentParamBase.MobilePhone, agentParamBase.ProductId, agentParamBase.HistoriesKey, agentParamBase.BackUrl);
            var desUrlParm = CarrierCharManipulation.Encrypt(url_parm, AppSec);
            var timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            var signStr = GetMd5Str(agentParamBase.MobilePhone, timeStamp, agentParamBase.ProductId);
            var sig = CarrierCharManipulation.GetStrByMd5(signStr).ToLower();
            var urlPath = RequestUrl + "?sell_id=" + App + "&url_parm=" + desUrlParm + "&time_stamp=" + timeStamp + "&sig=" + sig + "&flow_specifica=" + GetSpecificaStr(agentParamBase) + "&receiver=" + agentParamBase.MobilePhone;

            HttpWebRequest http;
            HttpWebResponse response;
            http = WebRequest.Create(urlPath) as HttpWebRequest;
            http.Method = "POST";
            http.ContentType = "application/json;charset=UTF-8";
            using (response = (HttpWebResponse)http.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    string josn = reader.ReadToEnd();
                    return josn;
                }
            }
        }


        private string GetSpecificaStr(AgentParamBase agentParamBase)
        {
            if (agentParamBase.PakgeSize % 1024 == 0)
            {
                return (agentParamBase.PakgeSize / 1024 * 1000).ToString().PadLeft(6, '0');
            }
            return agentParamBase.PakgeSize.ToString().PadLeft(6, '0');
        }


        private string GetUrlParamStr(string mobile, string produceid, string TransNo, string backurl)
        {
            var url = "mobile=" + mobile + "&productId=" + produceid + "&notifyUrl=" + backurl + "&passParm=" + TransNo;

            return url;
        }

        private string GetMd5Str(string mobile, string TimeStamp, string productId)
        {

            return mobile + "||" + App + "||" + TimeStamp + "||" + productId + "||" + AppSec;
        }
    }
}
