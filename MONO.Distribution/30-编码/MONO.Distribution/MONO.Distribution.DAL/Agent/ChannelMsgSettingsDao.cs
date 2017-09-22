using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using MONO.Distribution.DAL.Interface.Agent;
using MONO.Distribution.Model.Agent;

namespace MONO.Distribution.DAL.Agent
{
    public class ChannelMsgSettingsDao : IChannelMsgSettingsDao
    {
        Utility.ResultMessage IDao<ChannelMsgSettings>.Insert(ChannelMsgSettings entity)
        {
            throw new NotImplementedException();
        }

        Utility.ResultMessage IDao<ChannelMsgSettings>.Update(ChannelMsgSettings entity)
        {
            throw new NotImplementedException();
        }

        Utility.ResultMessage IDao<ChannelMsgSettings>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        ChannelMsgSettings IDao<ChannelMsgSettings>.FindById(int id)
        {
            throw new NotImplementedException();
        }

        IList<ChannelMsgSettings> IDao<ChannelMsgSettings>.FindAll(ChannelMsgSettings condition)
        {
            return Mapper.Instance().QueryForList<ChannelMsgSettings>("SelectChannelMsgSettingsList", condition);
        }

        int IDao<ChannelMsgSettings>.GetCount(ChannelMsgSettings codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectChannelMsgSettingsCount", codition);
        }
    }
}
