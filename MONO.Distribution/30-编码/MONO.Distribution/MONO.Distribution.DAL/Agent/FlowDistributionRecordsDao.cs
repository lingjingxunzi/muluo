using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using MONO.Distribution.DAL.Interface.Agent;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL.Agent
{
    public class FlowDistributionRecordsDao : DaoBase<FlowDistributionRecords>, IFlowDistributionRecordsDao
    {
        ResultMessage IDao<FlowDistributionRecords>.Insert(FlowDistributionRecords entity)
        {
            try
            {
                  Mapper.Instance().Insert("InsertDistributionRecord", entity);
               
            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<FlowDistributionRecords>.Update(FlowDistributionRecords entity)
        {
            try
            {
                Mapper.Instance().Update("UpdateDistributionRecord", entity);
               
            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<FlowDistributionRecords>.Delete(int id)
        {
            try
            {
                Mapper.Instance().Delete("DeleteDistributionRecord", id);
                 
            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        FlowDistributionRecords IDao<FlowDistributionRecords>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<FlowDistributionRecords>("SelectDistributionRecordByKey", id);
        }

        IList<FlowDistributionRecords> IDao<FlowDistributionRecords>.FindAll(FlowDistributionRecords condition)
        {
            
            return Mapper.Instance().QueryForList<FlowDistributionRecords>("SelectDistributionRecordList", condition);
        }

        int IDao<FlowDistributionRecords>.GetCount(FlowDistributionRecords codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectDistributionRecordCount", codition);
        }

        FlowDistributionRecords IFlowDistributionRecordsDao.FindById(string p)
        {
            return Mapper.Instance().QueryForObject<FlowDistributionRecords>("SelectDistributionRecordByKey", p);
        }


        IList<FlowDistributionRecords> IFlowDistributionRecordsDao.SelectDistributionRecordListForQueryBySysUserKey(FlowDistributionRecords condition)
        {
            return Mapper.Instance().QueryForList<FlowDistributionRecords>("SelectDistributionRecordListForQueryBySysUserKey", condition);
        }


        IList<FlowDistributionRecords> IFlowDistributionRecordsDao.SelectTransIdIsExistsCount(string BatchNo)
        {
            return Mapper.Instance().QueryForList<FlowDistributionRecords>("SelectTransIdIsExistsCount", BatchNo);
        }


        IList<FlowDistributionRecords> IFlowDistributionRecordsDao.SelectDistributionRecordForIntergalList(FlowDistributionRecords condition)
        {
            return Mapper.Instance().QueryForList<FlowDistributionRecords>("SelectDistributionRecordForIntergalList", condition);
        }

        int IFlowDistributionRecordsDao.SelectDistributionRecordForIntergalCount(FlowDistributionRecords condition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectDistributionRecordForIntergalCount", condition);
       
        }
    }
}
