using System;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using MONO.Distribution.DAL.Interface.BaseInfo;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL.BaseInfo
{
    public class DiscountsMapDao : DaoBase<Discounts>, IDiscountsDao
    {
         
        Discounts IDiscountsDao.SelectDiscountsByDeduction(decimal deduction)
        {
            return Mapper.Instance().QueryForObject<Discounts>("SelectDiscountsByDeduction", deduction);
        }

        ResultMessage IDao<Discounts>.Insert(Discounts entity)
        {
            try
            {
                var obj = Mapper.Instance().Insert("InsertDiscounts", entity);
                _result.Id = int.Parse(obj.ToString());
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                ////AddCreateError("Discounts Insert");
            }
            return _result;
        }

        ResultMessage IDao<Discounts>.Update(Discounts entity)
        {
            try
            {
                Mapper.Instance().Update("UpdateDiscounts", entity);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                //AddUpdateError("Discounts Update");
            }
            return _result;
        }

        ResultMessage IDao<Discounts>.Delete(int id)
        {
            try
            {

            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                //AddDeleteError("Discounts Delete");
            }
            return _result;
        }

        Discounts IDao<Discounts>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<Discounts>("SelectDiscountsByKey", id);
        }

        IList<Discounts> IDao<Discounts>.FindAll(Discounts condition)
        {
            return Mapper.Instance().QueryForList<Discounts>("SelectDiscountsList", condition);
        }

        int IDao<Discounts>.GetCount(Discounts codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectDiscountsCount", codition);
        }
    }
}

