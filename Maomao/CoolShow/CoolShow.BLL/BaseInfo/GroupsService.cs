using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoolShow.BLL.Interface.BaseInfo;
using CoolShow.DAL.BaseInfo;
using CoolShow.DAL.Interface.BaseInfo;

namespace CoolShow.BLL.BaseInfo
{
   public class GroupsService:IGroupsService
    {
       IGroupsDao _groupsDao = new GroupsDao();
        Common.ResultMessage IService<Model.BaseInfo.Groups>.Insert(Model.BaseInfo.Groups entity)
        {
           return  _groupsDao.Insert(entity);
        }

        Common.ResultMessage IService<Model.BaseInfo.Groups>.Update(Model.BaseInfo.Groups entity)
        {
            return _groupsDao.Update(entity);
        }

        Common.ResultMessage IService<Model.BaseInfo.Groups>.Delete(int id)
        {
            return _groupsDao.Delete(id);
        }

        Model.BaseInfo.Groups IService<Model.BaseInfo.Groups>.FindById(int id)
        {
            return _groupsDao.FindById(id);
        }

        IList<Model.BaseInfo.Groups> IService<Model.BaseInfo.Groups>.FindAll(Model.BaseInfo.Groups condition)
        {
            return _groupsDao.FindAll(condition);
        }

        int IService<Model.BaseInfo.Groups>.GetCount(Model.BaseInfo.Groups codition)
        {
            return _groupsDao.GetCount(codition);
        }
    }
}
