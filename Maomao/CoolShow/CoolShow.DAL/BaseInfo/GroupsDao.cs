using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoolShow.DAL.Interface.BaseInfo;

namespace CoolShow.DAL.BaseInfo
{
    public class GroupsDao:IGroupsDao
    {
        Common.ResultMessage IDao<Model.BaseInfo.Groups>.Insert(Model.BaseInfo.Groups entity)
        {
            throw new NotImplementedException();
        }

        Common.ResultMessage IDao<Model.BaseInfo.Groups>.Update(Model.BaseInfo.Groups entity)
        {
            throw new NotImplementedException();
        }

        Common.ResultMessage IDao<Model.BaseInfo.Groups>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Model.BaseInfo.Groups IDao<Model.BaseInfo.Groups>.FindById(int id)
        {
            throw new NotImplementedException();
        }

        IList<Model.BaseInfo.Groups> IDao<Model.BaseInfo.Groups>.FindAll(Model.BaseInfo.Groups condition)
        {
            throw new NotImplementedException();
        }

        int IDao<Model.BaseInfo.Groups>.GetCount(Model.BaseInfo.Groups codition)
        {
            throw new NotImplementedException();
        }
    }
}
