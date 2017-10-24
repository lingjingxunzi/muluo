using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoolShow.Common;
using CoolShow.DAL.Interface.Business;
using CoolShow.Model.Business;

namespace CoolShow.DAL.Business
{
    public class BusinesserToOrdersDao:IBusinesserToOrdersDao
    {
        ResultMessage IDao<BusinesserToOrders>.Insert(BusinesserToOrders entity)
        {
            throw new NotImplementedException();
        }

        ResultMessage IDao<BusinesserToOrders>.Update(BusinesserToOrders entity)
        {
            throw new NotImplementedException();
        }

        ResultMessage IDao<BusinesserToOrders>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        BusinesserToOrders IDao<BusinesserToOrders>.FindById(int id)
        {
            throw new NotImplementedException();
        }

        IList<BusinesserToOrders> IDao<BusinesserToOrders>.FindAll(BusinesserToOrders condition)
        {
            throw new NotImplementedException();
        }

        int IDao<BusinesserToOrders>.GetCount(BusinesserToOrders codition)
        {
            throw new NotImplementedException();
        }
    }
}
