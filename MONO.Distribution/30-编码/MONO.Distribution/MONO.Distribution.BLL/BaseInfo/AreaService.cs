using System;
using System.Collections.Generic;
using MONO.Distribution.BLL.Interface.BaseInfo;
using MONO.Distribution.DAL.BaseInfo;
using MONO.Distribution.DAL.Interface.BaseInfo;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.BaseInfo
{
    public class AreasService : ServiceBase<AreasService>, IAreaService
    {
        IAreasDao _areaDao = new AreasDao();
        ResultMessage IService<Areas>.Insert(Areas entity)
        {
            return _areaDao.Insert(entity);
        }

        ResultMessage IService<Areas>.Update(Areas entity)
        {
            return _areaDao.Update(entity);
        }

        ResultMessage IService<Areas>.Delete(int id)
        {
            return _areaDao.Delete(id);
        }

        Areas IService<Areas>.FindById(int id)
        {
            try
            {
                return _areaDao.FindById(id);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return new Areas();
            }
        }

        IList<Areas> IService<Areas>.FindAll(Areas condition)
        {
            try
            {

                return _areaDao.FindAll(condition);

            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return new List<Areas>();
            }
        }

        int IService<Areas>.GetCount(Areas codition)
        {
            try
            {
                return _areaDao.GetCount(codition);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return 0;
            }
        }

        protected override ResultMessage ExecuteInsert(AreasService t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(AreasService t)
        {
            throw new NotImplementedException();
        }
    }
}
