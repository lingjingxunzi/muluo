using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.DAL.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.Sys
{
    public class MessageTemplateService : ServiceBase<MessageTemplate>, IMessageTemplateService
    {
        IMessageTemplateDao _messageTemplateDao = new MessageTemplateDao();
        ResultMessage IService<MessageTemplate>.Insert(MessageTemplate entity)
        {
            return _messageTemplateDao.Insert(entity);
        }

        ResultMessage IService<MessageTemplate>.Update(MessageTemplate entity)
        {
            return _messageTemplateDao.Update(entity);
        }

        ResultMessage IService<MessageTemplate>.Delete(int id)
        {
            return _messageTemplateDao.Delete(id);
        }

        MessageTemplate IService<MessageTemplate>.FindById(int id)
        {
            return _messageTemplateDao.FindById(id);
        }

        IList<MessageTemplate> IService<MessageTemplate>.FindAll(MessageTemplate condition)
        {
            return _messageTemplateDao.FindAll(condition);
        }

        int IService<MessageTemplate>.GetCount(MessageTemplate codition)
        {
            return _messageTemplateDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(MessageTemplate t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(MessageTemplate t)
        {
            throw new NotImplementedException();
        }
    }
}
