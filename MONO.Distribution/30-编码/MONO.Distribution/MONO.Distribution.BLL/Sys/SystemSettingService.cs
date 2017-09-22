using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.DAL.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.Sys
{
    public class SystemSettingService : ServiceBase<SystemSetting>, ISystemSettingService
    {
        ISystemSettingDao _systemSettingDao = new SystemSettingDao();
        ResultMessage IService<SystemSetting>.Insert(SystemSetting entity)
        {
            return _systemSettingDao.Insert(entity);
        }

        ResultMessage IService<SystemSetting>.Update(SystemSetting entity)
        {
            return _systemSettingDao.Insert(entity);
        }

        ResultMessage IService<SystemSetting>.Delete(int id)
        {
            return _systemSettingDao.Delete(id);
        }

        SystemSetting IService<SystemSetting>.FindById(int id)
        {
            return _systemSettingDao.FindById(id);
        }

        IList<SystemSetting> IService<SystemSetting>.FindAll(SystemSetting condition)
        {
            return _systemSettingDao.FindAll(condition);
        }

        int IService<SystemSetting>.GetCount(SystemSetting codition)
        {
            return _systemSettingDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(SystemSetting t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(SystemSetting t)
        {
            throw new NotImplementedException();
        }

        SystemSetting ISystemSettingService.SelectSystemSettingBySysUserKey(int sysUserKey)
        {
            return _systemSettingDao.SelectSystemSettingBySysUserKey(sysUserKey);
        }
    }
}
