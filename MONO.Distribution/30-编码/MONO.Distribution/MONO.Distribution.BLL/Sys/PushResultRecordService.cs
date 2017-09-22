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
    public class PushResultRecordService : ServiceBase<PushResultRecords>, IPushResultRecordService
    {
        IPushResultRecordDao _pushResultRecordDao =new PushResultRecordDao();
        ResultMessage IService<PushResultRecords>.Insert(PushResultRecords entity)
        {
            return base.Insert(entity);
        }

        ResultMessage IService<PushResultRecords>.Update(PushResultRecords entity)
        {
            throw new NotImplementedException();
        }

        ResultMessage IService<PushResultRecords>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        PushResultRecords IService<PushResultRecords>.FindById(int id)
        {
            throw new NotImplementedException();
        }

        IList<PushResultRecords> IService<PushResultRecords>.FindAll(PushResultRecords condition)
        {
            throw new NotImplementedException();
        }

        int IService<PushResultRecords>.GetCount(PushResultRecords codition)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteInsert(PushResultRecords t)
        {
            return _pushResultRecordDao.Insert(t);
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(PushResultRecords t)
        {
            throw new NotImplementedException();
        }
    }
}
