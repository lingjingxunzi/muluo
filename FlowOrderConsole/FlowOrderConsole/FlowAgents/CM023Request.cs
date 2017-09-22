using System;
using FlowOrderConsole.Models;
using FlowOrderConsole.Tools;
using FlowOrderConsole.Tools.RequestUrl;

namespace FlowOrderConsole.FlowAgents
{
    public class CM023Request : AgentBase
    {
        public CM023Request()
        {
            App = "2308142192340";
            AppSec = "3c4c2ef43f1a42d6b82a1a1dbdcc9e58";
            RequestUrl = "http://183.230.97.113/cq-web/open/ChargeFlow";
        }
        public override string AgentRequest(AgentParamBase agentParamBase)
        {
            time = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            var signStr = GetSignStr(agentParamBase, time.ToString());
            var signbefore = signStr + AppSec;
            var sign = CarrierCharManipulation.GetMd5(32, signbefore).ToLower();
            var param = "<?xml version='1.0' encoding='utf-8' ?>"
                + "<AdvPay><PubInfo><Version>1</Version>"
                + "<EnterpriseCode>" + App + "</EnterpriseCode>"
                + "<VerifyCode>" + sign + "</VerifyCode>"
                + "</PubInfo>" + signStr + "</AdvPay>";
            BaseCode.WriteLog("CM_023请求参数：" + param);
            var result = HttpWebRequestTools.RequestToCM023(RequestUrl, param, time.ToString());
            return result;
        }



        private static string GetSignStr(AgentParamBase agentParamBase, string time)
        {
            return "<BusiData>"
                   + "<CreateTime>" + time + "</CreateTime>"
                   + "<ChargePhoneNum>" + agentParamBase.MobilePhone + "</ChargePhoneNum>"
                   + "<ProductCode>" + agentParamBase.ProductId + "</ProductCode>"
                   + "<ChargeNum>1</ChargeNum>"
                   + "</BusiData>";
        }

        public long time;


        public override string GetResultStr(string str)
        {
            var cm023result = new CM023ResultModel();
            if (!string.IsNullOrEmpty(str))
            {
                try
                {
                    cm023result.InitInstance(str);
                }
                catch (Exception ex)
                {
                    BaseCode.WriteLog("CM023Request->GetResultStr:" + ex.ToString() + "str:" + str);
                }
            }
            else
            {
                BaseCode.WriteLog("CM023Request->GetResultStr: str为空:");
                return "{\"ReturnCode\":\"\",\"ReturnMsg\":\"\"}";
            }
            return "{\"ReturnCode\":\"" + cm023result.ReturnCode + "\",\"ReturnMsg\":\"" + cm023result.ReturnMsg + "\",\"OrderId\":\"" + time + "\"}";
        }
    }
}
