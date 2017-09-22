using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL.Sys
{
    public class SystemSettingDao : DaoBase<SystemSetting>, ISystemSettingDao
    {
        ResultMessage IDao<SystemSetting>.Insert(SystemSetting entity)
        {
            try
            {
                object obj = Mapper.Instance().Insert("InsertSystemSetting", entity);
            }
            catch (Exception ex)
            {
                AddInsertError("SystemSetting", ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<SystemSetting>.Update(SystemSetting entity)
        {
            try
            {
                Mapper.Instance().Update("UpdateSystemSetting", entity);
            }
            catch (Exception ex)
            {
                AddUpdateError("SystemSetting", ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<SystemSetting>.Delete(int id)
        {
            try
            {
                Mapper.Instance().Delete("DeleteSystemSetting", id);
            }
            catch (Exception ex)
            {
                AddDeleteError("SystemSetting", ex.Message);
            }
            return _result;
        }

        SystemSetting IDao<SystemSetting>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<SystemSetting>("SelectSystemSettingBySysUserKey", id);
        }

        IList<SystemSetting> IDao<SystemSetting>.FindAll(SystemSetting condition)
        {
            return Mapper.Instance().QueryForList<SystemSetting>("SelectSystemSettingList", condition);
        }

        int IDao<SystemSetting>.GetCount(SystemSetting codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectSystemSettingCount", codition);
        }

        SystemSetting ISystemSettingDao.SelectSystemSettingBySysUserKey(int sysUserKey)
        {
            return Mapper.Instance().QueryForObject<SystemSetting>("SelectSystemSettingBySysUserKey", sysUserKey);
        }
    }
}
