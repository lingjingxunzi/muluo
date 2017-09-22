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
    public class MenusService : ServiceBase<Menus>, IMenusService
    {
        IMenusDao _menusDao = new MenusDao();
        ResultMessage IService<Menus>.Insert(Menus entity)
        {
            return _menusDao.Insert(entity);
        }

        ResultMessage IService<Menus>.Update(Menus entity)
        {
            return _menusDao.Update(entity);
        }

        ResultMessage IService<Menus>.Delete(int id)
        {
            return _menusDao.Delete(id);
        }

        Menus IService<Menus>.FindById(int id)
        {
            return _menusDao.FindById(id);
        }

        IList<Menus> IService<Menus>.FindAll(Menus condition)
        {
            return _menusDao.FindAll(condition);
        }

        int IService<Menus>.GetCount(Menus codition)
        {
            return _menusDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(Menus t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(Menus t)
        {
            throw new NotImplementedException();
        }

        IList<Menus> IMenusService.SelectMenuByUserKey(int SysUserKey)
        {
            return _menusDao.SelectMenuByUserKey(SysUserKey);
        }
    }
}
