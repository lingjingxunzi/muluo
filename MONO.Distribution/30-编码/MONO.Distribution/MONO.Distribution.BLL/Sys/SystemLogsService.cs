using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.Common;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.DAL.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.Sys
{
    public class SystemLogsService : ServiceBase<SystemLogs>, ISystemLogsService
    {
        ISystemLogsDao _systemLogsDao = new SystemLogsDao();
        ResultMessage IService<SystemLogs>.Insert(SystemLogs entity)
        {
            return _systemLogsDao.Insert(entity);
        }

        ResultMessage IService<SystemLogs>.Update(SystemLogs entity)
        {
            return _systemLogsDao.Update(entity);
        }

        ResultMessage IService<SystemLogs>.Delete(int id)
        {
            return _systemLogsDao.Delete(id);
        }

        SystemLogs IService<SystemLogs>.FindById(int id)
        {
            return _systemLogsDao.FindById(id);
        }

        IList<SystemLogs> IService<SystemLogs>.FindAll(SystemLogs condition)
        {
            return _systemLogsDao.FindAll(condition);
        }

        int IService<SystemLogs>.GetCount(SystemLogs codition)
        {
            return _systemLogsDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(SystemLogs t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(SystemLogs t)
        {
            throw new NotImplementedException();
        }
    }
}
