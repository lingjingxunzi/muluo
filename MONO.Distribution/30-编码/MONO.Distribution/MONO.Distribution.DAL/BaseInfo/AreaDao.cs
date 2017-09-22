using System;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using MONO.Distribution.DAL.Interface.BaseInfo;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL.BaseInfo
{
    public class AreasDao :DaoBase<Areas>, IAreasDao
    {
        
        ResultMessage IDao<Areas>.Insert(Areas entity)
        {
            try
            {
                var id = Mapper.Instance().Insert("InsertArea", entity);
                _result.Id = int.Parse(id.ToString());
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                ////AddCreateError("Areas Insert Err");
            }
            return _result;
        }

        ResultMessage IDao<Areas>.Update(Areas entity)
        {
            try
            {
                Mapper.Instance().Update("UpdateArea", entity);
                
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                //AddUpdateError("Areas Update Err");
            }
            return _result;
        }

        ResultMessage IDao<Areas>.Delete(int id)
        {
            try
            {
                 
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                //AddUpdateError("Areas Delete Err");
            }
            return _result;
        }

        Areas IDao<Areas>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<Areas>("SelectAreaByKey", id);
        }

        IList<Areas> IDao<Areas>.FindAll(Areas condition)
        {
            return Mapper.Instance().QueryForList<Areas>("SelectAreaList", condition);
        }

        int IDao<Areas>.GetCount(Areas codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectAreaCount", codition);
        }
    }
}
