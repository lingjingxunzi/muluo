using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using MONO.Orders.Models;
using MONO.Orders.Tools;


namespace MONO.Orders.FlowAgents
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
            return results;
        }


        public string GetRequestUrl(string md5str, string sign, AgentParamBase agentParamBase)
        {
            RequestUrl = RequestUrl + "productOrder" + "/t/" + agentParamBase.MobilePhone + "/b/" + agentParamBase.ProductId + "/a/" + "0" + "/y/" + App + "/p/" + md5str + "/f/" + "1" + "/m/" + sign;
            return RequestUrl;
        }

        public string GetPreSignStr(AgentParamBase agentParamBase)
        {
            return agentParamBase.MobilePhone + agentParamBase.ProductId + "111";
        }
    }
}
