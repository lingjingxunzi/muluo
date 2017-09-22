using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using MONO.Distribution.Common;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL.Sys
{
    public class SystemAccountDao : DaoBase<SystemAccount>, ISystemAccountDao
    {
        ResultMessage IDao<SystemAccount>.Insert(SystemAccount entity)
        {
            try
            {
                object obj = Mapper.Instance().Insert("InsertSystemAccount", entity);
                _result.Id = int.Parse(obj.ToString());
            }
            catch (Exception ex)
            {
                AddInsertError("SystemAccount", ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<SystemAccount>.Update(SystemAccount entity)
        {
            try
            {
                object obj = Mapper.Instance().Update("UpdateSystemAccount", entity);
                _result.Id = int.Parse(obj.ToString());
            }
            catch (Exception ex)
            {
                AddUpdateError("SystemAccount", ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<SystemAccount>.Delete(int id)
        {
            try
            {
                object obj = Mapper.Instance().Delete("DeleteSystemAccount", id);
                _result.Id = int.Parse(obj.ToString());
            }
            catch (Exception ex)
            {
                AddDeleteError("SystemAccount", ex.Message);
            }
            return _result;
        }

        SystemAccount IDao<SystemAccount>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<SystemAccount>("SelectSystemAccountByKey", id);
        }

        IList<SystemAccount> IDao<SystemAccount>.FindAll(SystemAccount condition)
        {
            return Mapper.Instance().QueryForList<SystemAccount>("SelectSystemAccountList", condition);
        }

        int IDao<SystemAccount>.GetCount(SystemAccount codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectSystemAccountCount", codition);
        }

        SystemAccount ISystemAccountDao.SelectSystemAccountByUserKey(int SysUserKey)
        {
            return Mapper.Instance().QueryForObject<SystemAccount>("SelectSystemAccountByUserKey", SysUserKey);
        }




        ResultMessage ISystemAccountDao.ExecUpdateCompanyAccount(SystemAccount condition)
        {
            try
            {
                var re = Mapper.Instance().QueryForObject<int>("ExecUpdateCompanyAccount", condition);
            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(),ex.Message);
            }
            return _result;
        }


        void ISystemAccountDao.UpdateSystemAccountForBond(SystemAccount condition)
        {
            try
            {
                Mapper.Instance().Update("UpdateSystemAccountForBond", condition);
            }
            catch (Exception ex)
            {
                
                
            }
        }

        void ISystemAccountDao.UpdateSystemAccountForDraft(SystemAccount condition)
        {
            try
            {
                Mapper.Instance().Update("UpdateSystemAccountForDraft", condition);
            }
            catch (Exception ex)
            {


            }
        }
    }
}
