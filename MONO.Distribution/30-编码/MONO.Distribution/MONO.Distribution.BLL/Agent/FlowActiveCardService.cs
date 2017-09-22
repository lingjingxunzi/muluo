using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.DAL.Agent;
using MONO.Distribution.DAL.Interface.Agent;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.Agent
{
    public class FlowActiveCardService : ServiceBase<FlowActiveCard>, IFlowActiveCardService
    {
        IFlowActiveCardDao _flowActiveCardDao = new FlowActiveCardDao();
        ResultMessage IService<FlowActiveCard>.Insert(FlowActiveCard entity)
        {
            return _flowActiveCardDao.Insert(entity);
        }

        ResultMessage IService<FlowActiveCard>.Update(FlowActiveCard entity)
        {
            return _flowActiveCardDao.Update(entity);
        }

        ResultMessage IService<FlowActiveCard>.Delete(int id)
        {
            return _flowActiveCardDao.Delete(id);
        }

        FlowActiveCard IService<FlowActiveCard>.FindById(int id)
        {
            return _flowActiveCardDao.FindById(id);
        }

        IList<FlowActiveCard> IService<FlowActiveCard>.FindAll(FlowActiveCard condition)
        {
            return _flowActiveCardDao.FindAll(condition);
        }

        int IService<FlowActiveCard>.GetCount(FlowActiveCard codition)
        {
            return _flowActiveCardDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(FlowActiveCard t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(FlowActiveCard t)
        {
            throw new NotImplementedException();
        }

        FlowActiveCard IFlowActiveCardService.FindById(string id)
        {
            return _flowActiveCardDao.FindById(id);
        }


        ResultMessage IFlowActiveCardService.FlowCardBatchCreate(FlowActiveCard info)
        {
            ResultMessage result = new ResultMessage();
            result = _flowActiveCardDao.Insert(info);
            if (result.IsOk)
            {
                result = _systemAccountService.SystemAccountChange(info.SysUserKey, info.TransNo, -Convert.ToInt32(info.Amount * info.Numbers), "KM");
                if (result.IsOk)
                {
                    var rd = new Random();
                    for (var i = 0; i < info.Numbers; i++)
                    {
                        var cardId = rd.Next().ToString().Substring(0, 8);
                        while (_flowActiveCardDao.FindById(cardId) != null)
                        {
                            cardId = rd.Next().ToString().Substring(0, 8);
                        }
                        var flowActiveCardDetails = new FlowActiveCardDetails
                        {
                            CardID = cardId,
                            Serect = rd.Next().ToString().Substring(0, 6),
                            Status = "KMWSY",
                            TransNo = info.TransNo
                        };
                        flowActiveCardDetailsDao.Insert(flowActiveCardDetails);
                    }
                }
            }

            return result;
        }

        private IFlowActiveCardDetailsDao flowActiveCardDetailsDao = new FlowActiveCardDetailsDao();
        private ISystemAccountService _systemAccountService = new SystemAccountService();

    }
}
