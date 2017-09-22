using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.BLL.Interface.Customers;
using MONO.Distribution.DAL.Constumers;
using MONO.Distribution.DAL.Interface.Constomers;
using MONO.Distribution.Model.Customers;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.Customers
{
    public class CompanyAccountAddApplysService : ServiceBase<CompanyAccountAddApplys>, ICompanyAccountAddApplysService
    {
        ICompanyAccountAddApplysDao _companyAccountAddApplysDao = new CompanyAccountAddApplysDao();
        ResultMessage IService<CompanyAccountAddApplys>.Insert(CompanyAccountAddApplys entity)
        {
            var _results = _companyAccountAddApplysDao.Insert(entity);
            try
            {

                IAccountApplyAttsService _applyAttsService = new AccountApplyAttsService();
                if (entity.AccountApplyAttses != null && entity.AccountApplyAttses.Count > 0)
                {
                    foreach (var item in entity.AccountApplyAttses)
                    {
                        item.AccountAddApplyKey = _results.Id;
                        _applyAttsService.Insert(item);
                    }
                }
            }
            catch (Exception ex)
            {


            }
            return _results;
        }

        ResultMessage IService<CompanyAccountAddApplys>.Update(CompanyAccountAddApplys entity)
        {
            return _companyAccountAddApplysDao.Update(entity);

        }

        ResultMessage IService<CompanyAccountAddApplys>.Delete(int id)
        {
            return _companyAccountAddApplysDao.Delete(id);
        }

        CompanyAccountAddApplys IService<CompanyAccountAddApplys>.FindById(int id)
        {
            return _companyAccountAddApplysDao.FindById(id);
        }

        IList<CompanyAccountAddApplys> IService<CompanyAccountAddApplys>.FindAll(CompanyAccountAddApplys condition)
        {
            return _companyAccountAddApplysDao.FindAll(condition);
        }

        int IService<CompanyAccountAddApplys>.GetCount(CompanyAccountAddApplys codition)
        {
            return _companyAccountAddApplysDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(CompanyAccountAddApplys t)
        {
            return _companyAccountAddApplysDao.Insert(t);
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(CompanyAccountAddApplys t)
        {
            throw new NotImplementedException();
        }


    }
}
