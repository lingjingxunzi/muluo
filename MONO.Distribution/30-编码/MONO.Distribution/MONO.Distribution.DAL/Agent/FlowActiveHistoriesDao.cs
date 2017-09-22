using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using MONO.Distribution.DAL.Interface.Agent;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL.Agent
{
    public class FlowActiveHistoriesDao : DaoBase<FlowActiveHistories>, IFlowActiveHistoriesDao
    {
        ResultMessage IDao<FlowActiveHistories>.Insert(FlowActiveHistories entity)
        {
            try
            {
               Mapper.Instance().Insert("InsertFlowActiveHistories", entity);
            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<FlowActiveHistories>.Update(FlowActiveHistories entity)
        {
            try
            {
                object obj = Mapper.Instance().Update("UpdateFlowActiveHistories", entity);
                _result.IdStr = obj.ToString();
            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<FlowActiveHistories>.Delete(int id)
        {
            try
            {
                object obj = Mapper.Instance().Delete("DeleteFlowActiveHistories", id);
                _result.IdStr = obj.ToString();
            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        FlowActiveHistories IDao<FlowActiveHistories>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<FlowActiveHistories>("SelectFlowActiveHistoriesByKey", id);
        }

        IList<FlowActiveHistories> IDao<FlowActiveHistories>.FindAll(FlowActiveHistories condition)
        {
            return Mapper.Instance().QueryForList<FlowActiveHistories>("SelectFlowActiveHistoriesList", condition);
        }

        int IDao<FlowActiveHistories>.GetCount(FlowActiveHistories codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectFlowActiveHistoriesCount", codition);
        }

        FlowActiveHistories IFlowActiveHistoriesDao.FindById(string transKey)
        {
            return Mapper.Instance().QueryForObject<FlowActiveHistories>("SelectFlowActiveHistoriesByKey", transKey);
        }


        FlowActiveHistories IFlowActiveHistoriesDao.SelectFlowActiveHistoriesByOrderId(string orders)
        {
            return Mapper.Instance().QueryForObject<FlowActiveHistories>("SelectFlowActiveHistoriesByOrderId", orders);
        }
    }
}
