using System;
using System.Collections.Generic;
using IBatisNet.DataMapper;
using MONO.Distribution.DAL.Interface.BaseInfo;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL.BaseInfo
{
    public class FlowBaseInfoDao : DaoBase<FlowBaseInfo>, IFlowBaseInfoDao
    {
        ResultMessage IDao<FlowBaseInfo>.Insert(FlowBaseInfo entity)
        {
            try
            {
                object obj = Mapper.Instance().Insert("InsertFlowBaseInfo", entity);
                _result.Id = int.Parse(obj.ToString());
            }
            catch (Exception ex)
            {
                _log.Error("FlowBaseInfo Insert" + ex.Message);
                _result.Errors.Add(new Guid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<FlowBaseInfo>.Update(FlowBaseInfo entity)
        {
            try
            {
                object obj = Mapper.Instance().Update("UpdateFlowBaseInfo", entity);
                _result.Id = int.Parse(obj.ToString());
            }
            catch (Exception ex)
            {
                _log.Error("FlowBaseInfo Update" + ex.Message);
                _result.Errors.Add(new Guid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<FlowBaseInfo>.Delete(int id)
        {
            try
            {
                Mapper.Instance().Delete("DeleteFlowBaseInfo", id);
            }
            catch (Exception ex)
            {
                _log.Error("FlowBaseInfo Delete" + ex.Message);
                _result.Errors.Add(new Guid().ToString(), ex.Message);
            }
            return _result;
        }

        FlowBaseInfo IDao<FlowBaseInfo>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<FlowBaseInfo>("SelectFlowBaseInfoByKey", id);
        }

        IList<FlowBaseInfo> IDao<FlowBaseInfo>.FindAll(FlowBaseInfo condition)
        {
            return Mapper.Instance().QueryForList<FlowBaseInfo>("SelectFlowBaseInfoList", condition);
        }

        int IDao<FlowBaseInfo>.GetCount(FlowBaseInfo codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectFlowBaseInfoCount", codition);
        }

        FlowBaseInfo IFlowBaseInfoDao.SelectFlowBaseInfoByFlowCode(string PlatformCode)
        {
            return Mapper.Instance().QueryForObject<FlowBaseInfo>("SelectFlowBaseInfoByFlowCode", PlatformCode);
        }


        IList<FlowBaseInfo> IFlowBaseInfoDao.SelectFlowType(FlowBaseInfo info)
        {
            return Mapper.Instance().QueryForList<FlowBaseInfo>("SelectFlowType", info);
        }
    }
}
