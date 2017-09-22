using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowOrderConsole.MappingModels;
using FlowOrderConsole.Models;
using FlowOrderConsole.Tools;
using FlowOrderConsole.Tools.RequestUrl;

namespace FlowOrderConsole.FlowAgents
{
    public class CT023_PRequest : AgentBase
    {
        public CT023_PRequest()
        {
            App = ChannelInfoModels.Ct023Pro.UserKey;
            AppSec = ChannelInfoModels.Ct023Pro.UserSec;
            RequestUrl = string.IsNullOrEmpty(ChannelInfoModels.Ct023Pro.Url) ? "https://llhb.online.cq.cn:8081/uniportal/sponsor/recharge_rechargevolume.action?" : ChannelInfoModels.Ct023Pro.Url;
        }
        public override string AgentRequest(AgentParamBase agentParamBase)
        {
            var transId = DateTime.Now.ToString("yyyyMMddHHmmss") + agentParamBase.MobilePhone.Substring(7, 4);
            var signStr = "appid=" + App + "appkey=" + AppSec + "clienttype=1contractid=" + ChannelInfoModels.Ct023All.Contract + "producttype=" + ChannelInfoModels.Ct023All.ProductType + "transactionid=" + transId + "usernum=" + agentParamBase.MobilePhone + "volume=" + agentParamBase.ProductId; ;
            var sign = CarrierCharManipulation.GetMd5(32, signStr).ToLower();
            var urlParam = "appid=" + App + "&clienttype=1&contractid=" + ChannelInfoModels.Ct023All.Contract + "&producttype=" + ChannelInfoModels.Ct023All.ProductType + "&transactionid=" + transId + "&usernum=" + agentParamBase.MobilePhone + "&volume=" + agentParamBase.ProductId + "&sign=" + sign;
            var url = RequestUrl + urlParam;
            var result = HttpWebRequestTools.GetRequestByHttpWebDefault(url);
            result = result.Replace("}", " ") + ",\"transId\":\"" + transId + "\" ,\"FlowDisKey\":\"" + agentParamBase.HistoriesKey + "\"}";
            return result;
        }

        public override string GetResultStr(string str)
        {
            return str;
        }
    }
}
