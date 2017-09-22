using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using log4net;
using log4net.Util;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Common;
using MONO.Distribution.DAL.Agent;
using MONO.Distribution.DAL.BaseInfo;
using MONO.Distribution.DAL.Interface.Agent;
using MONO.Distribution.DAL.Interface.BaseInfo;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.DAL.Sys;
using MONO.Distribution.Message;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.Agent
{
    public class FlowActiveHistoriesService : ServiceBase<FlowActiveHistories>, IFlowActiveHistoriesService
    {
        ILog LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        IFlowActiveHistoriesDao _flowActiveHistoriesDao = new FlowActiveHistoriesDao();
        IChannelMsgSettingsDao _channelMsgSettingsDao = new ChannelMsgSettingsDao();
        ResultMessage IService<FlowActiveHistories>.Insert(FlowActiveHistories entity)
        {
            return base.Insert(entity);
        }

        ResultMessage IService<FlowActiveHistories>.Update(FlowActiveHistories entity)
        {
            return base.Update(entity);
        }

        ResultMessage IService<FlowActiveHistories>.Delete(int id)
        {
            return _flowActiveHistoriesDao.Delete(id);
        }

        FlowActiveHistories IService<FlowActiveHistories>.FindById(int id)
        {
            return _flowActiveHistoriesDao.FindById(id);
        }

        IList<FlowActiveHistories> IService<FlowActiveHistories>.FindAll(FlowActiveHistories condition)
        {
            return _flowActiveHistoriesDao.FindAll(condition);
        }

        int IService<FlowActiveHistories>.GetCount(FlowActiveHistories codition)
        {
            return _flowActiveHistoriesDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(FlowActiveHistories t)
        {
            return _flowActiveHistoriesDao.Insert(t);
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(FlowActiveHistories t)
        {
            return _flowActiveHistoriesDao.Update(t);
        }

        protected override ResultMessage AfterInsert(FlowActiveHistories t)
        {
            var result = new ResultMessage();
            try
            {
                var textFolder = ConfigurationManager.AppSettings["ActiveFolder"];
                if (t.Carrier.Contains("CM023") && t.Carrier != "CM023New")
                {
                    textFolder = ConfigurationManager.AppSettings["BaseFolder"] + "//" + t.Carrier;
                }
                else
                {
                    if (t.Carrier.Contains("CT023"))
                    {
                        if (t.Carrier.Equals("CT023_A"))
                            textFolder = ConfigurationManager.AppSettings["BaseFolder"] + "//CT023";
                        if (t.Carrier.Equals("CT023_P"))
                            textFolder = ConfigurationManager.AppSettings["BaseFolder"] + "//DTBD";
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["IsDiffFolder"]) && ConfigurationManager.AppSettings["IsDiffFolder"].Equals("1"))
                        {
                            var rdm = new Random();
                            var n = rdm.Next(1, 8);
                            textFolder = ConfigurationManager.AppSettings["BaseFolder"] + n.ToString().PadLeft(2, '0') + "//";
                        }
                    }
                }
                var distributionInfo = _flowDistributionRecordsService.FindById(t.DistributionRecordKey);
                if (t.Carrier.Equals("CT023_P"))
                {
                    var xml = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><Root><Header><transactionId>" + t.FlowActiveHistoryKey + "</transactionId>"
                    + "<channel_id >1</channel_id>"
                    + "<password>9FE374529D3658197DA0</password>"
                  + "</Header><DataParam><acc_nbr>" + distributionInfo.MobilePhone + "</acc_nbr>"
                  + "<c_product_id>208511296</c_product_id>"
                      + "<buss_id>10034</buss_id><con_id>" + ConfigurationManager.AppSettings["conId"] + "</con_id>"
                          + "<sale_type>A</sale_type><offerCompId>" + t.Code + "</offerCompId>"
                + "<newFlag>F</newFlag><accept_type>1</accept_type>"
                + "<accept_mode>1</accept_mode><stimeFlag>0</stimeFlag>"
                + " </DataParam></Root>";
                    TxtWriteHandler.FileStreamWrite(textFolder, t.FlowActiveHistoryKey + ".xml", xml);
                }
                else
                {
                    var textContent = t.Carrier + "," + t.Code + "," + distributionInfo.MobilePhone + "," + t.FlowActiveHistoryKey + "," + (distributionInfo.SystemFlowPackets != null ? distributionInfo.SystemFlowPackets.FlowBaseInfo.Size : 0) + ",http://113.207.124.143/Order/GetOrderResultCallBack.aspx" + "," + (int)(distributionInfo.SystemFlowPackets.FlowBaseInfo.StandardPrice / 100);
                    TxtWriteHandler.FileStreamWrite(textFolder, t.FlowActiveHistoryKey + ".txt", textContent);
                }
            }
            catch (Exception ex)
            {
                result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return result;
        }
        IFlowDistributionRecordsDao _flowDistributionRecordsService = new FlowDistributionRecordsDao();

        FlowActiveHistories IFlowActiveHistoriesService.FindById(string transKey)
        {
            return _flowActiveHistoriesDao.FindById(transKey);
        }

        protected override ResultMessage AfterUpdate(FlowActiveHistories t)
        {
            var disInfo = _flowDistributionRecordsService.FindById(t.DistributionRecordKey);
            var settingInfo = _systemSettingDao.SelectSystemSettingBySysUserKey(disInfo.SysUserKey);
            var msgTemps = _systemMsgTemplatesDao.FindAll(new SystemMsgTemplates { SysUserKey = disInfo.SysUserKey });
            if (!string.IsNullOrEmpty(t.FlowStatus) && t.FlowStatus.Equals("0"))
            {
                OrderSuccessInfoInit(t, disInfo);
                SendMsgByChannel(t, disInfo);
                //SendSmsBySetting(settingInfo, msgTemps, disInfo);
                CalculateProfit(disInfo);
            }
            else
            {
                OrderFaildOperate(t, disInfo, settingInfo, msgTemps);
            }
            _flowDistributionRecordsService.Update(disInfo);
            return base.AfterUpdate(t);
        }

        private void SendMsgByChannel(FlowActiveHistories t, FlowDistributionRecords disInfo)
        {
            try
            {
                var item = _channelMsgSettingsDao.FindAll(new ChannelMsgSettings() { ChannelName = t.Carrier,Status = "0"});
                if (item != null && item.Count > 0)
                {
                    var content = item.First().MsgTemp;
                    var contentwithParm = ContentCombinationHandler.GetContent(content,GetSizeName(disInfo));
                    var msgSendRecord = new MsgSendRecord
                    {
                        SysUserKey = disInfo.SysUserKey,
                        Content = contentwithParm,
                        MsgSendRecordkey = Guid.NewGuid().ToString(),
                        UserPhone = disInfo.MobilePhone
                    };
                    var result = SendMessageHandler.SendMsg(disInfo.MobilePhone, contentwithParm);
                    msgSendRecord.Status = result;
                    _msgSendRecordDao.Insert(msgSendRecord);
                }
            }
            catch (Exception ex)
            {
                WriteErrors(ex.ToString());
            }
        }

        private string GetSizeName(FlowDistributionRecords disInfo)
        {
            if (disInfo.SystemFlowPackets.FlowBaseInfo.Size <1024)
            {
                return disInfo.SystemFlowPackets.FlowBaseInfo.Size + "M";
            }
            else
            {
                return disInfo.SystemFlowPackets.FlowBaseInfo.Size/1024 + "G";
            }
        }

        private void SendSmsBySetting(SystemSetting settingInfo, IList<SystemMsgTemplates> msgTemps, FlowDistributionRecords disInfo)
        {
            try
            {
                LogMsg.Info(settingInfo.IsSendMsg);
                LogMsg.Info(msgTemps.Any());
                if (settingInfo != null && settingInfo.IsSendMsg.Equals("Y") && msgTemps.Any())
                {
                    var temp = from m in msgTemps
                               where m.MessageTemplate.MsgType == "success"
                               select m;
                    if (temp.Any())
                    {
                        SendFlowMessage(temp, disInfo);
                    }
                }

            }
            catch (Exception ex)
            {
                 
            }
        }

        private void OrderSuccessInfoInit(FlowActiveHistories t, FlowDistributionRecords disInfo)
        {
            disInfo.Carrier = t.Carrier;
            disInfo.Code = disInfo.Code;
            disInfo.OrderStatus = "CG";
            disInfo.OrderNo = t.Orders;
            disInfo.ResultMsg = t.Results;
            SendCallBack(disInfo);
        }

        private void CalculateProfit(FlowDistributionRecords disInfo)
        {
            try
            {
                var curr = _systemUsersDao.FindById(disInfo.SysUserKey);
                var parent = _systemUsersDao.FindById(curr.ParentKey);
                LogMsg.Info("CalculateProfit parentKey:" + parent.ParentKey);
                if (parent.ParentKey == 0) return;
                var sysFlow =
                    _systemFlowPacketsDao.FindAll(new SystemFlowPackets
                    {
                        SysUserKey = disInfo.SysUserKey,
                        FlowPacketKey = disInfo.SystemFlowPackets.FlowPacketKey
                    });
                do
                {
                    var sysFlows =
                        _systemFlowPacketsDao.FindAll(new SystemFlowPackets
                        {
                            SysUserKey = parent.SysUserKey,
                            FlowPacketKey = disInfo.SystemFlowPackets.FlowPacketKey
                        });
                    if (sysFlows.Count > 0)
                    {
                        var difference = sysFlow.First().Price - sysFlows.First().Price;
                        _systemAccountService.SystemAccountChange(parent.SysUserKey, disInfo.DistributionRecordKey,
                            difference, "YS");
                    }
                    sysFlow =
                        _systemFlowPacketsDao.FindAll(new SystemFlowPackets
                        {
                            SysUserKey = parent.SysUserKey,
                            FlowPacketKey = disInfo.SystemFlowPackets.FlowPacketKey
                        });
                    parent = _systemUsersDao.FindById(parent.ParentKey);
                } while (!parent.Account.ToLower().Equals("admin"));

            }
            catch (Exception ex)
            {
                throw new Exception("计算盈利出错-" + ex.Message);
            }
        }

        private void OrderFaildOperate(FlowActiveHistories t, FlowDistributionRecords disInfo, SystemSetting settingInfo,
            IList<SystemMsgTemplates> msgTemps)
        {
            var condition = new FlowCode
            {
                FlowKey = disInfo.SystemFlowPackets.FlowBaseInfo.FlowKey,
                FromRanges = settingInfo.IsDefaultProvnice.Equals("Y") ? "" : "-1"
            };
            //var areas = _mobileAreaDao.FindAll(new MobileArea { MobileHead = disInfo.MobilePhone.Substring(0, 7) });
            //if (areas != null && areas.Count > 0 && areas.Any())
            //{
            //    condition.AreaStr = new List<string> {"0"};
            //    condition.AreaStr.Add(areas.First().AreaKey);
            //}

            if (string.IsNullOrEmpty(disInfo.SystemFlowPackets.FlowBaseInfo.IsRecyle) || disInfo.SystemFlowPackets.FlowBaseInfo.IsRecyle.Equals("N"))
            {
                OrderCompletionStatusUpdate(t, disInfo, settingInfo, msgTemps);
                return;
            }
            var list = _flowCodeDao.FindAll(condition);
            var currIndex = list.ToList()
                .FindIndex(m => m.Carrier == t.Carrier && m.ProductCode == t.Code);
            LogMsg.Info("list.Count:" + list.Count);
            LogMsg.Info("currIndex +1 :" + currIndex + 1);
            if (list.Count == currIndex + 1)
                OrderCompletionStatusUpdate(t, disInfo, settingInfo, msgTemps);
            else
            {
                if (disInfo.OrderStatus != "CG" && disInfo.OrderStatus != "SB")
                {
                    OrderTwoRequest(list, currIndex, disInfo);
                }
            }


        }

        private void OrderCompletionStatusUpdate(FlowActiveHistories t, FlowDistributionRecords disInfo,
            SystemSetting settingInfo, IList<SystemMsgTemplates> msgTemps)
        {
            disInfo.Carrier = t.Carrier;
            disInfo.Code = disInfo.Code;
            disInfo.OrderStatus = "SB";
            disInfo.OrderNo = t.Orders;
            disInfo.ResultMsg = t.Results;
            if (settingInfo != null && settingInfo.IsAfterFaildToSave.Equals("Y"))
            {
                disInfo.OrderStatus = "Temp";
                var temp = from m in msgTemps
                           where m.MessageTemplate.MsgType == "Temporary"
                           select m;
                if (temp.Any())
                {
                    SendFlowMessage(temp, disInfo);
                }
            }
            SendCallBack(disInfo);
            if (settingInfo != null && settingInfo.IsAfterFaildToSave.Equals("N"))
            {
                _systemAccountService.SystemAccountChange(disInfo.SysUserKey, disInfo.DistributionRecordKey,
                    disInfo.SystemFlowPackets.Price, "FlowBack");
            }
        }

        private void OrderTwoRequest(IList<FlowCode> list, int currIndex, FlowDistributionRecords disInfo)
        {
            var next = new FlowCode();
            try
            {
                next = list[currIndex + 1];
            }
            catch (Exception ex)
            {
                return;
            }
            if (!string.IsNullOrEmpty(next.From))
            {
                var his = new FlowActiveHistories();
                his.Carrier = next.Carrier;
                his.Code = next.ProductCode;
                his.FlowStatus = "0001";
                his.DistributionRecordKey = disInfo.DistributionRecordKey;
                his.FlowActiveHistoryKey = next.Carrier.Equals("CT023_P")
                    ? "qxcx" + GetGuidStrHandler.GenerateStringID()
                    : "D-" + GetGuidStrHandler.GenerateStringID();
                _flowActiveHistoriesDao.Insert(his);
                AfterInsert(his);
            }
        }

        private void SendFlowMessage(IEnumerable<SystemMsgTemplates> temp, FlowDistributionRecords disInfo)
        {
            var content = temp.First().MessageTemplate.Content;
            var contentwithParm = ContentCombinationHandler.GetContent(content, disInfo.SystemUsers.Account,
                disInfo.SystemFlowPackets.FlowBaseInfo.FlowName);
            var msgSendRecord = new MsgSendRecord
            {
                SysUserKey = disInfo.SysUserKey,
                Content = contentwithParm,
                MsgSendRecordkey = Guid.NewGuid().ToString(),
                UserPhone = disInfo.MobilePhone
            };
            var accountResult = _systemAccountService.SystemAccountChange(disInfo.SysUserKey,
                msgSendRecord.MsgSendRecordkey, -temp.First().MessageTemplate.Price, "Message");
            if (accountResult.IsOk)
            {
                var result = SendMessageHandler.SendMsg(disInfo.MobilePhone, contentwithParm);
                msgSendRecord.Status = result;
                if (result.Length == 2)
                {
                    _systemAccountService.SystemAccountChange(disInfo.SysUserKey,
                        msgSendRecord.MsgSendRecordkey, temp.First().MessageTemplate.Price, "MessageBack");
                }
            }
            _msgSendRecordDao.Insert(msgSendRecord);
        }


        public void SendCallBack(FlowDistributionRecords dis)
        {
            try
            {
                if (!string.IsNullOrEmpty(dis.OrderType) && dis.OrderType.Equals("Inter") && !string.IsNullOrEmpty(dis.BackUrl))
                {

                    var url = "";
                    if (dis.BackUrl.Contains("?"))
                    {
                        url = dis.BackUrl + "&";
                    }
                    else
                    {
                        url = dis.BackUrl + "?";
                    }
                    url = url + "orderId=" + dis.DistributionRecordKey + "&result=" + dis.OrderStatus + "&msg=" + dis.ResultMsg + "&transNo=" + dis.BatchNo;
                    LogMsg.Info("回调地址：" + url);
                    var json = HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                    LogMsg.Info("回调返回：" + json);
                }
            }
            catch (Exception ex)
            {
                LogMsg.Error(ex.Message);
            }
        }

        private IPushResultRecordDao _pushDao = new PushResultRecordDao();
        private IFlowCodeDao _flowCodeDao = new FlowCodeDao();
        private ISystemSettingDao _systemSettingDao = new SystemSettingDao();
        private ISystemMsgTemplatesDao _systemMsgTemplatesDao = new SystemMsgTemplatesDao();
        private IMsgSendRecordDao _msgSendRecordDao = new MsgSendRecordDao();
        private ISystemAccountService _systemAccountService = new SystemAccountService();
        private ISystemUsersDao _systemUsersDao = new SystemUsersDao();
        private ISystemFlowPacketsDao _systemFlowPacketsDao = new SystemFlowPacketsDao();
        private IMobileAreaDao _mobileAreaDao = new MobileAreaDao();


        FlowActiveHistories IFlowActiveHistoriesService.SelectFlowActiveHistoriesByOrderId(string orders)
        {
            return _flowActiveHistoriesDao.SelectFlowActiveHistoriesByOrderId(orders);
        }


        ResultMessage IFlowActiveHistoriesService.UpdateHistoryStatus(FlowActiveHistories entity)
        {
            return _flowActiveHistoriesDao.Update(entity);
        }


        void  IFlowActiveHistoriesService.Test(FlowActiveHistories entity)
        {
            ResultMessage message = new ResultMessage();
            var disInfo = _flowDistributionRecordsService.FindById(entity.DistributionRecordKey);
             SendMsgByChannel(entity, disInfo);
        }
    }
}
