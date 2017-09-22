using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowOrderConsole.Models;
using FlowOrderConsole.Tools;
using FlowOrderConsole.Tools.RequestUrl;

namespace FlowOrderConsole.FlowAgents
{
    public class YSRequest : AgentBase
    {
        public YSRequest()
        {
            App = "20151321";
            factoryID = "QXCX";
            AppSec = "20170517";
            RequestUrl = "http://hepay.eptok.com:9800/ysInterfaceServe/flowRateRecharge.cgi?";
        }
        public override string AgentRequest(AgentParamBase agentParamBase)
        {
            var reqDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            var termTransID = factoryID + reqDateTime;
            var userNumber = agentParamBase.MobilePhone;
            var templetID = agentParamBase.ProductId;
            var faceValue = agentParamBase.FaceValue;
            var sendfrom = "08";
            var signStr = "terminalID=" + App + "&factoryID=" + factoryID + "&reqDateTime=" + reqDateTime + "&termTransID=" + termTransID + "&userNumber=" + userNumber + "&templetID=" + templetID + "&faceValue=" + faceValue + "&sendfrom=" + sendfrom;
            var sgin = CarrierCharManipulation.GetMd5(32, signStr + "&key=" + AppSec);
            var url = RequestUrl + signStr + "&sign=" + sgin.ToLower();
            var info = HttpWebRequestTools.GetRequestByHttpWebDefault(url);
            return info;
        }

        public override string GetResultStr(string str)
        {
            return str;
        }

        public string factoryID;
    }
}
