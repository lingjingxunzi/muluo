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
    public class MenuGroupsService : ServiceBase<MenuGroups>, IMenuGroupsService
    {
        IMenuGroupsDao _menuGroupsDao = new MenuGroupsDao();
        ResultMessage IService<MenuGroups>.Insert(MenuGroups entity)
        {
            return _menuGroupsDao.Insert(entity);
        }

        ResultMessage IService<MenuGroups>.Update(MenuGroups entity)
        {
            return _menuGroupsDao.Update(entity);
        }

        ResultMessage IService<MenuGroups>.Delete(int id)
        {
            return _menuGroupsDao.Delete(id);
        }

        MenuGroups IService<MenuGroups>.FindById(int id)
        {
            return _menuGroupsDao.FindById(id);
        }

        IList<MenuGroups> IService<MenuGroups>.FindAll(MenuGroups condition)
        {
            return _menuGroupsDao.FindAll(condition);
        }

        int IService<MenuGroups>.GetCount(MenuGroups codition)
        {
            return _menuGroupsDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(MenuGroups t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(MenuGroups t)
        {
            throw new NotImplementedException();
        }
    }
}
