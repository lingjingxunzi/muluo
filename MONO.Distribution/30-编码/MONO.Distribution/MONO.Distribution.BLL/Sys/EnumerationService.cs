using System;
using System.Collections.Generic;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.Common;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.DAL.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.Sys
{
    public class EnumerationService : ServiceBase<Enumerations>, IEnumerationService
    {

        private ResultMessage _result = new ResultMessage();
        readonly IEnumerationDao _enumerationDao = new EnumerationMapDao();
        ResultMessage IService<Enumerations>.Insert(Enumerations entity)
        {
            return base.Insert(entity);
        }

        ResultMessage IService<Enumerations>.Update(Enumerations entity)
        {
            return base.Update(entity);
        }

        ResultMessage IService<Enumerations>.Delete(int id)
        {
            return _enumerationDao.Delete(id);
        }

        Enumerations IService<Enumerations>.FindById(int id)
        {
            try
            {
                return _enumerationDao.FindById(id);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return new Enumerations();
            }
        }

        IList<Enumerations> IService<Enumerations>.FindAll(Enumerations condition)
        {
            try
            {
                return _enumerationDao.FindAll(condition);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return new List<Enumerations>();
            }
        }

        int IService<Enumerations>.GetCount(Enumerations codition)
        {
            try
            {
                return _enumerationDao.GetCount(codition);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return 0;
            }
        }

        protected override ResultMessage ExecuteInsert(Enumerations t)
        {
            return _enumerationDao.Insert(t);
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            return _enumerationDao.Delete(id);
        }

        protected override ResultMessage ExecuteUpdate(Enumerations t)
        {
            return _enumerationDao.Update(t);
        }

        protected override ResultMessage BeforeInsert(Enumerations t)
        {
            try
            {
                if (_enumerationDao.GetCount(t) > 0)
                {
                    _result.Errors.Add("EnumNameIsExists", "字典类型名称已存在！");
                }
                return _result;
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return _result;
            }
        }

        Enumerations IEnumerationService.FindById(string key)
        {
            try
            {
                return _enumerationDao.FindById(key);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return new Enumerations();
            }
        }


        IList<Enumerations> IEnumerationService.SelectEnumerationsByTypeName(string name)
        {
            try
            {
                return _enumerationDao.SelectEnumerationsByTypeName(name);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return new List<Enumerations>();
            }
        }


        IList<Enumerations> IEnumerationService.SelectEnumerationByCarriers(string name)
        {
            return _enumerationDao.SelectEnumerationByCarriers(name);
        }
    }
}

