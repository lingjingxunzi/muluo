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
    public class CarrierMaintainRecordDao : DaoBase<CarrierMaintainRecords>, ICarrierMaintainRecordDao
    {
        ResultMessage IDao<CarrierMaintainRecords>.Insert(CarrierMaintainRecords entity)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                 
            }
            return _result;
        }

        ResultMessage IDao<CarrierMaintainRecords>.Update(CarrierMaintainRecords entity)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
            return _result;
        }

        ResultMessage IDao<CarrierMaintainRecords>.Delete(int id)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
            return _result;
        }

        CarrierMaintainRecords IDao<CarrierMaintainRecords>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<CarrierMaintainRecords>("", id);
        }

        IList<CarrierMaintainRecords> IDao<CarrierMaintainRecords>.FindAll(CarrierMaintainRecords condition)
        {
            return Mapper.Instance().QueryForList<CarrierMaintainRecords>("SelectMaintainRecordList", condition);
        }

        int IDao<CarrierMaintainRecords>.GetCount(CarrierMaintainRecords codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectMaintainRecordCount", codition);
        }
    }
}
