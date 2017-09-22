using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using FlowOrderConsole.Models;
using FlowOrderConsole.Tools;
using FlowOrderConsole.Tools.RequestUrl;

namespace FlowOrderConsole.FlowAgents
{
    public class XZWholeCMRequest : AgentBase
    {

        public XZWholeCMRequest()
        {
            App = "7cbcd10aade94b048d3ac7b27e12e9db";
            AppSec = "b1e19ef7ef5b466e9e0310a590dd1173";
            RequestUrl = "http://api.ytx.net";
        }
        public override string AgentRequest(AgentParamBase agentParamBase)
        {
            var time = DateTime.Now.ToString("yyyyMMddHHmmss");
            var param = GetParams(agentParamBase);
            var auto = HttpWebRequestTools.Base64EnCode(App + "|" + time);
            var sign = CarrierCharManipulation.GetMd5(32, App + AppSec + time);
            var url = RequestUrl + "/201612/sid/" + App + "/traffic/Traffic.wx?Sign=" + sign;
            var result = HttpWebRequestTools.SendRequest(url, param, auto);
            return result;
        }

        private string GetParams(AgentParamBase agentParamBase)
        {
            var data = "{\"action\":\"flowOrder\",\"phone\":\"" + agentParamBase.MobilePhone + "\",\"flowCode\":\"" + agentParamBase.ProductId + "\","
+ "\"appid\":\"" + AppID + "\",\"customParm\":\"" + agentParamBase.HistoriesKey + "\"}";
            return data;
        }

        public override string GetResultStr(string str)
        {
            return str;
        }

        public string AppID = "467e7f90d5514b2cb2e33431948bb1de";
    }
}
