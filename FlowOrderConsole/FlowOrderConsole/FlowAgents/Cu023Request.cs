using FlowOrderConsole.Models;
using FlowOrderConsole.Tools;
using FlowOrderConsole.Tools.RequestUrl;

namespace FlowOrderConsole.FlowAgents
{
    public class Cu023Request : AgentBase
    {
        public Cu023Request()
        {
            RequestUrl = "http://123.147.190.200:8989/tmsOrder/";
            App = "HX0013";
            AppSec = "12345678";
        }
        public override string AgentRequest(AgentParamBase agentParamBase)
        {
            var requestUrl = GetRequestUrl(CarrierCharManipulation.CU023Encode(AppSec),
                                            CarrierCharManipulation.CU023Encode(GetPreSignStr(agentParamBase)), agentParamBase);
            var results = HttpWebRequestTools.GetRequestByHttpWebDefault(requestUrl);
           BaseCode.WriteLog("重庆联通请求返回："+results);
            return results;
        }


        public string GetRequestUrl(string md5str, string sign, AgentParamBase agentParamBase)
        {
            return RequestUrl + "productOrder" + "/t/" + agentParamBase.MobilePhone + "/b/" + agentParamBase.ProductId + "/a/" + "0" + "/y/" + App + "/p/" + md5str + "/f/" + "1" + "/m/" + sign;
        }

        public string GetPreSignStr(AgentParamBase agentParamBase)
        {
            return agentParamBase.MobilePhone + agentParamBase.ProductId + "111";
        }

        public override string GetResultStr(string str)
        {
            return str;
        }
    }
}
