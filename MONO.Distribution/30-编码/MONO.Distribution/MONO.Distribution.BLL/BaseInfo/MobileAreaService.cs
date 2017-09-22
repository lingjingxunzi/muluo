using System;
using System.Collections.Generic;
using MONO.Distribution.BLL.Interface.BaseInfo;
using MONO.Distribution.DAL.BaseInfo;
using MONO.Distribution.DAL.Interface.BaseInfo;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.DAL.Sys;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.BaseInfo
{
    public class MobileAreaService : ServiceBase<MobileArea>, IMobileAreaService
    {
        IMobileAreaDao _mobileAreaDao = new MobileAreaDao();

        ResultMessage IService<MobileArea>.Insert(MobileArea entity)
        {
            return base.Insert(entity);
        }

        ResultMessage IService<MobileArea>.Update(MobileArea entity)
        {
            return _mobileAreaDao.Update(entity);
        }

        ResultMessage IService<MobileArea>.Delete(int id)
        {
            return _mobileAreaDao.Delete(id);
        }

        MobileArea IService<MobileArea>.FindById(int id)
        {
            try
            {

                return _mobileAreaDao.FindById(id);

            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return new MobileArea();
            }
        }

        IList<MobileArea> IService<MobileArea>.FindAll(MobileArea condition)
        {
            try
            {

                return _mobileAreaDao.FindAll(condition);

            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return new List<MobileArea>();
            }
        }

        int IService<MobileArea>.GetCount(MobileArea codition)
        {
            try
            {

                return _mobileAreaDao.GetCount(codition);

            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return 0;
            }
        }

        MobileArea IMobileAreaService.SelectMobileAreaByHead(string MobileHead)
        {
            try
            {
                return _mobileAreaDao.SelectMobileAreaByHead(MobileHead);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return new MobileArea();
            }
        }


        IList<string> IMobileAreaService.ExecGetFlowCodeByMobile(MobileArea conditon)
        {
            try
            {

                return _mobileAreaDao.ExecGetFlowCodeByMobile(conditon);

            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return new List<string>();
            }
        }


        string IMobileAreaService.ExecGetMobileFrom(string mobile)
        {
            try
            {
                return _mobileAreaDao.ExecGetMobileFrom(mobile);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return "";
            }
        }

        protected override ResultMessage ExecuteInsert(MobileArea t)
        {
            return _mobileAreaDao.Insert(t);
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new System.NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(MobileArea t)
        {
            throw new System.NotImplementedException();
        }

        protected override ResultMessage BeforeInsert(MobileArea t)
        {
            if (_mobileAreaDao.GetCount(new MobileArea { MobileHead = t.MobileHead }) > 0)
            {
                _resultMessage.Errors.Add(t.MobileHead + "isExists", t.MobileHead + "插入失败。该号码头已存在！");
            }
            return _resultMessage;
        }

        private ResultMessage _resultMessage = new ResultMessage();
        private ISystemLogsDao _systemLogsDao = new SystemLogsDao();
    }
}

