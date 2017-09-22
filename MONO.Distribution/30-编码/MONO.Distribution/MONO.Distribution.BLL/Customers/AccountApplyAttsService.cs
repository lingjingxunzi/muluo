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
    public class AccountApplyAttsService : ServiceBase<AccountApplyAtts>, IAccountApplyAttsService
    {
        IAccountApplyAttsDao _accountApplyAttsDao = new AccountApplyAttsDao();
        ResultMessage IService<AccountApplyAtts>.Insert(AccountApplyAtts entity)
        {
            return _accountApplyAttsDao.Insert(entity);
        }

        ResultMessage IService<AccountApplyAtts>.Update(AccountApplyAtts entity)
        {
            return _accountApplyAttsDao.Update(entity);
        }

        ResultMessage IService<AccountApplyAtts>.Delete(int id)
        {
            return _accountApplyAttsDao.Delete(id);
        }

        AccountApplyAtts IService<AccountApplyAtts>.FindById(int id)
        {
            return _accountApplyAttsDao.FindById(id);
        }

        IList<AccountApplyAtts> IService<AccountApplyAtts>.FindAll(AccountApplyAtts condition)
        {
            return _accountApplyAttsDao.FindAll(condition);
        }

        int IService<AccountApplyAtts>.GetCount(AccountApplyAtts codition)
        {
            return _accountApplyAttsDao.GetCount(codition);
        }

        protected override Utility.ResultMessage ExecuteInsert(AccountApplyAtts t)
        {
            throw new NotImplementedException();
        }

        protected override Utility.ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override Utility.ResultMessage ExecuteUpdate(AccountApplyAtts t)
        {
            throw new NotImplementedException();
        }
    }
}
