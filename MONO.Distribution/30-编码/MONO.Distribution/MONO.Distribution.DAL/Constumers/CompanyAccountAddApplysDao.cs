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
    public class CompanyAccountAddApplysDao : DaoBase<CompanyAccountAddApplys>, ICompanyAccountAddApplysDao
    {
        ResultMessage IDao<CompanyAccountAddApplys>.Insert(CompanyAccountAddApplys entity)
        {
            try
            {
                object obj =  Mapper.Instance().Insert("InsertCompanyAccountAddApplys", entity);
                _result.Id = int.Parse(obj.ToString());
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<CompanyAccountAddApplys>.Update(CompanyAccountAddApplys entity)
        {
            try
            {
                Mapper.Instance().Update("UpdateCompanyAccountAddApplys", entity);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<CompanyAccountAddApplys>.Delete(int id)
        {
            try
            {
                Mapper.Instance().Delete("DeleteCompanyAccountAddApplys", id);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
            return _result;
        }

        CompanyAccountAddApplys IDao<CompanyAccountAddApplys>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<CompanyAccountAddApplys>("SelectCompanyAccountAddApplysByKey", id);
        }

        IList<CompanyAccountAddApplys> IDao<CompanyAccountAddApplys>.FindAll(CompanyAccountAddApplys condition)
        {
            return Mapper.Instance().QueryForList<CompanyAccountAddApplys>("SelectCompanyAccountAddApplysList", condition);
        }

        int IDao<CompanyAccountAddApplys>.GetCount(CompanyAccountAddApplys codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectCompanyAccountAddApplysCount", codition);
        }
    }
}
