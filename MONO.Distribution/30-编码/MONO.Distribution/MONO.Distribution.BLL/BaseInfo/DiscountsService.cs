using System;
using System.Collections.Generic;
using MONO.Distribution.BLL.Interface.BaseInfo;
using MONO.Distribution.DAL.BaseInfo;
using MONO.Distribution.DAL.Interface.BaseInfo;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.BaseInfo
{
    public class DiscountsService : ServiceBase<Discounts>, IDiscountsService
    {

        IDiscountsDao _discountsDao = new DiscountsMapDao();
        ResultMessage IService<Discounts>.Insert(Discounts entity)
        {
            return _discountsDao.Insert(entity);
        }

        ResultMessage IService<Discounts>.Update(Discounts entity)
        {
            return _discountsDao.Update(entity);
        }

        ResultMessage IService<Discounts>.Delete(int id)
        {
            return _discountsDao.Delete(id);
        }

        Discounts IService<Discounts>.FindById(int id)
        {
            try
            {
                return _discountsDao.FindById(id);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return new Discounts();
            }
        }

        IList<Discounts> IService<Discounts>.FindAll(Discounts condition)
        {
            try
            {
                return _discountsDao.FindAll(condition);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return new List<Discounts>();
            }
        }

        int IService<Discounts>.GetCount(Discounts codition)
        {
            try
            {
                return _discountsDao.GetCount(codition);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return 0;
            }
        }

        protected override ResultMessage ExecuteInsert(Discounts t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(Discounts t)
        {
            throw new NotImplementedException();
        }

        Discounts IDiscountsService.SelectDiscountsByDeduction(decimal deduction)
        {
            BeforeSelection(deduction);
            return _discountsDao.SelectDiscountsByDeduction(deduction);
        }

        private void BeforeSelection(decimal deduction)
        {
            if (_discountsDao.SelectDiscountsByDeduction(deduction) == null)
            {
                _discountsDao.Insert(new Discounts { Deduction = deduction, Status = "0" });
            }
        }
    }
}

