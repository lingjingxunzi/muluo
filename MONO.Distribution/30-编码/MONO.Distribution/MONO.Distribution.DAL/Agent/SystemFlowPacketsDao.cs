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
    public class SystemFlowPacketsDao : DaoBase<SystemFlowPackets>, ISystemFlowPacketsDao
    {
        ResultMessage IDao<SystemFlowPackets>.Insert(SystemFlowPackets entity)
        {
            try
            {
                object obj = Mapper.Instance().Insert("InsertSystemFlowPacket", entity);
                _result.IdStr = obj.ToString();
            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<SystemFlowPackets>.Update(SystemFlowPackets entity)
        {
            try
            {
                Mapper.Instance().Update("UpdateSystemFlowPacket", entity);

            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<SystemFlowPackets>.Delete(int id)
        {
            try
            {
                Mapper.Instance().Delete("DeleteSystemFlowPacket", id);

            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        SystemFlowPackets IDao<SystemFlowPackets>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<SystemFlowPackets>("SelectSystemFlowPacketByKey", id);
        }

        IList<SystemFlowPackets> IDao<SystemFlowPackets>.FindAll(SystemFlowPackets condition)
        {
            return Mapper.Instance().QueryForList<SystemFlowPackets>("SelectSystemFlowPacketList", condition);
        }

        int IDao<SystemFlowPackets>.GetCount(SystemFlowPackets codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectSystemFlowPacketCount", codition);
        }

        SystemFlowPackets ISystemFlowPacketsDao.SelectSystemFlowPacketBySystemKey(SystemFlowPackets condition)
        {
            return Mapper.Instance().QueryForObject<SystemFlowPackets>("SelectSystemFlowPacketBySystemKey", condition);
        }


        IList<SystemFlowPackets> ISystemFlowPacketsDao.SelectSystemFlowPacketByUser(SystemFlowPackets condition)
        {
            return Mapper.Instance().QueryForList<SystemFlowPackets>("SelectSystemFlowPacketByUser", condition);
        }

        int ISystemFlowPacketsDao.SelectSystemFlowPacketCountByUser(SystemFlowPackets condition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectSystemFlowPacketCountByUser", condition);
        }


        void ISystemFlowPacketsDao.UpdateSystemFlowPacketBySytemKey(SystemFlowPackets condition)
        {
            Mapper.Instance().Update("UpdateSystemFlowPacketBySytemKey", condition);
        }


        IList<SystemFlowPackets> ISystemFlowPacketsDao.SelectSystemFlowPacketForBusinessList(SystemFlowPackets condition)
        {
            return Mapper.Instance().QueryForList<SystemFlowPackets>("SelectSystemFlowPacketForBusinessList", condition);
        }

        int ISystemFlowPacketsDao.SelectSystemFlowPacketForBusinessCount(SystemFlowPackets condition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectSystemFlowPacketForBusinessCount", condition);
        }
    }
}
