using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.DAL.Agent;
using MONO.Distribution.DAL.Interface.Agent;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.Agent
{
    public class FlowDistributionRecordsService : ServiceBase<FlowDistributionRecords>, IFlowDistributionRecordsService
    {
        IFlowDistributionRecordsDao _flowDistributionRecordsDao = new FlowDistributionRecordsDao();
        ResultMessage IService<FlowDistributionRecords>.Insert(FlowDistributionRecords entity)
        {
            return base.Insert(entity);
        }

        ResultMessage IService<FlowDistributionRecords>.Update(FlowDistributionRecords entity)
        {
            return _flowDistributionRecordsDao.Update(entity);
        }

        ResultMessage IService<FlowDistributionRecords>.Delete(int id)
        {
            return _flowDistributionRecordsDao.Delete(id);
        }

        FlowDistributionRecords IService<FlowDistributionRecords>.FindById(int id)
        {
            return _flowDistributionRecordsDao.FindById(id);
        }

        IList<FlowDistributionRecords> IService<FlowDistributionRecords>.FindAll(FlowDistributionRecords condition)
        {
            return _flowDistributionRecordsDao.FindAll(condition);
        }

        int IService<FlowDistributionRecords>.GetCount(FlowDistributionRecords codition)
        {
            return _flowDistributionRecordsDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(FlowDistributionRecords t)
        {
            return _flowDistributionRecordsDao.Insert(t);
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            return _flowDistributionRecordsDao.Delete(id);
        }

        protected override ResultMessage ExecuteUpdate(FlowDistributionRecords t)
        {
            return _flowDistributionRecordsDao.Update(t);
        }

        protected override ResultMessage AfterInsert(FlowDistributionRecords t)
        {
            var flowInfo = _systemFlowPacketsService.FindById(t.CompanyFlowPacketKey);
            var histories = new FlowActiveHistories
            {
                Carrier = t.Carrier,
                Code = t.Code,
                FlowStatus = "0001",
                DistributionRecordKey = t.DistributionRecordKey,
                FlowActiveHistoryKey = t.Carrier.Equals("CT023_P") ? "qxcx" + GetGuidStrHandler.GenerateStringID().Substring(0,4) + GetGuidStrHandler.GenerateDt023ID() : "D-" + GetGuidStrHandler.GenerateStringID() 
            };
            if (string.IsNullOrEmpty(t.DistributionType) || (t.DistributionType.Equals("Orders") && t.OrderType.Equals("Inter")))
            {
                var accountResult = _systemAccountService.SystemAccountChange(t.SysUserKey, t.DistributionRecordKey, -flowInfo.Price, "ZS");
                if (accountResult.IsOk)
                {
                    var hisResult = _flowActiveHistoriesService.Insert(histories);
                    return hisResult;
                }
                else
                {
                    return accountResult;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(t.DistributionType) || (t.DistributionType.Equals("Orders") && t.OrderType.Equals("Platform")))
                {
                    var accountResult = _systemAccountService.SystemAccountChange(t.SysUserKey, t.DistributionRecordKey, -flowInfo.Price, "PTZS");
                    if (accountResult.IsOk)
                    {
                        var platResult = _flowActiveHistoriesService.Insert(histories);
                        return platResult;
                    }
                    else
                    {
                        return accountResult;
                    }
                }
                else
                {
                    var hisResult = _flowActiveHistoriesService.Insert(histories);
                    return hisResult;
                }
            }
        }
        FlowDistributionRecords IFlowDistributionRecordsService.FindById(string p)
        {
            return _flowDistributionRecordsDao.FindById(p);
        }

        IFlowActiveHistoriesService _flowActiveHistoriesService = new FlowActiveHistoriesService();
        ISystemFlowPacketsService _systemFlowPacketsService = new SystemFlowPacketsService();
        ISystemAccountService _systemAccountService = new SystemAccountService();


        IList<FlowDistributionRecords> IFlowDistributionRecordsService.SelectDistributionRecordListForQueryBySysUserKey(FlowDistributionRecords condition)
        {
            return _flowDistributionRecordsDao.SelectDistributionRecordListForQueryBySysUserKey(condition);
        }

        
        IList<FlowDistributionRecords> IFlowDistributionRecordsService.SelectTransIdIsExistsCount(string BatchNo)
        {
            return _flowDistributionRecordsDao.SelectTransIdIsExistsCount(BatchNo);
        }


        IList<FlowDistributionRecords> IFlowDistributionRecordsService.SelectDistributionRecordForIntergalList(FlowDistributionRecords condition)
        {
            return _flowDistributionRecordsDao.SelectDistributionRecordForIntergalList(condition);
        }

        int IFlowDistributionRecordsService.SelectDistributionRecordForIntergalCount(FlowDistributionRecords condition)
        {
            return _flowDistributionRecordsDao.SelectDistributionRecordForIntergalCount(condition);
        }
    }
}
