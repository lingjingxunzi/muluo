using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoolShow.DAL.Interface.BaseInfo;

namespace CoolShow.DAL.BaseInfo
{
    public class EnumerationInfosDao:IEnumerationInfosDao
    {
        Common.ResultMessage IDao<Model.BaseInfo.EnumerationInfos>.Insert(Model.BaseInfo.EnumerationInfos entity)
        {
            throw new NotImplementedException();
        }

        Common.ResultMessage IDao<Model.BaseInfo.EnumerationInfos>.Update(Model.BaseInfo.EnumerationInfos entity)
        {
            throw new NotImplementedException();
        }

        Common.ResultMessage IDao<Model.BaseInfo.EnumerationInfos>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Model.BaseInfo.EnumerationInfos IDao<Model.BaseInfo.EnumerationInfos>.FindById(int id)
        {
            throw new NotImplementedException();
        }

        IList<Model.BaseInfo.EnumerationInfos> IDao<Model.BaseInfo.EnumerationInfos>.FindAll(Model.BaseInfo.EnumerationInfos condition)
        {
            throw new NotImplementedException();
        }

        int IDao<Model.BaseInfo.EnumerationInfos>.GetCount(Model.BaseInfo.EnumerationInfos codition)
        {
            throw new NotImplementedException();
        }
    }
}
