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
    public class CardSamplerDao : DaoBase<CardSampler>, ICardSamplerDao
    {
        ResultMessage IDao<CardSampler>.Insert(CardSampler entity)
        {
            try
            {
                object obj = Mapper.Instance().Insert("InsertCardSampler", entity);
                _result.Id = int.Parse(obj.ToString());
            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<CardSampler>.Update(CardSampler entity)
        {
            try
            {
                Mapper.Instance().Update("UpdateCardSampler", entity);

            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<CardSampler>.Delete(int id)
        {
            try
            {
                Mapper.Instance().Delete("DeleteCardSampler", id);

            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        CardSampler IDao<CardSampler>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<CardSampler>("SelectCardSamplerByKey", id);
        }

        IList<CardSampler> IDao<CardSampler>.FindAll(CardSampler condition)
        {
            return Mapper.Instance().QueryForList<CardSampler>("SelectCardSamplerList", condition);
        }

        int IDao<CardSampler>.GetCount(CardSampler codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectCardSamplerCount", codition);
        }
    }
}
