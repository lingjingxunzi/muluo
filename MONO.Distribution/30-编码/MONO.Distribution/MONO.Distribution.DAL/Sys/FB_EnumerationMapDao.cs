using System;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using MONO.Distribution.Common;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL.Sys
{
    public class EnumerationMapDao : DaoBase<Enumerations>, IEnumerationDao
    {


        Enumerations IEnumerationDao.FindById(string key)
        {
            return Mapper.Instance().QueryForObject<Enumerations>("SelectEnumerationByKey", key);
        }

        ResultMessage IDao<Enumerations>.Insert(Enumerations entity)
        {
            try
            {
                Mapper.Instance().Insert("InsertEnumeration", entity);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                ////AddCreateError("Enumeration Insert");
            }
            return _result;
        }

        ResultMessage IDao<Enumerations>.Update(Enumerations entity)
        {
            try
            {
                int i = Mapper.Instance().Update("UpdateEnumeration", entity);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                //AddUpdateError("Enumeration UpdateError");
            }
            return _result;
        }

        ResultMessage IDao<Enumerations>.Delete(int id)
        {
            try
            {

            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                //AddDeleteError("Enumeration DeleteError");
            }
            return _result;
        }

        Enumerations IDao<Enumerations>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<Enumerations>("SelectEnumerationByKey", id);
        }

        System.Collections.Generic.IList<Enumerations> IDao<Enumerations>.FindAll(Enumerations condition)
        {
            return Mapper.Instance().QueryForList<Enumerations>("SelectEnumerationList", condition);
        }

        int IDao<Enumerations>.GetCount(Enumerations codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectEnumerationCount", codition);
        }


        IList<Enumerations> IEnumerationDao.SelectEnumerationsByTypeName(string name)
        {
            return Mapper.Instance().QueryForList<Enumerations>("SelectEnumerationsByTypeName", name);
        }


        IList<Enumerations> IEnumerationDao.SelectEnumerationByCarriers(string name)
        {
            return Mapper.Instance().QueryForList<Enumerations>("SelectEnumerationByCarriers", name);
        }
    }
}

