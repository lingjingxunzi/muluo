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
    public class ChannelMsgSettingsService : ServiceBase<ChannelMsgSettings>, IChannelMsgSettingsService
    {
        IChannelMsgSettingsDao _channelMsgSettingsDao = new ChannelMsgSettingsDao();
       ResultMessage IService<ChannelMsgSettings>.Insert(ChannelMsgSettings entity)
       {
           return _channelMsgSettingsDao.Insert(entity);
       }

       ResultMessage IService<ChannelMsgSettings>.Update(ChannelMsgSettings entity)
       {
           return _channelMsgSettingsDao.Update(entity);
       }

       ResultMessage IService<ChannelMsgSettings>.Delete(int id)
       {
           return _channelMsgSettingsDao.Delete(id);
       }

        ChannelMsgSettings IService<ChannelMsgSettings>.FindById(int id)
        {
            return _channelMsgSettingsDao.FindById(id);
        }

        IList<ChannelMsgSettings> IService<ChannelMsgSettings>.FindAll(ChannelMsgSettings condition)
        {
            return _channelMsgSettingsDao.FindAll(condition);
        }

        int IService<ChannelMsgSettings>.GetCount(ChannelMsgSettings codition)
        {
            return _channelMsgSettingsDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(ChannelMsgSettings t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(ChannelMsgSettings t)
        {
            throw new NotImplementedException();
        }
    }
}
