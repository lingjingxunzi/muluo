using System;
using System.Collections.Generic;
using MONO.Distribution.BLL.Interface.BaseInfo;
using MONO.Distribution.DAL.BaseInfo;
using MONO.Distribution.DAL.Interface.BaseInfo;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.BaseInfo
{
    public class FlowCodeService : ServiceBase<FlowCode>, IFlowCodeService
    {
        IFlowCodeDao _flowCodeDao = new FlowCodeDao();
        ResultMessage IService<FlowCode>.Insert(FlowCode entity)
        {
            return _flowCodeDao.Insert(entity);
        }

        ResultMessage IService<FlowCode>.Update(FlowCode entity)
        {
            return _flowCodeDao.Update(entity);
        }

        ResultMessage IService<FlowCode>.Delete(int id)
        {
            return _flowCodeDao.Delete(id);
        }

        FlowCode IService<FlowCode>.FindById(int id)
        {
            return _flowCodeDao.FindById(id);
        }

        IList<FlowCode> IService<FlowCode>.FindAll(FlowCode condition)
        {
            return _flowCodeDao.FindAll(condition);
        }

        int IService<FlowCode>.GetCount(FlowCode codition)
        {
            return _flowCodeDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(FlowCode t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(FlowCode t)
        {
            throw new NotImplementedException();
        }

        IList<FlowCode> IFlowCodeService.ExecGetFlowActiveLaunchInfo(FlowCode condition)
        {
            return _flowCodeDao.ExecGetFlowActiveLaunchInfo(condition);
        }


        IList<FlowCode> IFlowCodeService.SelectFlowCodeByDistinctList(FlowCode condition)
        {
            return _flowCodeDao.SelectFlowCodeByDistinctList(condition);
        }

        int IFlowCodeService.SelectFlowCodeByDistinctCount(FlowCode condition)
        {
            return _flowCodeDao.SelectFlowCodeByDistinctCount(condition);
        }
    }
}
