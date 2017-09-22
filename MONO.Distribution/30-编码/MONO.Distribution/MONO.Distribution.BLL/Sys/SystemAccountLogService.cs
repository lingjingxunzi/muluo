using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.DAL.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.Sys
{
    public class SystemAccountLogService : ServiceBase<SystemAccountLog>, ISystemAccountLogService
    {
        ISystemAccountLogDao _stsSystemAccountLogDao = new SystemAccountLogDao();
        ResultMessage IService<SystemAccountLog>.Insert(SystemAccountLog entity)
        {
            return _stsSystemAccountLogDao.Insert(entity);
        }

        ResultMessage IService<SystemAccountLog>.Update(SystemAccountLog entity)
        {
            return _stsSystemAccountLogDao.Update(entity);
        }

        ResultMessage IService<SystemAccountLog>.Delete(int id)
        {
            return _stsSystemAccountLogDao.Delete(id);
        }

        SystemAccountLog IService<SystemAccountLog>.FindById(int id)
        {
            return _stsSystemAccountLogDao.FindById(id);
        }

        IList<SystemAccountLog> IService<SystemAccountLog>.FindAll(SystemAccountLog condition)
        {
            return _stsSystemAccountLogDao.FindAll(condition);
        }

        int IService<SystemAccountLog>.GetCount(SystemAccountLog codition)
        {
            return _stsSystemAccountLogDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(SystemAccountLog t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(SystemAccountLog t)
        {
            throw new NotImplementedException();
        }
    }
}
