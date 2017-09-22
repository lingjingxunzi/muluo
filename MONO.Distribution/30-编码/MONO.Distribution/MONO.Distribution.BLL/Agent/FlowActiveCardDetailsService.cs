using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.DAL.Agent;
using MONO.Distribution.DAL.Interface.Agent;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.Agent
{
    public class FlowActiveCardDetailsService : ServiceBase<FlowActiveCardDetails>, IFlowActiveCardDetailsService
    {
        IFlowActiveCardDetailsDao _flowActiveCardDetailsDao = new FlowActiveCardDetailsDao();
        ResultMessage IService<FlowActiveCardDetails>.Insert(FlowActiveCardDetails entity)
        {
            return _flowActiveCardDetailsDao.Insert(entity);
        }

        ResultMessage IService<FlowActiveCardDetails>.Update(FlowActiveCardDetails entity)
        {
            return _flowActiveCardDetailsDao.Update(entity);
        }

        ResultMessage IService<FlowActiveCardDetails>.Delete(int id)
        {
            return _flowActiveCardDetailsDao.Delete(id);
        }

        FlowActiveCardDetails IService<FlowActiveCardDetails>.FindById(int id)
        {
            return _flowActiveCardDetailsDao.FindById(id);
        }

        IList<FlowActiveCardDetails> IService<FlowActiveCardDetails>.FindAll(FlowActiveCardDetails condition)
        {
            return _flowActiveCardDetailsDao.FindAll(condition);
        }

        int IService<FlowActiveCardDetails>.GetCount(FlowActiveCardDetails codition)
        {
            return _flowActiveCardDetailsDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(FlowActiveCardDetails t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(FlowActiveCardDetails t)
        {
            throw new NotImplementedException();
        }

        FlowActiveCardDetails IFlowActiveCardDetailsService.FindById(string p)
        {
            return _flowActiveCardDetailsDao.FindById(p);
        }
    }
}
