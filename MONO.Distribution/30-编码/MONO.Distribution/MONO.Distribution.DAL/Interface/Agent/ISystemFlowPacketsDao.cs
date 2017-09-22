using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.Model.Agent;

namespace MONO.Distribution.DAL.Interface.Agent
{
    public interface ISystemFlowPacketsDao : IDao<SystemFlowPackets>
    {
        SystemFlowPackets SelectSystemFlowPacketBySystemKey(SystemFlowPackets condition);

        IList<SystemFlowPackets> SelectSystemFlowPacketByUser(SystemFlowPackets condition);

        int SelectSystemFlowPacketCountByUser(SystemFlowPackets condition);

        void UpdateSystemFlowPacketBySytemKey(SystemFlowPackets condition);

        IList<SystemFlowPackets> SelectSystemFlowPacketForBusinessList(SystemFlowPackets condition);

        int SelectSystemFlowPacketForBusinessCount(SystemFlowPackets condition);
    }
}
