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
    public class VerCodeRecordService : ServiceBase<VerCodeRecords>, IVerCodeRecordService
    {
        IVerCodeRecordDao _verCodeRecordDao = new VerCodeRecordsDao();
        ResultMessage IService<VerCodeRecords>.Insert(VerCodeRecords entity)
        {
            return _verCodeRecordDao.Insert(entity);
        }

        ResultMessage IService<VerCodeRecords>.Update(VerCodeRecords entity)
        {
            return _verCodeRecordDao.Update(entity);
        }

        ResultMessage IService<VerCodeRecords>.Delete(int id)
        {
            return _verCodeRecordDao.Delete(id);
        }

        VerCodeRecords IService<VerCodeRecords>.FindById(int id)
        {
            return _verCodeRecordDao.FindById(id);
        }

        IList<VerCodeRecords> IService<VerCodeRecords>.FindAll(VerCodeRecords condition)
        {
            return _verCodeRecordDao.FindAll(condition);
        }

        int IService<VerCodeRecords>.GetCount(VerCodeRecords codition)
        {
            return _verCodeRecordDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(VerCodeRecords t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(VerCodeRecords t)
        {
            throw new NotImplementedException();
        }



        IList<VerCodeRecords> IVerCodeRecordService.SelectVerCodeByIP(string IP)
        {
            return _verCodeRecordDao.SelectVerCodeByIP(IP);
        }


        void IVerCodeRecordService.Delete(string VerCodeKey)
        {
              _verCodeRecordDao.Delete(VerCodeKey);
        }
    }
}
