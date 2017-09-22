using System;
using System.Collections;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using MONO.Distribution.DAL.Interface.BaseInfo;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL.BaseInfo
{
    public class FlowCodeDao : DaoBase<FlowCode>, IFlowCodeDao
    {
        ResultMessage IDao<FlowCode>.Insert(FlowCode entity)
        {
            try
            {
                object obj = Mapper.Instance().Insert("InsertFlowCode", entity);
                _result.Id = int.Parse(obj.ToString());
            }
            catch (Exception ex)
            {
                _log.Error("FlowCode Insert" + ex.Message);
                _result.Errors.Add(new Guid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<FlowCode>.Update(FlowCode entity)
        {
            try
            {
                Mapper.Instance().Update("UpdateFlowCode", entity);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                _result.Errors.Add(new Guid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<FlowCode>.Delete(int id)
        {
            try
            {
                Mapper.Instance().Delete("DeleteFlowCode", id);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                _result.Errors.Add(new Guid().ToString(), ex.Message);
            }
            return _result;
        }

        FlowCode IDao<FlowCode>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<FlowCode>("SelectFlowCodeByKey", id);
        }

        IList<FlowCode> IDao<FlowCode>.FindAll(FlowCode condition)
        {
            return Mapper.Instance().QueryForList<FlowCode>("SelectFlowCodeList", condition);
        }

        int IDao<FlowCode>.GetCount(FlowCode codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectFlowCodeCount", codition);
        }

        IList<FlowCode> IFlowCodeDao.ExecGetFlowActiveLaunchInfo(FlowCode condition)
        {
            var hashTable = new Hashtable { { "UserPhone", condition.UserPhone }, { "FlowKey", condition.FlowKey }, { "ActiveRecordKey", condition.ActiveRecordKey } };
            return Mapper.Instance().QueryForList<FlowCode>("ExecGetFlowActiveLaunchInfo", hashTable);
        }

        IList<FlowCode> IFlowCodeDao.SelectFlowCodeByDistinctList(FlowCode condition)
        {
            return Mapper.Instance().QueryForList<FlowCode>("SelectFlowCodeByDistinctList", condition);
        }

        int IFlowCodeDao.SelectFlowCodeByDistinctCount(FlowCode condition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectFlowCodeByDistinctCount", condition);
        }
    }
}
