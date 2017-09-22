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
    public class SystemFlowPacketsService : ServiceBase<SystemFlowPackets>, ISystemFlowPacketsService
    {
        ISystemFlowPacketsDao _systemFlowPacketsDao = new SystemFlowPacketsDao();
        ResultMessage IService<SystemFlowPackets>.Insert(SystemFlowPackets entity)
        {
            return _systemFlowPacketsDao.Insert(entity);
        }

        ResultMessage IService<SystemFlowPackets>.Update(SystemFlowPackets entity)
        {
            return _systemFlowPacketsDao.Update(entity);
        }

        ResultMessage IService<SystemFlowPackets>.Delete(int id)
        {
            return _systemFlowPacketsDao.Delete(id);
        }

        SystemFlowPackets IService<SystemFlowPackets>.FindById(int id)
        {
            return _systemFlowPacketsDao.FindById(id);
        }

        IList<SystemFlowPackets> IService<SystemFlowPackets>.FindAll(SystemFlowPackets condition)
        {
            return _systemFlowPacketsDao.FindAll(condition);
        }

        int IService<SystemFlowPackets>.GetCount(SystemFlowPackets codition)
        {
            return _systemFlowPacketsDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(SystemFlowPackets t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(SystemFlowPackets t)
        {
            throw new NotImplementedException();
        }

        SystemFlowPackets ISystemFlowPacketsService.SelectSystemFlowPacketBySystemKey(SystemFlowPackets condition)
        {
            return _systemFlowPacketsDao.SelectSystemFlowPacketBySystemKey(condition);
        }






        IList<SystemFlowPackets> ISystemFlowPacketsService.SelectSystemFlowPacketByUser(SystemFlowPackets condition)
        {
            return _systemFlowPacketsDao.SelectSystemFlowPacketByUser(condition);
        }


        int ISystemFlowPacketsService.SelectSystemFlowPacketCountByUser(SystemFlowPackets condition)
        {
            return _systemFlowPacketsDao.SelectSystemFlowPacketCountByUser(condition);
        }


        void ISystemFlowPacketsService.UpdateSystemFlowPacketBySytemKey(SystemFlowPackets condition)
        {
            _systemFlowPacketsDao.UpdateSystemFlowPacketBySytemKey(condition);
        }


        IList<SystemFlowPackets> ISystemFlowPacketsService.SelectSystemFlowPacketForBusinessList(SystemFlowPackets condition)
        {
            return _systemFlowPacketsDao.SelectSystemFlowPacketForBusinessList(condition);
        }

        int ISystemFlowPacketsService.SelectSystemFlowPacketForBusinessCount(SystemFlowPackets condition)
        {
            return _systemFlowPacketsDao.SelectSystemFlowPacketForBusinessCount(condition);
        }
    }
}
