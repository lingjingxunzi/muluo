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
    public class SystemLockDao : DaoBase<SystemLock>, ISystemLockDao
    {
        ResultMessage IDao<SystemLock>.Insert(SystemLock entity)
        {
            try
            {
                Mapper.Instance().Insert("InsertSystemLock", entity);
            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<SystemLock>.Update(SystemLock entity)
        {
            try
            {
                Mapper.Instance().Update("UpdateSystemLock", entity);

            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<SystemLock>.Delete(int id)
        {
            try
            {
                Mapper.Instance().Delete("DeleteSystemLock", id);

            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        SystemLock IDao<SystemLock>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<SystemLock>("SelectSystemLockByKey", id);
        }

        IList<SystemLock> IDao<SystemLock>.FindAll(SystemLock condition)
        {
            return Mapper.Instance().QueryForList<SystemLock>("SelectSystemLockList", condition);
        }

        int IDao<SystemLock>.GetCount(SystemLock codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectSystemLockCount", codition);
        }
    }
}
