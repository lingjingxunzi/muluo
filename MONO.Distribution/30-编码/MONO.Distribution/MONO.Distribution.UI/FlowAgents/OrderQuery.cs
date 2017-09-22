using System;
using System.Collections.Generic;
using System.Reflection;
using log4net;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.AgentModel;
using MONO.Distribution.Model.FlowAgentViewModels;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.UI.FlowAgents
{
    public class OrderQuery : AgentBase
    {
        public OrderQuery()
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
            //if (CheckIpBind(param.userkey))
            //{
            //    result.Result = "113";
            //    result.Msg = "IP地址鉴权失败";
            //    agentResult.Clear();
            //    agentResult.Add(result);
            //    return agentResult;
            //}
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
            if (CheckOrderExists((QueryOrderParam)param, result))
            {

            }
            agentResult.Add(result);
            return agentResult;
        }

        private bool CheckOrderExists(QueryOrderParam queryOrderParam, QueryResult result)
        {
            var record = _flowActiveRecordService.FindById(queryOrderParam.OrderId);
            if (record == null)
            {
                result.OrderId = queryOrderParam.OrderId;
                result.Result = "112";
                result.Msg = "订单号不存在";
                return true;
            }
            return false;
        }

        public override IList<AgentResultBase> ExecutiveOrder(AgentParamBase param)
        {
            IList<AgentResultBase> agentResult = new List<AgentResultBase>();
            try
            {
                var result = new QueryResult { Result = "0", Msg = "成功", OrderId = ((QueryOrderParam)param).OrderId };
                var record = _flowActiveRecordService.FindById(((QueryOrderParam)param).OrderId);
                result.Msg = record.ResultMsg;
                result.Result = record.OrderStatus;
                agentResult.Add(result);
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