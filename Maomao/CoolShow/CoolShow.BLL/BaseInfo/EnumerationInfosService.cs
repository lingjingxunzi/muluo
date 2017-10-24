using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoolShow.BLL.Interface.BaseInfo;

namespace CoolShow.BLL.BaseInfo
{
    public class EnumerationInfosService:IEnumerationInfosService
    {
        Common.ResultMessage IService<Model.BaseInfo.EnumerationInfos>.Insert(Model.BaseInfo.EnumerationInfos entity)
        {
            throw new NotImplementedException();
        }

        Common.ResultMessage IService<Model.BaseInfo.EnumerationInfos>.Update(Model.BaseInfo.EnumerationInfos entity)
        {
            throw new NotImplementedException();
        }

        Common.ResultMessage IService<Model.BaseInfo.EnumerationInfos>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Model.BaseInfo.EnumerationInfos IService<Model.BaseInfo.EnumerationInfos>.FindById(int id)
        {
            throw new NotImplementedException();
        }

        IList<Model.BaseInfo.EnumerationInfos> IService<Model.BaseInfo.EnumerationInfos>.FindAll(Model.BaseInfo.EnumerationInfos condition)
        {
            throw new NotImplementedException();
        }

        int IService<Model.BaseInfo.EnumerationInfos>.GetCount(Model.BaseInfo.EnumerationInfos codition)
        {
            throw new NotImplementedException();
        }
    }
}
