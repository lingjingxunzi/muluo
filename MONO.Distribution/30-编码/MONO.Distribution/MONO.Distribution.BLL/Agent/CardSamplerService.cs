using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.DAL.Agent;
using MONO.Distribution.DAL.Interface.Agent;
using MONO.Distribution.DAL.Sys;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.Agent
{
    public class CardSamplerService : ServiceBase<CardSampler>, ICardSamplerService
    {
        ICardSamplerDao _cardSamplerDao = new CardSamplerDao();
        ResultMessage IService<CardSampler>.Insert(CardSampler entity)
        {
            return _cardSamplerDao.Insert(entity);
        }

        ResultMessage IService<CardSampler>.Update(CardSampler entity)
        {
            return _cardSamplerDao.Update(entity);
        }

        ResultMessage IService<CardSampler>.Delete(int id)
        {
            return _cardSamplerDao.Delete(id);
        }

        CardSampler IService<CardSampler>.FindById(int id)
        {
            return _cardSamplerDao.FindById(id);
        }

        IList<CardSampler> IService<CardSampler>.FindAll(CardSampler condition)
        {
            return _cardSamplerDao.FindAll(condition);
        }

        int IService<CardSampler>.GetCount(CardSampler codition)
        {
            return _cardSamplerDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(CardSampler t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(CardSampler t)
        {
            throw new NotImplementedException();
        }
    }
}
