using System;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL.Sys
{
    public class SystemAccountLogDao : DaoBase<SystemAccountLog>, ISystemAccountLogDao
    {
        ResultMessage IDao<SystemAccountLog>.Insert(SystemAccountLog entity)
        {
            try
            {
                Mapper.Instance().Insert("InsertAccountLog", entity);
                 
            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<SystemAccountLog>.Update(SystemAccountLog entity)
        {
            try
            {
                Mapper.Instance().Update("UpdateAccountLog", entity);

            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<SystemAccountLog>.Delete(int id)
        {
            try
            {
                Mapper.Instance().Delete("DeleteAccountLog", id);

            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        SystemAccountLog IDao<SystemAccountLog>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<SystemAccountLog>("SelectAccountLogByKey", id);
        }

        IList<SystemAccountLog> IDao<SystemAccountLog>.FindAll(SystemAccountLog condition)
        {
            return Mapper.Instance().QueryForList<SystemAccountLog>("SelectAccountLogList", condition);
        }

        int IDao<SystemAccountLog>.GetCount(SystemAccountLog codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectAccountLogCount", codition);
        }
    }
}
