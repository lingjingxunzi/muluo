using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using MONO.Distribution.Common;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL.Sys
{
    public class RechargeRecordsDao : DaoBase<RechargeRecords>, IRechargeRecordsDao
    {
        ResultMessage IDao<RechargeRecords>.Insert(RechargeRecords entity)
        {
            try
            {
                Mapper.Instance().Insert("InsertRechargeRecord", entity);

            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(),ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<RechargeRecords>.Update(RechargeRecords entity)
        {
            try
            {
                Mapper.Instance().Update("UpdateRechargeRecord", entity);

            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<RechargeRecords>.Delete(int id)
        {
            try
            {
                Mapper.Instance().Delete("DeleteRechargeRecord", id);

            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        RechargeRecords IDao<RechargeRecords>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<RechargeRecords>("SelectRechargeRecordByKey", id);
        }

        IList<RechargeRecords> IDao<RechargeRecords>.FindAll(RechargeRecords condition)
        {
            return Mapper.Instance().QueryForList<RechargeRecords>("SelectRechargeRecordList", condition);
        }

        int IDao<RechargeRecords>.GetCount(RechargeRecords codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectRechargeRecordCount", codition);
        }

        RechargeRecords IRechargeRecordsDao.FindById(string RechargeKey)
        {
            return Mapper.Instance().QueryForObject<RechargeRecords>("SelectRechargeRecordByKey", RechargeKey);
        }
    }
}
