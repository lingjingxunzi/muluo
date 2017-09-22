using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL.Sys
{
    public class SystemErrLoginRecordDao :DaoBase<SystemErrLoginRecord>, ISystemErrLoginRecordDao
    {
        ResultMessage IDao<SystemErrLoginRecord>.Insert(SystemErrLoginRecord entity)
        {
            try
            {
                Mapper.Instance().Insert("InsertLoginRecord", entity);
            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<SystemErrLoginRecord>.Update(SystemErrLoginRecord entity)
        {
            try
            {
                Mapper.Instance().Update("UpdateLoginRecord", entity);
            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<SystemErrLoginRecord>.Delete(int id)
        {
            try
            {
                Mapper.Instance().Delete("DeleteLoginRecord", id);
            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        SystemErrLoginRecord IDao<SystemErrLoginRecord>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<SystemErrLoginRecord>("SelectLoginRecordByKey", id);
        }

        IList<SystemErrLoginRecord> IDao<SystemErrLoginRecord>.FindAll(SystemErrLoginRecord condition)
        {
            return Mapper.Instance().QueryForList<SystemErrLoginRecord>("SelectLoginRecordList", condition);
        }

        int IDao<SystemErrLoginRecord>.GetCount(SystemErrLoginRecord codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectLoginRecordCount", codition);
        }
    }
}
