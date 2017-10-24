using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoolShow.BLL.Interface.Business;
using CoolShow.Common;
using CoolShow.DAL.Business;
using CoolShow.DAL.Interface.Business;
using CoolShow.Model.Business;

namespace CoolShow.BLL.Business
{
    public class BusinesserBaseInfosService:IBusinesserBaseInfosService
    {
        IBusinesserBaseInfosDao _businesserBaseInfosDao = new BusinesserBaseInfosDao();
        ResultMessage IService<BusinesserBaseInfos>.Insert(BusinesserBaseInfos entity)
        {
            return _businesserBaseInfosDao.Insert(entity);
        }

        ResultMessage IService<BusinesserBaseInfos>.Update(BusinesserBaseInfos entity)
        {
            throw new NotImplementedException();
        }

        ResultMessage IService<BusinesserBaseInfos>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        BusinesserBaseInfos IService<BusinesserBaseInfos>.FindById(int id)
        {
            throw new NotImplementedException();
        }

        IList<BusinesserBaseInfos> IService<BusinesserBaseInfos>.FindAll(BusinesserBaseInfos condition)
        {
            throw new NotImplementedException();
        }

        int IService<BusinesserBaseInfos>.GetCount(BusinesserBaseInfos codition)
        {
            throw new NotImplementedException();
        }
    }
}
