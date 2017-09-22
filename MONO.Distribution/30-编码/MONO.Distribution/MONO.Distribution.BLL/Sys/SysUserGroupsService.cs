using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.Common;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.DAL.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.Sys
{
    public class SysUserGroupsService : ServiceBase<SysUserGroups>, ISysUserGroupsService 
    {
        ISysUserGroupsDao _sysUserGroupsDao = new SysUserGroupsDao();
        ResultMessage IService<SysUserGroups>.Insert(SysUserGroups entity)
        {
            return _sysUserGroupsDao.Insert(entity);
        }

        ResultMessage IService<SysUserGroups>.Update(SysUserGroups entity)
        {
            return _sysUserGroupsDao.Update(entity);
        }

        ResultMessage IService<SysUserGroups>.Delete(int id)
        {
            return _sysUserGroupsDao.Delete(id);
        }

        SysUserGroups IService<SysUserGroups>.FindById(int id)
        {
            return _sysUserGroupsDao.FindById(id);
        }

        IList<SysUserGroups> IService<SysUserGroups>.FindAll(SysUserGroups condition)
        {
            return _sysUserGroupsDao.FindAll(condition);
        }

        int IService<SysUserGroups>.GetCount(SysUserGroups codition)
        {
            return _sysUserGroupsDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(SysUserGroups t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(SysUserGroups t)
        {
            throw new NotImplementedException();
        }
    }
}
