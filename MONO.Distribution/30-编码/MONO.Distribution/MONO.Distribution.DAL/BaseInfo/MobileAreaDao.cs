using System;
using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using MONO.Distribution.DAL.Interface.BaseInfo;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL.BaseInfo
{
    public class MobileAreaDao : DaoBase<MobileArea>, IMobileAreaDao
    {
        ResultMessage IDao<MobileArea>.Insert(MobileArea entity)
        {
            try
            {

                object id = Mapper.Instance().Insert("InsertMobileArea", entity);
                _result.Id = Int32.Parse(id.ToString());

            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                //AddCreateError("MobileArea Insert");
            }
            return _result;
        }

        ResultMessage IDao<MobileArea>.Update(MobileArea entity)
        {
            try
            {
                int i = Mapper.Instance().Update("UpdateMobileArea", entity);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                //AddUpdateError("MobileArea Update");
            }
            return _result;
        }

        ResultMessage IDao<MobileArea>.Delete(int id)
        {
            try
            {

            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                //AddDeleteError("MobileArea Delete");
            }
            return _result;
        }

        MobileArea IDao<MobileArea>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<MobileArea>("SelectMobileAreaByKey", id);
        }

        IList<MobileArea> IDao<MobileArea>.FindAll(MobileArea condition)
        {
            return Mapper.Instance().QueryForList<MobileArea>("SelectMobileAreaList", condition);
        }

        int IDao<MobileArea>.GetCount(MobileArea codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectMobileAreaCount", codition);
        }

        MobileArea IMobileAreaDao.SelectMobileAreaByHead(string MobileHead)
        {
            return Mapper.Instance().QueryForObject<MobileArea>("SelectMobileAreaByHead", MobileHead);
        }


        IList<string> IMobileAreaDao.ExecGetFlowCodeByMobile(MobileArea conditon)
        {
            var ht = new Hashtable { { "mobile", conditon.MobileHead }, { "flowKey", conditon.flowKey } };
            return Mapper.Instance().QueryForList<string>("ExecGetFlowCodeByMobile104", ht);
        }


        string IMobileAreaDao.ExecGetMobileFrom(string mobile)
        {
            var ht = new Hashtable { { "mobile", mobile } };
            return Mapper.Instance().QueryForObject<string>("ExecGetMobileFrom", ht);
        }
    }
}

