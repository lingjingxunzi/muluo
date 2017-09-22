using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using FlowOrderConsole.Models;
using FlowOrderConsole.Tools;
using FlowOrderConsole.Tools.RequestUrl;

namespace FlowOrderConsole.FlowAgents
{
    public class CM028Request: AgentBase
    {
        public CM028Request()
        {
            App = "f164530c6b9d4905bf51e3310262c34e";
            AppSec = "60bd295daa934f64afd30a5b15c1ca81";
            RequestUrl = "https://sc.4ggogo.com/web-in/boss/charge.html";
        }
        public override string AgentRequest(AgentParamBase agentParamBase)
        {
            GetToken();
            if (string.IsNullOrEmpty(Token)) return "";
            var param = "<Request>"
  + "<Datetime>" + time + "</Datetime>"
  + "<ChargeData><Mobile >" + agentParamBase.MobilePhone + "</Mobile>"
      + "<ProductId >" + agentParamBase.ProductId + "</ProductId >"
      + "<SerialNum>" + agentParamBase.HistoriesKey + "</SerialNum>"
  + "</ChargeData></Request>";
            var sign = CarrierCharManipulation.SHA256(param + AppSec);
            BaseCode.WriteLog(sign);
            BaseCode.WriteLog(param);
            var result = HttpWebRequestTools.CM023NewHttpPost(RequestUrl, param, Token, sign);
            return result;
        }

        private string GetToken()
        {
            try
            {
                BaseCode.WriteLog("GetToken:");
                time = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fff") + "+08:00";
                var authUrl = "https://sc.4ggogo.com/web-in/auth.html";
                var sign = CarrierCharManipulation.SHA256(App + time + AppSec);
                var paramStr = "<Request>"
                    + "<Datetime>" + time + "</Datetime>"
                    + "<Authorization><AppKey>" + App + "</AppKey>"
                    + "<Sign>" + sign + "</Sign>"
                    + "</Authorization></Request>";
                BaseCode.WriteLog(paramStr);
                BaseCode.WriteLog(authUrl);
                var authJson = HttpWebRequestTools.CM023NewAuthHttpPost(authUrl, paramStr);
                InitToken(authJson);
                BaseCode.WriteLog(Token);
                return Token;
            }
            catch (Exception ex)
            {
                BaseCode.WriteLog(ex.ToString());
            }
            return "";
        }

        public override string GetResultStr(string str)
        {
            BaseCode.WriteLog("解析字符串：" + str);
            if (string.IsNullOrEmpty(str)) return "{\"Result\":\"提交失败\",\"Code\":\"-1\",\"SerialNum\":\"0\",\"SystemNum\":\"0\"}";
            return InitResult(str);
        }

        public string InitResult(string str)
        {
            var serialNum = "";
            var systemNum = "";
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(str);
            var selectSingleNode = xmlDoc.SelectSingleNode("//Response//ChargeData");
            if (selectSingleNode != null)
            {
                XmlNodeList xn0 = selectSingleNode.ChildNodes;
                foreach (XmlNode node in xn0)
                {
                    if (node.Name == "SerialNum")
                    {
                        serialNum = node.InnerText;
                    }
                    if (node.Name == "SystemNum")
                    {
                        systemNum = node.InnerText;
                    }
                }
            }
            return "{\"Result\":\"已提交\",\"Code\":\"0001\",\"SerialNum\":\"" + serialNum + "\",\"SystemNum\":\"" + systemNum + "\"}";
        }



        public void InitToken(string str)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(str);
            var selectSingleNode = xmlDoc.SelectSingleNode("//Response//Authorization");

            if (selectSingleNode != null)
            {
                XmlNodeList xn0 = selectSingleNode.ChildNodes;

                foreach (XmlNode node in xn0)
                {
                    if (node.Name == "Token")
                    {
                        this.Token = node.InnerText;
                    }
                }
            }
        }

        public string Token;
        public string time;
    }
}
