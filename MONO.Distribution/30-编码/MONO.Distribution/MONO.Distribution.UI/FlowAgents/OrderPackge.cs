using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using log4net;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.BaseInfo;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.BLL.Interface.BaseInfo;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Common;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Model.AgentModel;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.UI.FlowAgents
{
    public class OrderPackge : AgentBase
    {
        public OrderPackge()
        {
            logMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _systemFlowPacketsService = new SystemFlowPacketsService();
            _systemUsersService = new SystemUsersService();
            _resultMessage = new ResultMessage();
            _mobileAreaService = new MobileAreaService();
            _flowBaseInfoService = new FlowBaseInfoService();
            _flowCodeService = new FlowCodeService();
            _sytSystemSettingService = new SystemSettingService();
            _flowDistributionRecordsService = new FlowDistributionRecordsService();
            _carrierMaintainRecordService = new CarrierMaintainRecordService();
            _carrierMaintainDetailService = new CarrierMaintainDetailService();
        }
        public override IList<AgentResultBase> ValidateInfo(AgentParamBase param)
        {
            logMsg.Info("ValidateInfo Start");
            IList<AgentResultBase> results = new List<AgentResultBase>();
            var result = new AgentResult { Msg = "通过", Result = "000" };
            results.Add(result);
            try
            {
                if (CheckEmpty((ActiveFlowParam)param, result))
                {
                    results.Clear();
                    results.Add(result);
                    return results;
                }
                var sysUser = _systemUsersService.SelectByAccount(param.userkey);
                logMsg.Info("ValidateInfo:" + param.userkey);
                if (sysUser == null)
                {
                    result.Result = "102";
                    result.Msg = "账户信息有误";
                    results.Clear();
                    results.Add(result);
                    return results;
                }
                if (CheckIpBind(param.userkey))
                {
                    result.Result = "113";
                    result.Msg = "IP地址鉴权失败";
                    results.Clear();
                    results.Add(result);
                    return results;
                }
                if (CheckSig((ActiveFlowParam)param, result, sysUser))
                {
                    results.Clear();
                    results.Add(result);
                    return results;
                }
                if (CheckTimeStamp((ActiveFlowParam)param, result))
                {
                    results.Clear();
                    results.Add(result);
                    return results;
                }
                if (CheckPhoneStr((ActiveFlowParam)param, result))
                {
                    results.Clear();
                    results.Add(result);
                    return results;
                }
                if (CheckPhoneLength((ActiveFlowParam)param, result))
                {
                    results.Clear();
                    results.Add(result);
                    return results;
                }
                if (CheckAccount((ActiveFlowParam)param, sysUser, result))
                {
                    results.Clear();
                    results.Add(result);
                    return results;
                }
            }
            catch (Exception ex)
            {
                logMsg.Error(ex.Message);
                result.Result = "905";
                result.Msg = "异常";
            }
            return results;
        }


        public override IList<AgentResultBase> ExecutiveOrder(AgentParamBase param)
        {
            IList<AgentResultBase> resultList = new List<AgentResultBase>();
            try
            {
                var sysUser = _systemUsersService.SelectByAccount(param.userkey);
                var mobileStr = GetMobileStr((ActiveFlowParam)param);
                logMsg.Info("sysUserkey：" + sysUser.SysUserKey);
                logMsg.Info("mobileStr:" + mobileStr);
                logMsg.Info("strTrans:" + strTrans.ToString().TrimEnd(','));
                foreach (var item in phoneCodeModels)
                {
                    var returnresult = new AgentResult { Msg = "成功", Result = "000", OrderId = "", TransNo = "" };

                    var flowInfos = _flowBaseInfoService.SelectFlowBaseInfoByFlowCode(item.Code);
                    var sysFlowList = _systemFlowPacketsService.FindAll(new SystemFlowPackets() { FlowPacketKey = flowInfos.FlowKey, SysUserKey = sysUser.SysUserKey });
                    var currentSysFlow = sysFlowList.Count > 0 ? sysFlowList.First() : new SystemFlowPackets();
                    var record = new FlowDistributionRecords
                    {
                        BatchNo = item.TransNo,
                        SysUserKey = sysUser.SysUserKey,
                        DistributionRecordKey = Guid.NewGuid().ToString(),
                        CompanyFlowPacketKey = currentSysFlow.SystemFlowPacketKey,
                        MobilePhone = item.MobilePhone,
                        DistributionType = "Orders",
                        OrderStatus = "OrderCommit",
                        BackUrl = param.GetUrl(),
                        OrderType = "Inter"
                    };
                    var flowCodeInfo = GetFlowCode(currentSysFlow.SystemFlowPacketKey, item.MobilePhone);
                    if (string.IsNullOrEmpty(flowCodeInfo.Carrier))
                    {
                        returnresult.Msg = "订购失败,未找到对应的产品编码";
                        returnresult.Result = "116";
                        returnresult.TransNo = item.TransNo;
                        resultList.Add(returnresult);
                    }
                    else
                    {
                        record.Carrier = flowCodeInfo.Carrier;
                        record.Code = flowCodeInfo.ProductCode;
                        var result = _flowDistributionRecordsService.Insert(record);
                        if (result.IsOk)
                        {
                            returnresult.Msg = "订单已提交";
                            returnresult.OrderId = record.DistributionRecordKey;
                            returnresult.TransNo = record.BatchNo;
                            resultList.Add(returnresult);
                        }
                        else
                        {
                            returnresult.Msg = "订单提交失败";
                            returnresult.OrderId = record.DistributionRecordKey;
                            returnresult.TransNo = record.BatchNo;
                            returnresult.Result = "999";
                            resultList.Add(returnresult);
                            record.OrderStatus = "SB";
                            _flowDistributionRecordsService.Update(record);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                logMsg.Error(ex.Message);

                resultList.Add(new AgentResult { Msg = "异常", Result = "902" });
            }
            return resultList;
        }

        private FlowCode GetFlowCode(int flowKey, string mobile)
        {
            var systemFlow = _systemFlowPacketsService.FindById(flowKey);
            var baseFlowInfo = _flowBaseInfoService.FindById(systemFlow.FlowPacketKey);
            var condition = new FlowCode
            {
                AreaStr = null,
                FlowKey = systemFlow.FlowPacketKey
            };
            //var settingInfo = _sytSystemSettingService.SelectSystemSettingBySysUserKey(systemFlow.SysUserKey);
            //var areas = _mobileAreaService.FindAll(new MobileArea { MobileHead = mobile.Substring(0, 7) });
            //if (areas != null && areas.Count > 0 && areas.Any())
            //{
            //    condition.AreaStr.Add(areas.First().AreaKey);
            //}
            var flowCodes = _flowCodeService.FindAll(condition).OrderBy(m => m.Priority).ToList();
            if (!flowCodes.Any()) return new FlowCode();
            if (!string.IsNullOrEmpty(baseFlowInfo.IsInterParallel) && baseFlowInfo.IsInterParallel.Equals("Y"))
            {
                var i = StaticInfo.CM023StartIndex % flowCodes.Count;
                if (StaticInfo.CM023StartIndex >= 999)
                    StaticInfo.CM023StartIndex = 1;
                else
                    StaticInfo.CM023StartIndex++;
                if (flowCodes.Count >= i) return flowCodes[i];
            }
            return flowCodes.First();
        }


        private bool CheckEmpty(ActiveFlowParam queryOrderParam, AgentResult result)
        {
            try
            {
                var variable = new CheckPageVariable();
                variable
                    .CheckInputValueIsEmpty(queryOrderParam.userkey)
                    .CheckInputValueIsEmpty(queryOrderParam.sig)
                    .CheckInputValueIsEmpty(queryOrderParam.name)
                    .CheckInputValueIsEmpty(queryOrderParam.timestamp)
                    .CheckInputValueIsEmpty(queryOrderParam.phonecodestr)
                   ;
                _resultMessage = variable.GetResultMessage();
                if (!_resultMessage.IsOk)
                {
                    result.Msg = "参数错误";
                    result.Result = "101";
                    return true;
                }
            }
            catch (Exception ex)
            {
                logMsg.Error(ex.Message);
                result.Msg = "异常";
                result.Result = "906";
            }
            return false;
        }


        private bool CheckPhoneStr(ActiveFlowParam param, AgentResult result)
        {
            var phonecodeArr = param.phonecodestr.TrimEnd('|').Split('|');
            if (phonecodeArr.Length > 0)
            {
                var phone = phonecodeArr[0].Split(',');
                if (phone.Length < 3)
                {
                    result.Msg = "电话号码与流量包代码组合字符串格式不正确";
                    result.Result = "110";
                    return true;
                }
            }
            return false;
        }

        private bool CheckAccount(ActiveFlowParam param, SystemUsers sysUser, AgentResult result)
        {
            try
            {
                decimal amount = 0;
                foreach (var phoneCodeModel in phoneCodeModels)
                {
                    var flowBaseInfo = _flowBaseInfoService.SelectFlowBaseInfoByFlowCode(phoneCodeModel.Code);
                    if (flowBaseInfo == null)
                    {
                        result.Result = "107";
                        result.Msg = "流量包权限不足(流量包不存在)";
                        return false;
                    }
                    if (!CheckIsMaintain(result, flowBaseInfo)) return false;
                    var sysFlowCount = _systemFlowPacketsService.FindAll(new SystemFlowPackets() { FlowPacketKey = flowBaseInfo.FlowKey, SysUserKey = sysUser.SysUserKey, Status = "Y" });
                    if (sysFlowCount.Count == 0)
                    {
                        result.Result = "107";
                        result.Msg = "流量包权限不足";
                        return false;
                    }
                    var froms = GetPhoneFromsHandler.GetInstance().GetFroms(phoneCodeModel.MobilePhone);
                    if (!string.IsNullOrEmpty(froms) && !flowBaseInfo.From.Equals(froms))
                    {
                        result.Result = "114";
                        result.Msg = "电话号码(" + phoneCodeModel.MobilePhone + ")与产品编号(" + phoneCodeModel.Code + ")不匹配";
                        return false;
                    }
                    amount += sysFlowCount.First().Price;
                    phoneCodeModel.Price = sysFlowCount.First().Price;
                    phoneCodeModel.FlowKey = sysFlowCount.First().FlowPacketKey;
                    phoneCodeModel.CompanyFlowKey = sysFlowCount.First().SystemFlowPacketKey;
                }
                var sysCount = sysUser.SystemAccount != null ? sysUser.SystemAccount.LeftAccount + sysUser.SystemAccount.OverDraft - 1000 : 0;
                if (amount > sysCount)
                {
                    result.Result = "108";
                    result.Msg = "账户余额不足";
                    return false;
                }
            }
            catch (Exception ex)
            {
                logMsg.Error(ex.Message);
                result.Result = "901";
                result.Msg = "内部错误";
                return true;
            }
            return false;
        }

        private bool CheckIsMaintain(AgentResult result, FlowBaseInfo flowBaseInfo)
        {
            if (!(string.IsNullOrEmpty(flowBaseInfo.ChannelStatus)) && flowBaseInfo.ChannelStatus.Equals("N"))
            {
                result.Result = "115";
                result.Msg = "通道维护！请暂停提交!";
                return false;
            }
            var muList = _carrierMaintainRecordService.GetCount(new CarrierMaintainRecords() { IsQueryInTime = "Y", RecoveryStatus = "ING" });
            if (muList > 0)
            {
                var item = _carrierMaintainDetailService.SelectCarrierMaintainDetailsByFlowKey(flowBaseInfo.FlowKey);
                if (item != null)
                {
                    result.Result = "116";
                    result.Msg = "通道维护！请暂停提交!";
                    return false;
                }
            }
            return true;
        }

        private bool CheckPhoneLength(ActiveFlowParam param, AgentResult result)
        {
            try
            {
                var phonecodeArr = param.phonecodestr.TrimEnd('|').Split('|');
                phoneCodeModels = (from s in phonecodeArr where !string.IsNullOrEmpty(s) select s.Split(',') into sArr select new PhoneCodeModel { MobilePhone = sArr[0], Code = sArr[1], TransNo = sArr[2] }).ToList();
                if (phoneCodeModels.Count > 10)
                {
                    result.Result = "105";
                    result.Msg = "电话号码多于10个";
                    return true;
                }
            }
            catch (Exception ex)
            {
                result.Result = "910";
                result.Msg = "异常";
                logMsg.Error(ex.Message);
            }
            return false;
        }


        private string GetMobileStr(ActiveFlowParam param)
        {
            strTrans = new StringBuilder();
            var str = new StringBuilder();
            try
            {
                if (phoneCodeModels != null)
                {
                    foreach (var phoneCodeModel in phoneCodeModels)
                    {
                        str.Append(phoneCodeModel.MobilePhone + "," + phoneCodeModel.CompanyFlowKey + "|");
                        strTrans.Append(phoneCodeModel.TransNo + ",");
                    }
                }
            }
            catch (Exception ex)
            {
                logMsg.Error(ex.Message);
            }
            return str.ToString().TrimEnd('|');
        }

        private bool CheckTimeStamp(ActiveFlowParam param, AgentResult result)
        {
            try
            {
                var timespan = DateTime.Now - DateTime.ParseExact(param.timestamp, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture); ;
                if (timespan.TotalSeconds >= 180)
                {
                    result.Result = "104";
                    result.Msg = "已超时";
                    return true;
                }
            }
            catch (Exception ex)
            {
                result.Result = "908";
                result.Msg = "异常";
                logMsg.Error(ex.Message);
            }
            return false;
        }

        private bool CheckSig(ActiveFlowParam param, AgentResult result, SystemUsers sysUser)
        {
            try
            {

                var sigStr = sysUser.PWD + "||" + param.name + "||" + param.phonecodestr + "||" + param.userkey + "||" + param.timestamp +
                             "||" + sysUser.PWD;
                var sigParent = SHA1(sigStr);
                var sig = sigParent.Substring(4, sigParent.Length - 8);
                if (!sig.Equals(param.sig))
                {
                    result.Result = "103";
                    result.Msg = "sig校验失败";
                    return true;
                }
            }
            catch (Exception ex)
            {
                result.Result = "907";
                result.Msg = "异常";
                logMsg.Error(ex.Message);
            }
            return false;
        }



        private ISystemUsersService _systemUsersService;
        private IList<PhoneCodeModel> phoneCodeModels = null;
        private StringBuilder strTrans;
        private ResultMessage _resultMessage;
        private IMobileAreaService _mobileAreaService;
        private ISystemFlowPacketsService _systemFlowPacketsService;
        private IFlowBaseInfoService _flowBaseInfoService;
        private ISystemSettingService _sytSystemSettingService;
        private IFlowCodeService _flowCodeService;
        private IFlowDistributionRecordsService _flowDistributionRecordsService;
        private ICarrierMaintainRecordService _carrierMaintainRecordService;
        private ICarrierMaintainDetailService _carrierMaintainDetailService;
    }
}