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
    public class SystemLogsDao : DaoBase<SystemLogs>, ISystemLogsDao
    {
        ResultMessage IDao<SystemLogs>.Insert(SystemLogs entity)
        {
            try
            {
                object obj = Mapper.Instance().Insert("InsertSystemLog", entity);
                _result.Id = int.Parse(obj.ToString());
            }
            catch (Exception ex)
            {
                 
            }
            return _result;
        }

        ResultMessage IDao<SystemLogs>.Update(SystemLogs entity)
        {
            try
            {
                Mapper.Instance().Update("UpdateSystemLog", entity);
            }
            catch (Exception ex)
            {

            }
            return _result;
        }

        ResultMessage IDao<SystemLogs>.Delete(int id)
        {
            try
            {
                Mapper.Instance().Delete("DeleteSystemLog", id);
            }
            catch (Exception ex)
            {

            }
            return _result;
        }

        SystemLogs IDao<SystemLogs>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<SystemLogs>("SelectSystemLogByKey", id);
        }

        IList<SystemLogs> IDao<SystemLogs>.FindAll(SystemLogs condition)
        {
            return Mapper.Instance().QueryForList<SystemLogs>("SelectSystemLogList", condition);
        }

        int IDao<SystemLogs>.GetCount(SystemLogs codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectSystemLogCount", codition);
        }
    }
}
