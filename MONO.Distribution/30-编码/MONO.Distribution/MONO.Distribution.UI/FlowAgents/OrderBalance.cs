using System;
using System.Collections.Generic;
using System.Reflection;
using log4net;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.AgentModel;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.UI.FlowAgents
{
    public class OrderBalance : AgentBase
    {
        public OrderBalance()
        {
            logMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _systemUsersService = new SystemUsersService();
            _companyAccountService = new SystemAccountService();
            _resultMessage = new ResultMessage();
        }
        public override IList<AgentResultBase> ValidateInfo(AgentParamBase param)
        {
            IList<AgentResultBase> agentResults = new List<AgentResultBase>();
            var result = new AgentBlanceResult();

            if (CheckEmpty(param, result))
            {
                agentResults.Clear();
                agentResults.Add(result);
                return agentResults;
            }
            var sysUser = _systemUsersService.SelectByAccount(param.userkey);
            if (sysUser == null)
            {
                result.Result = "102";
                result.Msg = "账户信息有误";
                agentResults.Clear();
                agentResults.Add(result);
                return agentResults;
            }
            //if (CheckIpBind(param.userkey))
            //{
            //    result.Result = "113";
            //    result.Msg = "IP地址鉴权失败";
            //    agentResults.Clear();
            //    agentResults.Add(result);
            //    return agentResults;
            //}
            if (CheckSig(param, result, sysUser))
            {
                agentResults.Clear();
                agentResults.Add(result);
                return agentResults;
            }
            if (CheckTimeStamp(param, result))
            {
                agentResults.Clear();
                agentResults.Add(result);
                return agentResults;
            }
            agentResults.Add(result);
            return agentResults;
        }

        public override IList<AgentResultBase> ExecutiveOrder(AgentParamBase param)
        {
            IList<AgentResultBase> agentResults = new List<AgentResultBase>();
            var result = new AgentBlanceResult { Msg = "成功", Result = "0", Balance = "0" };
            try
            {
                var info = _systemUsersService.SelectByAccount(param.userkey);
                if (info != null && info.SystemAccount != null)
                {
                    result.Balance = info.SystemAccount == null ? "0" : info.SystemAccount.LeftAccount.ToString();
                }
            }
            catch (Exception ex)
            {
                result.Result = "902";
                result.Msg = "内部错误";
            }
            agentResults.Add(result);
            return agentResults;
        }


        private bool CheckSig(AgentParamBase param, AgentBlanceResult result, SystemUsers sysUser)
        {
            var sigStr = sysUser.PWD + "||" + param.name + "||" + param.userkey + "||" + param.timestamp +
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

        private bool CheckEmpty(AgentParamBase param, AgentBlanceResult result)
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

        private bool CheckTimeStamp(AgentParamBase param, AgentBlanceResult result)
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
    }
}