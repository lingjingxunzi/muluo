using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoolShow.Common;
using CoolShow.DAL.Interface.Madou;
using CoolShow.Model.Madou;
using IBatisNet.DataMapper;

namespace CoolShow.DAL.Madou
{
    public class MadouOrdersDao:IMadouOrdersDao
    {
        ResultMessage IDao<MadouOrders>.Insert(MadouOrders entity)
        {
            throw new NotImplementedException();
        }

        ResultMessage IDao<MadouOrders>.Update(MadouOrders entity)
        {
            throw new NotImplementedException();
        }

        ResultMessage IDao<MadouOrders>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        MadouOrders IDao<MadouOrders>.FindById(int id)
        {
            throw new NotImplementedException();
        }

        IList<MadouOrders> IDao<MadouOrders>.FindAll(MadouOrders condition)
        {
            return Mapper.Instance().QueryForList<MadouOrders>("",condition);
        }

        int IDao<MadouOrders>.GetCount(MadouOrders codition)
        {
            return Mapper.Instance().QueryForObject<int>("", codition);
        }
    }
}
