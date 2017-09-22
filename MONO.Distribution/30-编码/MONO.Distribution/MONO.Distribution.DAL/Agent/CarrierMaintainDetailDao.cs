using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using MONO.Distribution.DAL.Interface.Agent;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL.Agent
{
    public class CarrierMaintainDetailDao : DaoBase<CarrierMaintainDetails>, ICarrierMaintainDetailDao
    {
        ResultMessage IDao<CarrierMaintainDetails>.Insert(CarrierMaintainDetails entity)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
            return _result;
        }

        ResultMessage IDao<CarrierMaintainDetails>.Update(CarrierMaintainDetails entity)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
            return _result;
        }

        ResultMessage IDao<CarrierMaintainDetails>.Delete(int id)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
            return _result;
        }

        CarrierMaintainDetails IDao<CarrierMaintainDetails>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<CarrierMaintainDetails>("", id);
        }

        IList<CarrierMaintainDetails> IDao<CarrierMaintainDetails>.FindAll(CarrierMaintainDetails condition)
        {
            return Mapper.Instance().QueryForList<CarrierMaintainDetails>("", condition);
        }

        int IDao<CarrierMaintainDetails>.GetCount(CarrierMaintainDetails codition)
        {
            return Mapper.Instance().QueryForObject<int>("", codition);
        }

        CarrierMaintainDetails ICarrierMaintainDetailDao.SelectCarrierMaintainDetailsByFlowKey(int key)
        {
            return Mapper.Instance().QueryForObject<CarrierMaintainDetails>("SelectCarrierMaintainDetailsByFlowKey", key);
        }
    }
}
