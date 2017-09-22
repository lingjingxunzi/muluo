
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using MONO.Order.Test.Models;
using MONO.Order.Test.Tools;

namespace MONO.Order.Test.FlowAgents
{
    /// <summary>
    /// 江苏移动
    /// </summary>
    public class CM025Request : AgentBase
    {
        public CM025Request()
        {
            App = "khdyt";
            AppSec = "fa8f718ce5924170b74e858d05181e6f";
            RequestUrl = "http://221.178.130.157:8083/api.aspx";
        }
        public override string AgentRequest(AgentParamBase agentParamBase)
        {
            InitParamInfo(agentParamBase);
            var sigStr = GetSignStr();
            var sign = CarrierCharManipulation.GetMd5(32, sigStr);
            var url = RequestUrl + "?Action=" + _param["Action"] + "&V=" + _param["V"] + "&Range=" + _param["Range"] + "&OutTradeNo=" + _param["OutTradeNo"] +
                      "&Account=" + _param["Account"] + "&Mobile=" + _param["Mobile"] + "&Package=" + _param["Package"] + "&Sign=" + sign;
            var result = HttpWebRequestTools.GetRequestByHttpWebDefault(url);
            return result;
        }


        public void InitParamInfo(AgentParamBase agentParamBase)
        {
            _param.Add("Action", "charge");
            _param.Add("V", "1.1");
            _param.Add("Range", "0");
            _param.Add("OutTradeNo", agentParamBase.HistoriesKey);
            _param.Add("Account", App);
            _param.Add("Mobile", agentParamBase.MobilePhone);
            _param.Add("Package", agentParamBase.ProductId);
        }


        public string GetSignStr()
        {
            return "account=" + _param["Account"] + "&mobile=" + _param["Mobile"] + "&package=" + _param["Package"] + "&key=" + AppSec;
        }

        private IDictionary<string, string> _param = new Dictionary<string, string>();

        public override string GetResultStr(string str)
        {
            return str;
        }
    }
}
