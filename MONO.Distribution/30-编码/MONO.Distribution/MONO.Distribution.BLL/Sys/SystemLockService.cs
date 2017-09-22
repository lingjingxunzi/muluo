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
    public class SystemLockService : ServiceBase<SystemLock>, ISystemLockService
    {
        ISystemLockDao _systemLockDao = new SystemLockDao();
        ResultMessage IService<SystemLock>.Insert(SystemLock entity)
        {
            return _systemLockDao.Insert(entity);
        }

        ResultMessage IService<SystemLock>.Update(SystemLock entity)
        {
            return _systemLockDao.Update(entity);
        }

        ResultMessage IService<SystemLock>.Delete(int id)
        {
            return _systemLockDao.Delete(id);
        }

        SystemLock IService<SystemLock>.FindById(int id)
        {
            return _systemLockDao.FindById(id);
        }

        IList<SystemLock> IService<SystemLock>.FindAll(SystemLock condition)
        {
            return _systemLockDao.FindAll(condition);
        }

        int IService<SystemLock>.GetCount(SystemLock codition)
        {
            return _systemLockDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(SystemLock t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(SystemLock t)
        {
            throw new NotImplementedException();
        }
    }
}
