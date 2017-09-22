using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using log4net;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.AgentModel;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.UI.FlowAgents
{
    public class OrderQueryTrans : AgentBase
    {
        public OrderQueryTrans()
        {
            logMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _systemUsersService = new SystemUsersService();
            _companyAccountService = new SystemAccountService();
            _resultMessage = new ResultMessage();
            _flowActiveRecordService = new FlowDistributionRecordsService();
        }

        public override IList<AgentResultBase> ValidateInfo(AgentParamBase param)
        {
            IList<AgentResultBase> agentResult = new List<AgentResultBase>();
            var result = new QueryResult();
            if (CheckEmpty((QueryOrderParam)param, result))
            {
                agentResult.Clear();
                agentResult.Add(result);
                return agentResult;
            }
            var sysUser = _systemUsersService.SelectByAccount(param.userkey);
            if (sysUser == null)
            {
                result.Result = "102";
                result.Msg = "账户信息有误";
                agentResult.Clear();
                agentResult.Add(result);
                return agentResult;
            }
            if (CheckSig((QueryOrderParam)param, result, sysUser))
            {
                agentResult.Clear();
                agentResult.Add(result);
                return agentResult;
            }
            if (CheckTimeStamp((QueryOrderParam)param, result))
            {
                agentResult.Clear();
                agentResult.Add(result);
                return agentResult;
            }

            agentResult.Add(result);
            return agentResult;
        }

        public override IList<AgentResultBase> ExecutiveOrder(AgentParamBase param)
        {
            IList<AgentResultBase> agentResult = new List<AgentResultBase>();
            try
            {
                var result = new QueryResult { Result = "0", Msg = "成功", OrderId = ((QueryOrderParam)param).OrderId };
                var record = _flowActiveRecordService.SelectTransIdIsExistsCount(param.GetOrderId());
                if (record.Count > 0)
                {
                    foreach (var items in record)
                    {
                        var results = new QueryResult { Result = "0", Msg = "成功", OrderId = ((QueryOrderParam)param).OrderId };
                        results.Msg = items.ResultMsg;
                        results.Result = items.OrderStatus;
                        agentResult.Add(results);
                    }
                }
                else
                {
                    result.Msg = "未找到对应流水号订单";
                    result.Result = "120";
                    agentResult.Add(result);
                }
            }
            catch (Exception ex)
            {
                var resu = new QueryResult { Msg = "异常" };
                resu.Msg = "908";
                resu.OrderId = ((QueryOrderParam)param).OrderId;
                agentResult.Add(resu);
                logMsg.Error(ex.Message);
            }
            return agentResult;
        }


        


        private bool CheckSig(QueryOrderParam param, QueryResult result, SystemUsers sysUser)
        {
            var sigStr = sysUser.PWD + "||" + param.name + "||" + param.userkey + "||" + param.OrderId + "||" + param.timestamp +
                         "||" + sysUser.PWD;
            var sigParent = SHA1(sigStr);
            var sig = sigParent.Substring(4, sigParent.Length - 8);
            if (!sig.Equals(param.sig))
            {
                result.Result = "103";
                result.Msg = "sig校验失败";
                return true;
            }
            return false;
        }

        private bool CheckEmpty(QueryOrderParam param, QueryResult result)
        {
            var variable = new CheckPageVariable();
            variable
                .CheckInputValueIsEmpty(param.userkey)
                .CheckInputValueIsEmpty(param.sig)
                .CheckInputValueIsEmpty(param.name)
                .CheckInputValueIsEmpty(param.timestamp);
            _resultMessage = variable.GetResultMessage();
            if (!_resultMessage.IsOk)
            {
                result.Msg = "参数错误";
                result.Result = "101";
                return true;
            }
            return false;
        }

        private bool CheckTimeStamp(QueryOrderParam param, QueryResult result)
        {
            var timespan = DateTime.Now - DateTime.ParseExact(param.timestamp, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture); ;
            if (timespan.TotalSeconds >= 180)
            {
                result.Result = "104";
                result.Msg = "已超时";
                return true;
            }
            return false;
        }

        private ISystemUsersService _systemUsersService;
        private ISystemAccountService _companyAccountService;
        private ResultMessage _resultMessage;
        private IFlowDistributionRecordsService _flowActiveRecordService;
    }
}