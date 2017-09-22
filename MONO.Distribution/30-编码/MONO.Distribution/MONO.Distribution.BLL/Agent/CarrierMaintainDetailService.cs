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
    public class CarrierMaintainDetailService : ServiceBase<CarrierMaintainDetails>, ICarrierMaintainDetailService
    { 
        ICarrierMaintainDetailDao _carrierMaintainDetailDao = new CarrierMaintainDetailDao();
        protected override ResultMessage ExecuteInsert(CarrierMaintainDetails t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(CarrierMaintainDetails t)
        {
            throw new NotImplementedException();
        }

        ResultMessage IService<CarrierMaintainDetails>.Insert(CarrierMaintainDetails entity)
        {
            return _carrierMaintainDetailDao.Insert(entity);
        }

        ResultMessage IService<CarrierMaintainDetails>.Update(CarrierMaintainDetails entity)
        {
            return _carrierMaintainDetailDao.Update(entity);
        }

        ResultMessage IService<CarrierMaintainDetails>.Delete(int id)
        {
            return _carrierMaintainDetailDao.Delete(id);
        }

        CarrierMaintainDetails IService<CarrierMaintainDetails>.FindById(int id)
        {
            return _carrierMaintainDetailDao.FindById(id);
        }

        IList<CarrierMaintainDetails> IService<CarrierMaintainDetails>.FindAll(CarrierMaintainDetails condition)
        {
            return _carrierMaintainDetailDao.FindAll(condition);
        }

        int IService<CarrierMaintainDetails>.GetCount(CarrierMaintainDetails codition)
        {
            return _carrierMaintainDetailDao.GetCount(codition);
        }

        CarrierMaintainDetails ICarrierMaintainDetailService.SelectCarrierMaintainDetailsByFlowKey(int key)
        {
            return _carrierMaintainDetailDao.SelectCarrierMaintainDetailsByFlowKey(key);
        }
    }
}
