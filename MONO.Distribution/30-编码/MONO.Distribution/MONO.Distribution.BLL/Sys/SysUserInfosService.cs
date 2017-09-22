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
    public class SysUserInfosService : ServiceBase<SysUserInfos>, ISysUserInfosService
    {
        ISysUserInfosDao _sysUserInfosDao =new SysUserInfosDao();
        ResultMessage IService<SysUserInfos>.Insert(SysUserInfos entity)
        {
            return _sysUserInfosDao.Insert(entity);
        }

        ResultMessage IService<SysUserInfos>.Update(SysUserInfos entity)
        {
            return _sysUserInfosDao.Update(entity);
        }

        ResultMessage IService<SysUserInfos>.Delete(int id)
        {
            return _sysUserInfosDao.Delete(id);
        }

        SysUserInfos IService<SysUserInfos>.FindById(int id)
        {
            return _sysUserInfosDao.FindById(id);

        }

        IList<SysUserInfos> IService<SysUserInfos>.FindAll(SysUserInfos condition)
        {
            return _sysUserInfosDao.FindAll(condition);
        }

        int IService<SysUserInfos>.GetCount(SysUserInfos codition)
        {
            return _sysUserInfosDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(SysUserInfos t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(SysUserInfos t)
        {
            throw new NotImplementedException();
        }
    }
}
