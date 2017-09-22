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
    public class FlowActiveCardDao : DaoBase<FlowActiveCard>, IFlowActiveCardDao
    {
        ResultMessage IDao<FlowActiveCard>.Insert(FlowActiveCard entity)
        {
            try
            {
                Mapper.Instance().Insert("InsertFlowActiveCard", entity);

            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<FlowActiveCard>.Update(FlowActiveCard entity)
        {
            try
            {
                Mapper.Instance().Update("UpdateFlowActiveCard", entity);

            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<FlowActiveCard>.Delete(int id)
        {
            try
            {
                Mapper.Instance().Delete("DeleteFlowActiveCard", id);

            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        FlowActiveCard IDao<FlowActiveCard>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<FlowActiveCard>("SelectFlowActiveCardByKey", id);
        }

        IList<FlowActiveCard> IDao<FlowActiveCard>.FindAll(FlowActiveCard condition)
        {
            return Mapper.Instance().QueryForList<FlowActiveCard>("SelectFlowActiveCardList", condition);
        }

        int IDao<FlowActiveCard>.GetCount(FlowActiveCard codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectFlowActiveCardCount", codition);
        }

        FlowActiveCard IFlowActiveCardDao.FindById(string id)
        {
            return Mapper.Instance().QueryForObject<FlowActiveCard>("SelectFlowActiveCardByKey", id);
        }
    }
}
