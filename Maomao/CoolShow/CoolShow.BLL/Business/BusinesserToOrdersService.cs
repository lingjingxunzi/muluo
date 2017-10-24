using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoolShow.BLL.Interface.Business;

namespace CoolShow.BLL.Business
{
   public  class BusinesserToOrdersService:IBusinesserToOrdersService
    {
        Common.ResultMessage IService<Model.Business.BusinesserToOrders>.Insert(Model.Business.BusinesserToOrders entity)
        {
            throw new NotImplementedException();
        }

        Common.ResultMessage IService<Model.Business.BusinesserToOrders>.Update(Model.Business.BusinesserToOrders entity)
        {
            throw new NotImplementedException();
        }

        Common.ResultMessage IService<Model.Business.BusinesserToOrders>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Model.Business.BusinesserToOrders IService<Model.Business.BusinesserToOrders>.FindById(int id)
        {
            throw new NotImplementedException();
        }

        IList<Model.Business.BusinesserToOrders> IService<Model.Business.BusinesserToOrders>.FindAll(Model.Business.BusinesserToOrders condition)
        {
            throw new NotImplementedException();
        }

        int IService<Model.Business.BusinesserToOrders>.GetCount(Model.Business.BusinesserToOrders codition)
        {
            throw new NotImplementedException();
        }
    }
}
