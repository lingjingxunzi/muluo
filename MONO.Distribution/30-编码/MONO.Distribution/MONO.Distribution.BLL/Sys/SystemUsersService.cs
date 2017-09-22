using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.Common;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.DAL.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.Sys
{
    public class SystemUsersService : ServiceBase<SystemUsers>, ISystemUsersService
    {
        ISystemUsersDao _systemUsersDao = new SystemUsersDao();
        ResultMessage IService<SystemUsers>.Insert(SystemUsers entity)
        {
            return base.Insert(entity);
        }

        ResultMessage IService<SystemUsers>.Update(SystemUsers entity)
        {
            return _systemUsersDao.Update(entity);
        }

        ResultMessage IService<SystemUsers>.Delete(int id)
        {
            return _systemUsersDao.Delete(id);
        }

        SystemUsers IService<SystemUsers>.FindById(int id)
        {
            return _systemUsersDao.FindById(id);
        }

        IList<SystemUsers> IService<SystemUsers>.FindAll(SystemUsers condition)
        {
            return _systemUsersDao.FindAll(condition);
        }

        int IService<SystemUsers>.GetCount(SystemUsers codition)
        {
            return _systemUsersDao.GetCount(codition);
        }

        SystemUsers ISystemUsersService.Login(string account, string pwd)
        {
            var list = _systemUsersDao.FindAll(new SystemUsers { DisAccount = account, PWD = pwd, IsStartPager = false, StartRecordIndex = 0, EndRecordIndex = 0, Flag = 0 });
            return list.Count == 0 ? null : list[0];
        }

        protected override ResultMessage ExecuteInsert(SystemUsers t)
        {
            return _systemUsersDao.Insert(t);
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(SystemUsers t)
        {
            throw new NotImplementedException();
        }




        SystemUsers ISystemUsersService.SelectByAccount(string userAccount)
        {
            return _systemUsersDao.SelectByAccount(userAccount);
        }


        IList<int> ISystemUsersService.SelectSystemChildrensKey(SystemUsers systemUsers)
        {
            return _systemUsersDao.SelectSystemChildrensKey(systemUsers);
        }


        IList<SystemUsers> ISystemUsersService.SelectSystemChildrensKeyForAllInfo(SystemUsers systemUsers)
        {
            return _systemUsersDao.SelectSystemChildrensKeyForAllInfo(systemUsers);
        }

        protected override ResultMessage BeforeInsert(SystemUsers t)
        {
            var result = new ResultMessage();
            if (string.IsNullOrEmpty(t.Account))
            {
                result.Errors.Add(Guid.NewGuid().ToString(), "帐号不能为空！");
                return result;
            }
            if (_systemUsersDao.SelectByAccount(t.Account) != null)
            {
                result.Errors.Add(Guid.NewGuid().ToString(), "帐号不能添加，已存在！");
                return result;
            }
            return result;
        }


        IList<SystemUsers> ISystemUsersService.SelectSystemUserListForReport(SystemUsers condition)
        {
            return _systemUsersDao.SelectSystemUserListForReport(condition);
        }

        int ISystemUsersService.SelectSystemUserCountForReport(SystemUsers condition)
        {
            return _systemUsersDao.SelectSystemUserCountForReport(condition);
        }


        void ISystemUsersService.UpdateSystemUserCode(SystemUsers condition)
        {
            _systemUsersDao.UpdateSystemUserCode(condition);
        }


        IList<SystemUsers> ISystemUsersService.SelectSystemUserListForMonthReport(SystemUsers condition)
        {
            return _systemUsersDao.SelectSystemUserListForMonthReport(condition);
        }


        IList<decimal> ISystemUsersService.SelectSystemUserListForMonthList(SystemUsers condition)
        {
            return _systemUsersDao.SelectSystemUserListForMonthList(condition);
        }


        IList<string> ISystemUsersService.SelectDateForEveryDate(SystemUsers condition)
        {
            return _systemUsersDao.SelectDateForEveryDate(condition);
        }
    }
}
