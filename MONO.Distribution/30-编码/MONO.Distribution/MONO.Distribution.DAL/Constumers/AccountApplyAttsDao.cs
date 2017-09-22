using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using MONO.Distribution.DAL.Interface.Constomers;
using MONO.Distribution.Model.Customers;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL.Constumers
{
    public class AccountApplyAttsDao : DaoBase<AccountApplyAtts>, IAccountApplyAttsDao
    {
        ResultMessage IDao<AccountApplyAtts>.Insert(AccountApplyAtts entity)
        {
            try
            {
                Mapper.Instance().Insert("InsertAccountApplyAtts", entity);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<AccountApplyAtts>.Update(AccountApplyAtts entity)
        {
            try
            {
                Mapper.Instance().Update("UpdateAccountApplyAtts", entity);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<AccountApplyAtts>.Delete(int id)
        {
            try
            {
                Mapper.Instance().Delete("DeleteAccountApplyAtts", id);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
            return _result;
        }

        AccountApplyAtts IDao<AccountApplyAtts>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<AccountApplyAtts>("SelectAccountApplyAttsByKey", id);
        }

        IList<AccountApplyAtts> IDao<AccountApplyAtts>.FindAll(AccountApplyAtts condition)
        {
            return Mapper.Instance().QueryForList<AccountApplyAtts>("SelectAccountApplyAttsList", condition);
        }

        int IDao<AccountApplyAtts>.GetCount(AccountApplyAtts codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectAccountApplyAttsCount", codition);
        }
    }
}
