using System;
using System.Collections.Generic;
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
    public class RechargeRecordsService : ServiceBase<RechargeRecords>, IRechargeRecordsService
    {
        IRechargeRecordsDao _rechargeRecordsDao = new RechargeRecordsDao();
        ResultMessage IService<RechargeRecords>.Insert(RechargeRecords entity)
        {
            return _rechargeRecordsDao.Insert(entity);
        }

        ResultMessage IService<RechargeRecords>.Update(RechargeRecords entity)
        {
            return _rechargeRecordsDao.Update(entity);
        }

        ResultMessage IService<RechargeRecords>.Delete(int id)
        {
            return _rechargeRecordsDao.Delete(id);
        }

        RechargeRecords IService<RechargeRecords>.FindById(int id)
        {
            return _rechargeRecordsDao.FindById(id);
        }

        IList<RechargeRecords> IService<RechargeRecords>.FindAll(RechargeRecords condition)
        {
            return _rechargeRecordsDao.FindAll(condition);
        }

        int IService<RechargeRecords>.GetCount(RechargeRecords codition)
        {
            return _rechargeRecordsDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(RechargeRecords t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(RechargeRecords t)
        {
            throw new NotImplementedException();
        }

        RechargeRecords IRechargeRecordsService.FindById(string RechargeKey)
        {
            return _rechargeRecordsDao.FindById(RechargeKey);
        }
    }
}
