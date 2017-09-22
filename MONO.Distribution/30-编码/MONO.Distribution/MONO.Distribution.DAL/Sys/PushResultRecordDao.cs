using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL.Sys
{
    public class PushResultRecordDao : DaoBase<PushResultRecords>, IPushResultRecordDao
    {
        ResultMessage IDao<PushResultRecords>.Insert(PushResultRecords entity)
        {
            try
            {
                Mapper.Instance().Insert("InsertPushResultRecords", entity);
            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(),ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<PushResultRecords>.Update(PushResultRecords entity)
        {
            throw new NotImplementedException();
        }

        ResultMessage IDao<PushResultRecords>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        PushResultRecords IDao<PushResultRecords>.FindById(int id)
        {
            throw new NotImplementedException();
        }

        IList<PushResultRecords> IDao<PushResultRecords>.FindAll(PushResultRecords condition)
        {
            throw new NotImplementedException();
        }

        int IDao<PushResultRecords>.GetCount(PushResultRecords codition)
        {
            throw new NotImplementedException();
        }
    }
}
