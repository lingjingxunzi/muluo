using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.UI;
using log4net;
using MONO.Distribution.Model.AgentModel;
using MONO.Distribution.UI.FlowAgents;
using MONO.Distribution.Utility;

namespace MONO.Distribution.UI
{
    public partial class FlowAgent : Page
    {
        public FlowAgent()
        {
            LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            manager = new AgentManager();
            _agentResult = new AgentResult { Result = "000", Msg = "成功" };
            _result = new ResultMessage();
            parm = new AgentParamBase();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetQueryString();
                Response.Expires = -1;
                Response.Clear();
                Response.ContentEncoding = Encoding.UTF8;
                Response.ContentType = "application/json";
                Response.Write(GetJsonString(GetJsonData()));
                //Response.Flush();
                Response.End();
            }
        }

        protected void GetQueryString()
        {
            try
            {
                try
                {
                    LogMsg.Info(Request.Url);
                    parm = GetParam();
                    _instance = manager.GetAgentInstance(parm.name);
                    LogMsg.Info("url:" + parm.GetUrl());
                }
                catch (Exception ex)
                {
                    LogMsg.Error("GetQueryString error :" + ex.Message);
                    _agentResult.Msg = "调用方法名未注册";
                    _agentResult.Result = "111";
                }
                if (_agentResult.Result.Equals("000")) _agentResult = _instance.ValidateInfo(parm)[0];
            }
            catch (Exception ex)
            {
                LogMsg.Error("" + ex.Message);
                _agentResult.Result = "902";
                _agentResult.Msg = ex.Message;
            }
        }


        protected string GetJsonString(Object objects)
        {
            return Request["jsoncallback"] + new JavaScriptSerializer().Serialize(objects);
        }

        private AgentParamBase GetParam()
        {
            var name = GetPostGetParamer("name");
            if (string.IsNullOrEmpty(name)) return new AgentParamBase();
            switch (name.ToLower())
            {
                case "orderpkg":
                    return new ActiveFlowParam
                    {
                        sig = GetPostGetParamer("sig"),
                        userkey = GetPostGetParamer("userkey"),
                        name = GetPostGetParamer("name"),
                        timestamp = GetPostGetParamer("timestamp"),
                        phonecodestr = GetPostGetParamer("phonecodestr"),
                        CallBackUrl = GetPostGetParamer("backurl"),
                        ActiveChannel = "Inter"
                    };
                case "orderbce":
                    return new AgentParamBase
                    {
                        sig = GetPostGetParamer("sig"),
                        userkey = GetPostGetParamer("userkey"),
                        name = GetPostGetParamer("name"),
                        timestamp = GetPostGetParamer("timestamp"),
                    };
                case "orderquery":
                    return new QueryOrderParam
                    {
                        sig = GetPostGetParamer("sig"),
                        userkey = GetPostGetParamer("userkey"),
                        name = GetPostGetParamer("name"),
                        timestamp = GetPostGetParamer("timestamp"),
                        OrderId = GetPostGetParamer("orderid")
                    };
                case "orderquerytrans":
                    return new QueryOrderParam
                    {
                        sig = GetPostGetParamer("sig"),
                        userkey = GetPostGetParamer("userkey"),
                        name = GetPostGetParamer("name"),
                        timestamp = GetPostGetParamer("timestamp"),
                        OrderId = GetPostGetParamer("orderid")
                    };
                default:
                    return new AgentParamBase();
            }

        }


        public string GetPostGetParamer(string name)
        {
            return Request.Params[name];
        }
        protected object GetJsonData()
        {
            LogMsg.Error("FlowAgent:GetJsonData");
            IList<AgentResultBase> results = new List<AgentResultBase>();
            results.Add(_agentResult);
            try
            {
                try
                {
                    if (_agentResult.Result.Equals("000") || _agentResult.Result.Equals("0"))
                    {
                        var result = _instance.ExecutiveOrder(parm);
                        return result;
                    }
                    else
                    {
                        return results;
                    }
                }
                catch (Exception)
                {
                    return results;
                }
            }
            catch (Exception ex)
            {
                LogMsg.Error(ex.Message);
                return results;
            }
        }


        private AgentManager manager;
        private AgentResultBase _agentResult;
        private AgentBase _instance;
        private ResultMessage _result;
        private AgentParamBase parm;
        private ILog LogMsg;
    }
}