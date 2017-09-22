using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.Model;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL.Sys
{
    public class VerCodeRecordsDao : IVerCodeRecordDao
    {
        ResultMessage IDao<VerCodeRecords>.Insert(VerCodeRecords entity)
        {
            var obj = Mapper.Instance().Insert("InsertVerCode", entity);
            ResultMessage _result = new ResultMessage();
            return _result;
        }

        ResultMessage IDao<VerCodeRecords>.Update(VerCodeRecords entity)
        {
            Mapper.Instance().Insert("UpdateVerCode", entity);
            ResultMessage _result = new ResultMessage();
            return _result;
        }

        ResultMessage IDao<VerCodeRecords>.Delete(int id)
        {
            Mapper.Instance().Insert("DeleteVerCode", id);
            ResultMessage _result = new ResultMessage();
            return _result;
        }

        VerCodeRecords IDao<VerCodeRecords>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<VerCodeRecords>("SelectVerCodeByKey", id);
        }

        IList<VerCodeRecords> IDao<VerCodeRecords>.FindAll(VerCodeRecords condition)
        {
            return Mapper.Instance().QueryForList<VerCodeRecords>("SelectVerCodeList", condition);
        }

        int IDao<VerCodeRecords>.GetCount(VerCodeRecords codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectVerCodeCount", codition);
        }

        IList<VerCodeRecords> IVerCodeRecordDao.SelectVerCodeByIP(string IP)
        {
            return Mapper.Instance().QueryForList<VerCodeRecords>("SelectVerCodeByIP", IP);
        }


        void IVerCodeRecordDao.Delete(string VerCodeKey)
        {
            Mapper.Instance().Delete("DeleteVerCode", VerCodeKey);
        }
    }
}
