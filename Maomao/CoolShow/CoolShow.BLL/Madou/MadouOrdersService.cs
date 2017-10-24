using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoolShow.BLL.Interface.Madou;
using CoolShow.Model.Madou;
using CoolShow.DAL.Interface.Madou;
using CoolShow.DAL.Madou;

namespace CoolShow.BLL.Madou
{
   public class MadouOrdersService:IMadouOrdersService
    {
       IMadouOrdersDao _madouOrderDao = new MadouOrdersDao();
        Common.ResultMessage IService<MadouOrders>.Insert(MadouOrders entity)
        {
            return _madouOrderDao.Insert(entity);
        }

        Common.ResultMessage IService<MadouOrders>.Update(MadouOrders entity)
        {
            throw new NotImplementedException();
        }

        Common.ResultMessage IService<MadouOrders>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        MadouOrders IService<MadouOrders>.FindById(int id)
        {
            throw new NotImplementedException();
        }

        IList<MadouOrders> IService<MadouOrders>.FindAll(MadouOrders condition)
        {
            return _madouOrderDao.FindAll(condition);
        }

        int IService<MadouOrders>.GetCount(MadouOrders codition)
        {
            return _madouOrderDao.GetCount(codition);
        }
    }
}
