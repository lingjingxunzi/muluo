using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoolShow.Common;
using CoolShow.DAL.Interface.Business;
using CoolShow.Model.Business;
using IBatisNet.DataMapper;

namespace CoolShow.DAL.Business
{
    public class BusinesserBaseInfosDao:IBusinesserBaseInfosDao
    {
       ResultMessage IDao<BusinesserBaseInfos>.Insert(BusinesserBaseInfos entity)
       {
           var result = new ResultMessage();
           var obj = Mapper.Instance().Insert("InsertBusinesserBaseInfo", entity);
           result.Id = int.Parse(obj.ToString());
           return result;
       }

       ResultMessage IDao<BusinesserBaseInfos>.Update(BusinesserBaseInfos entity)
        {
            throw new NotImplementedException();
        }

       ResultMessage IDao<BusinesserBaseInfos>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        BusinesserBaseInfos IDao<BusinesserBaseInfos>.FindById(int id)
        {
            throw new NotImplementedException();
        }

        IList<BusinesserBaseInfos> IDao<BusinesserBaseInfos>.FindAll(BusinesserBaseInfos condition)
        {
            throw new NotImplementedException();
        }

        int IDao<BusinesserBaseInfos>.GetCount(BusinesserBaseInfos codition)
        {
            throw new NotImplementedException();
        }
    }
}
