using System;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL.Sys
{
    public class FB_BusinessIPBindDao :DaoBase<BusinessIPBind>, IBusinessIPBindDao
    {

        ResultMessage IDao<BusinessIPBind>.Insert(BusinessIPBind entity)
        {
            try
            {
                object obj = Mapper.Instance().Insert("InsertBusinessIP", entity);
                _result.Id = int.Parse(obj.ToString());
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                ////AddCreateError("FB_BusinessIPBind Insert Error");
                 
            }
            return _result;
        }

        ResultMessage IDao<BusinessIPBind>.Update(BusinessIPBind entity)
        {
            try
            {
                Mapper.Instance().Update("UpdateBusinessIP", entity);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                //AddUpdateError("FB_BusinessIPBind Update Error");
                 
            }
            return _result;
        }

        ResultMessage IDao<BusinessIPBind>.Delete(int id)
        {
            try
            {
                Mapper.Instance().Delete("DeleteBusinessIP", id);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                //AddDeleteError("FB_BusinessIPBind delete error");
            }
            return _result;
        }

        BusinessIPBind IDao<BusinessIPBind>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<BusinessIPBind>("SelectBusinessIPByKey", id);
        }

        IList<BusinessIPBind> IDao<BusinessIPBind>.FindAll(BusinessIPBind condition)
        {
            return Mapper.Instance().QueryForList<BusinessIPBind>("SelectBusinessIPList", condition);
        }

        int IDao<BusinessIPBind>.GetCount(BusinessIPBind codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectBusinessIPCount", codition);
        }
    }
}
