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
    public class FlowActiveCardDetailsDao : DaoBase<FlowActiveCardDetails>, IFlowActiveCardDetailsDao 
    {
         
        ResultMessage IDao<FlowActiveCardDetails>.Insert(FlowActiveCardDetails entity)
        {
            try
            {
                Mapper.Instance().Insert("InsertFlowCardDetail", entity);
               
            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<FlowActiveCardDetails>.Update(FlowActiveCardDetails entity)
        {
            try
            {
                Mapper.Instance().Update("UpdateFlowCardDetail", entity);
                 
            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<FlowActiveCardDetails>.Delete(int id)
        {
            try
            {
                Mapper.Instance().Delete("DeleteFlowCardDetail", id);
                 
            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        FlowActiveCardDetails IDao<FlowActiveCardDetails>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<FlowActiveCardDetails>("SelectFlowCardDetailByKey", id);
        }

        IList<FlowActiveCardDetails> IDao<FlowActiveCardDetails>.FindAll(FlowActiveCardDetails condition)
        {
            return Mapper.Instance().QueryForList<FlowActiveCardDetails>("SelectFlowCardDetailList", condition);
        }

        int IDao<FlowActiveCardDetails>.GetCount(FlowActiveCardDetails codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectFlowCardDetailCount", codition);
        }

        FlowActiveCardDetails IFlowActiveCardDetailsDao.FindById(string p)
        {
            return Mapper.Instance().QueryForObject<FlowActiveCardDetails>("SelectFlowCardDetailByKey", p);
        }
    }
}
