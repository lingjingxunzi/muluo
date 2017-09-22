using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using MONO.Distribution.Common;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL.Sys
{
    public class SysUserGroupsDao : DaoBase<SysUserGroups>, ISysUserGroupsDao
    {
        ResultMessage IDao<SysUserGroups>.Insert(SysUserGroups entity)
        {
            try
            {
                object obj = Mapper.Instance().Insert("InsertSysUserGroup", entity);
                _result.Id = int.Parse(obj.ToString());
            }
            catch (Exception ex)
            {

            }
            return _result;
        }

        ResultMessage IDao<SysUserGroups>.Update(SysUserGroups entity)
        {
            try
            {
                Mapper.Instance().Update("UpdateSysUserGroup", entity);

            }
            catch (Exception ex)
            {

            }
            return _result;
        }

        ResultMessage IDao<SysUserGroups>.Delete(int id)
        {
            try
            {
                Mapper.Instance().Delete("DeleteSysUserGroup", id);
            }
            catch (Exception ex)
            {

            }
            return _result;
        }

        SysUserGroups IDao<SysUserGroups>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<SysUserGroups>("SelectSysUserGroupByKey", id);
        }

        IList<SysUserGroups> IDao<SysUserGroups>.FindAll(SysUserGroups condition)
        {
            return Mapper.Instance().QueryForList<SysUserGroups>("SelectSysUserGroupList", condition);
        }

        int IDao<SysUserGroups>.GetCount(SysUserGroups codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectSysUserGroupCount", codition);
        }
    }
}
