using System;
using System.Collections.Generic;
using MONO.Distribution.BLL.Interface.BaseInfo;
using MONO.Distribution.DAL.BaseInfo;
using MONO.Distribution.DAL.Interface.BaseInfo;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.BaseInfo
{
    public class FlowBaseInfoService : ServiceBase<FlowBaseInfo>, IFlowBaseInfoService
    {
        IFlowBaseInfoDao _flowBaseInfoDao = new FlowBaseInfoDao();
        ResultMessage IService<FlowBaseInfo>.Insert(FlowBaseInfo entity)
        {
            return _flowBaseInfoDao.Insert(entity);
        }

        ResultMessage IService<FlowBaseInfo>.Update(FlowBaseInfo entity)
        {
            return _flowBaseInfoDao.Update(entity);
        }

        ResultMessage IService<FlowBaseInfo>.Delete(int id)
        {
            return _flowBaseInfoDao.Delete(id);
        }

        FlowBaseInfo IService<FlowBaseInfo>.FindById(int id)
        {
            return _flowBaseInfoDao.FindById(id);
        }

        IList<FlowBaseInfo> IService<FlowBaseInfo>.FindAll(FlowBaseInfo condition)
        {
            return _flowBaseInfoDao.FindAll(condition);
        }

        int IService<FlowBaseInfo>.GetCount(FlowBaseInfo codition)
        {
            return _flowBaseInfoDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(FlowBaseInfo t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(FlowBaseInfo t)
        {
            throw new NotImplementedException();
        }

        FlowBaseInfo IFlowBaseInfoService.SelectFlowBaseInfoByFlowCode(string PlatformCode)
        {
            return _flowBaseInfoDao.SelectFlowBaseInfoByFlowCode(PlatformCode);
        }


        IList<FlowBaseInfo> IFlowBaseInfoService.SelectFlowType(FlowBaseInfo info)
        {
            return _flowBaseInfoDao.SelectFlowType(info);
        }
    }
}
