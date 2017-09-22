using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using FlowOrderConsole.MappingModels;
using FlowOrderConsole.Models;
using FlowOrderConsole.Tools;
using FlowOrderConsole.Tools.RequestUrl;
using log4net.Util;

namespace FlowOrderConsole.FlowAgents
{
    public class CT023_ARequest : AgentBase
    {
        public CT023_ARequest()
        {
            App = ChannelInfoModels.Ct023All.UserKey;
            AppSec = ChannelInfoModels.Ct023All.UserSec;
            RequestUrl = string.IsNullOrEmpty(ChannelInfoModels.Ct023All.Url) ? "https://llhb.online.cq.cn:8081/uniportal/sponsor/recharge_rechargevolume.action?" : ChannelInfoModels.Ct023All.Url;
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
