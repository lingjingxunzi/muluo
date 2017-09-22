using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Util;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.Common;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.DAL.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.Sys
{
    public class SystemAccountService : ServiceBase<SystemAccount>, ISystemAccountService
    {
        ISystemAccountDao _systemAccountDao = new SystemAccountDao();
        ResultMessage IService<SystemAccount>.Insert(SystemAccount entity)
        {
            return _systemAccountDao.Insert(entity);
        }

        ResultMessage IService<SystemAccount>.Update(SystemAccount entity)
        {
            return _systemAccountDao.Update(entity);
        }

        ResultMessage IService<SystemAccount>.Delete(int id)
        {
            return _systemAccountDao.Delete(id);
        }

        SystemAccount IService<SystemAccount>.FindById(int id)
        {
            BeforeSelect(id);
            return _systemAccountDao.FindById(id);
        }

        IList<SystemAccount> IService<SystemAccount>.FindAll(SystemAccount condition)
        {
            BeforeSelect(condition.SysUserKey);
            return _systemAccountDao.FindAll(condition);
        }

        private void BeforeSelect(int sysUserKey)
        {
            if (_systemAccountDao.FindById(sysUserKey) == null)
            {
                _systemAccountDao.Insert(new SystemAccount { SysUserKey = sysUserKey, LeftAccount = 0, TotalAccount = 0 });
            }
        }

        int IService<SystemAccount>.GetCount(SystemAccount codition)
        {
            return _systemAccountDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(SystemAccount t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(SystemAccount t)
        {
            throw new NotImplementedException();
        }



        ResultMessage ISystemAccountService.SystemAccountChange(int systemKey, string transNo, decimal charges, string chargeType)
        {
            SystemAccount systemAccount = _systemAccountDao.SelectSystemAccountByUserKey(systemKey);
            var result = new ResultMessage();
            if (systemAccount == null)
            {
                var insertResult =
                    _systemAccountDao.Insert(new SystemAccount
                    {
                        SysUserKey = systemKey,
                        LeftAccount = 0,
                        TotalAccount = 0
                    });
                systemAccount = _systemAccountDao.SelectSystemAccountByUserKey(systemKey);
            }
            if (charges <= 0 && systemAccount.LeftAccount + systemAccount.OverDraft + charges < 0)
            {
                result.Errors.Add(Guid.NewGuid().ToString(), "账户余额不足！");
                return result;
            }
            var log = new SystemAccountLog
            {
                AccountLogKey = Guid.NewGuid(),
                BeforeIntegral = 0,
                AfterIntegral = 0,
                CompanyAccountKey = systemAccount.CompanyAccountKey,
                Integral = charges,
                OperaType = chargeType,
                Seq = transNo
            };
            var logResult = _systemAccountLogDao.Insert(log);
            if (logResult.IsOk)
            {
                return result;
            }
            else
            {
                return logResult;
            }

        }




        SystemAccount ISystemAccountService.SelectSystemAccountByUserKey(int SysUserKey)
        {
            return _systemAccountDao.SelectSystemAccountByUserKey(SysUserKey);
        }

        private ISystemAccountLogDao _systemAccountLogDao = new SystemAccountLogDao();


        ResultMessage ISystemAccountService.ExecUpdateCompanyAccount(SystemAccount condition)
        {
            return _systemAccountDao.ExecUpdateCompanyAccount(condition);
        }


        void ISystemAccountService.UpdateSystemAccountForBond(SystemAccount condition)
        {
            _systemAccountDao.UpdateSystemAccountForBond(condition);
        }

        void ISystemAccountService.UpdateSystemAccountForDraft(SystemAccount condition)
        {
            _systemAccountDao.UpdateSystemAccountForDraft(condition);
        }
    }
}
