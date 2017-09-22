using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using FlowOrderConsole.Models;
using FlowOrderConsole.Tools;
using FlowOrderConsole.Tools.RequestUrl;

namespace FlowOrderConsole.FlowAgents
{
    public class AggregationRequest : AgentBase
    {
        public AggregationRequest()
        {
            App = "QXCX";
            AppSec = "JK-QXCX";
            RequestUrl = "http://juhe.17erp.cn:8884/GatewayAPI/GatewayOrderHandler.ashx";
        }
        public override string AgentRequest(AgentParamBase agentParamBase)
        {
            var echo = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            var time = DateTime.Now.ToString("yyyyMMddHHmmss");
            var sign = GetSignStr(agentParamBase, echo, time);
            var param = GetParamStr(agentParamBase, echo, time, sign);
            var josn = HttpWebRequestTools.AggregationRequest(RequestUrl, param);
            return josn;
        }

        private string GetSignStr(AgentParamBase agentParamBase, string echo, string time)
        {
            var md5Str = App + agentParamBase.HistoriesKey + AppSec + echo + time;
            var md5Result = CarrierCharManipulation.GetAbstractByMd5(md5Str);
            return Convert.ToBase64String(md5Result);
        }

        private string GetParamStr(AgentParamBase agentParamBase, string echo, string time, string sign)
        {
            return "<request><head><custInteId>" + App + "</custInteId>"
        + "<echo>" + echo + "</echo><orderId>" + agentParamBase.HistoriesKey + "</orderId>"
        + "<timestamp>" + time + "</timestamp><orderType>1</orderType>"
        + "<version>1</version><chargeSign>" + sign + "</chargeSign>"
        + "</head><body><item><packCode>" + agentParamBase.ProductId + "</packCode><mobile>" + agentParamBase.MobilePhone + "</mobile>"
        + "<effectType>1</effectType></item></body></request>";
        }

        public override string GetResultStr(string str)
        {
            var result = "";
            var desc = "";
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(str);
            var selectSingleNode = xmlDoc.SelectSingleNode("//response");
            if (selectSingleNode != null)
            {
                XmlNodeList xn0 = selectSingleNode.ChildNodes;
                foreach (XmlNode node in xn0)
                {
                    if (node.Name == "result")
                    {
                        result = node.InnerText;
                    }
                    if (node.Name == "desc")
                    {
                        desc = node.InnerText;
                    }
                }
            }
            if (result.Equals("0000"))
                return "{\"Result\":\"已提交\",\"Code\":\"0001\"}";
            return "{\"Result\":\"" + desc + "\",\"Code\":\"" + result + "\"}";
        }
    }
}
