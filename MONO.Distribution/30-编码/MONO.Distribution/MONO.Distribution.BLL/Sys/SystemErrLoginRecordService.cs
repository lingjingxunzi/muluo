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
    public class SystemErrLoginRecordService : ServiceBase<SystemErrLoginRecord>, ISystemErrLoginRecordService
    {
        ISystemErrLoginRecordDao _systemErrLoginRecordDao = new SystemErrLoginRecordDao();
        ResultMessage IService<SystemErrLoginRecord>.Insert(SystemErrLoginRecord entity)
        {
            return _systemErrLoginRecordDao.Insert(entity);
        }

        ResultMessage IService<SystemErrLoginRecord>.Update(SystemErrLoginRecord entity)
        {
            return _systemErrLoginRecordDao.Update(entity);
        }

        ResultMessage IService<SystemErrLoginRecord>.Delete(int id)
        {
            return _systemErrLoginRecordDao.Delete(id);
        }

        SystemErrLoginRecord IService<SystemErrLoginRecord>.FindById(int id)
        {
            return _systemErrLoginRecordDao.FindById(id);
        }

        IList<SystemErrLoginRecord> IService<SystemErrLoginRecord>.FindAll(SystemErrLoginRecord condition)
        {
            return _systemErrLoginRecordDao.FindAll(condition);
        }

        int IService<SystemErrLoginRecord>.GetCount(SystemErrLoginRecord codition)
        {
            return _systemErrLoginRecordDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(SystemErrLoginRecord t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(SystemErrLoginRecord t)
        {
            throw new NotImplementedException();
        }
    }
}
