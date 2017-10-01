using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowOrderConsole.Models;
using FlowOrderConsole.Tools;
using FlowOrderConsole.Tools.RequestUrl;

namespace FlowOrderConsole.FlowAgents
{
    public class CT023DiffRequest : AgentBase
    {
        public CT023DiffRequest()
        {
            App = "104346228";
            AppSec = "3c4c2ef43f1a42d6b82a1a1dbdcc9e58";
            RequestUrl = "http://api.800.21cn.com/fps/flowService.do";
        }
        public override string AgentRequest(Models.AgentParamBase agentParamBase)
        {
            SetModelInfo(agentParamBase);
            var signStr = "{\"request_no\":\"" + model.request_no + "\",\"service_code\":\"" + model.service_code
               + "\",\"contract_id\":\"" + model.contract_id + "\",\"activity_id\":\"" + model.activity_id + "\",\"order_type\":\""
               + model.order_type + "\",\"phone_id\":\"" + model.phone_id + "\",\"plat_offer_id\":\"" + model.plat_offer_id
               + "\",\"effect_type\":\"" + model.effect_type + "\"}";
            var sign = CarrierCharManipulation.encodeBytesForCqCT(signStr, secreKey, vector);
            var requestParam = "{\"partner_no\":\"" + partner_no + "\",\"code\":\"" + sign + "\"}";
            var result = HttpWebRequestTools.PostForCT023(RequestUrl, requestParam);
            return result.Substring(0, result.Length - 1) + ",\"HistoryKey\":\"" + agentParamBase.HistoriesKey + "\"}";
        }

        private void SetModelInfo(Models.AgentParamBase agentParamBase)
        {
            model = new CT023RequestModel();
            model.activity_id = "106042";//活动id
            model.contract_id = "102476";//合同id
            model.plat_offer_id = agentParamBase.ProductId;
            model.request_no = agentParamBase.HistoriesKey;
            model.phone_id = agentParamBase.MobilePhone;
            secreKey = "hp4qyIZK2dDSHczy";
            vector = "4627117905719104";
        }

        public override string GetResultStr(string str)
        {
            return str;
        }


        public string partner_no
        {
            get
            {
                return App;
            }
            set{}
        }


        public CT023RequestModel model;

        public string secreKey { get; set; }
        public string vector { get; set; }

    }
}
