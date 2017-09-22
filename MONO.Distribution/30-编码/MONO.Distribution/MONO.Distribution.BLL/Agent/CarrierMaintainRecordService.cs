using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.DAL.Agent;
using MONO.Distribution.DAL.Interface.Agent;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.Agent
{
    public class CarrierMaintainRecordService : ServiceBase<CarrierMaintainRecords>, ICarrierMaintainRecordService
    {
        ICarrierMaintainRecordDao _carrierMaintainRecordDao = new CarrierMaintainRecordDao();
        ResultMessage IService<CarrierMaintainRecords>.Insert(CarrierMaintainRecords entity)
        {
            return _carrierMaintainRecordDao.Insert(entity);
        }

        ResultMessage IService<CarrierMaintainRecords>.Update(CarrierMaintainRecords entity)
        {
            return _carrierMaintainRecordDao.Update(entity);
        }

        ResultMessage IService<CarrierMaintainRecords>.Delete(int id)
        {
            return _carrierMaintainRecordDao.Delete(id);
        }

        CarrierMaintainRecords IService<CarrierMaintainRecords>.FindById(int id)
        {
            return _carrierMaintainRecordDao.FindById(id);
        }

        IList<CarrierMaintainRecords> IService<CarrierMaintainRecords>.FindAll(CarrierMaintainRecords condition)
        {
            return _carrierMaintainRecordDao.FindAll(condition);
        }

        int IService<CarrierMaintainRecords>.GetCount(CarrierMaintainRecords codition)
        {
            return _carrierMaintainRecordDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(CarrierMaintainRecords t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(CarrierMaintainRecords t)
        {
            throw new NotImplementedException();
        }
    }
}
