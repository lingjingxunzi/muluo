using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using MONO.Distribution.Common;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL.Sys
{
    public class SystemUsersDao : DaoBase<SystemUsers>, ISystemUsersDao
    {
        ResultMessage IDao<SystemUsers>.Insert(SystemUsers entity)
        {
            try
            {
                object obj = Mapper.Instance().Insert("InsertSystemUser", entity);
                _result.Id = int.Parse(obj.ToString());
            }
            catch (Exception ex)
            {

            }
            return _result;
        }

        ResultMessage IDao<SystemUsers>.Update(SystemUsers entity)
        {
            try
            {
                Mapper.Instance().Update("UpdateSystemUser", entity);
            }
            catch (Exception ex)
            {

            }
            return _result;
        }

        ResultMessage IDao<SystemUsers>.Delete(int id)
        {
            try
            {
                Mapper.Instance().Delete("DeleteSystemUser", id);

            }
            catch (Exception ex)
            {

            }
            return _result;
        }

        SystemUsers IDao<SystemUsers>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<SystemUsers>("SelectSystemUserByKey", id);
        }

        IList<SystemUsers> IDao<SystemUsers>.FindAll(SystemUsers condition)
        {
            return Mapper.Instance().QueryForList<SystemUsers>("SelectSystemUserList", condition);
        }

        int IDao<SystemUsers>.GetCount(SystemUsers codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectSystemUserCount", codition);
        }

        SystemUsers ISystemUsersDao.SelectByAccount(string userAccount)
        {
            return Mapper.Instance().QueryForObject<SystemUsers>("SelectByAccount", userAccount);
        }


        IList<int> ISystemUsersDao.SelectSystemChildrensKey(SystemUsers systemUsers)
        {
            return Mapper.Instance().QueryForList<int>("SelectSystemChildrensKey", systemUsers);
        }


        IList<SystemUsers> ISystemUsersDao.SelectSystemChildrensKeyForAllInfo(SystemUsers systemUsers)
        {
            return Mapper.Instance().QueryForList<SystemUsers>("SelectSystemChildrensKeyForAllInfo", systemUsers);
        }


        IList<SystemUsers> ISystemUsersDao.SelectSystemUserListForReport(SystemUsers condition)
        {
            return Mapper.Instance().QueryForList<SystemUsers>("SelectSystemUserListForReport", condition);
        }

        int ISystemUsersDao.SelectSystemUserCountForReport(SystemUsers condition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectSystemUserCountForReport", condition);
        }


        void ISystemUsersDao.UpdateSystemUserCode(SystemUsers condition)
        {
            Mapper.Instance().Update("UpdateSystemUserCode", condition);
        }


        IList<SystemUsers> ISystemUsersDao.SelectSystemUserListForMonthReport(SystemUsers condition)
        {
           return  Mapper.Instance().QueryForList<SystemUsers>("SelectSystemUserListForMonthReport", condition);
        }


        IList<decimal> ISystemUsersDao.SelectSystemUserListForMonthList(SystemUsers condition)
        {
            return Mapper.Instance().QueryForList<decimal>("SelectSystemUserListForMonthList", condition);
        }


        IList<string> ISystemUsersDao.SelectDateForEveryDate(SystemUsers condition)
        {
            return Mapper.Instance().QueryForList<string>("SelectDateForEveryDate", condition);
        }
    }
}
