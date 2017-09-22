using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL.Sys
{
    public class MessageTemplateDao : DaoBase<MessageTemplate>, IMessageTemplateDao
    {

        ResultMessage IDao<MessageTemplate>.Insert(MessageTemplate entity)
        {
            try
            {
                Mapper.Instance().Insert("InsertMessageTemplate", entity);
            }
            catch (Exception ex)
            {
                AddInsertError("MessageTemplate", ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<MessageTemplate>.Update(MessageTemplate entity)
        {
            try
            {
                Mapper.Instance().Update("UpdateMessageTemplate", entity);
            }
            catch (Exception ex)
            {
                AddUpdateError("MessageTemplate", ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<MessageTemplate>.Delete(int id)
        {
            try
            {
                Mapper.Instance().Delete("DeleteMessageTemplate", id);
            }
            catch (Exception ex)
            {
                AddDeleteError("MessageTemplate", ex.Message);
            }
            return _result;
        }

        MessageTemplate IDao<MessageTemplate>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<MessageTemplate>("SelectMessageTemplateByKey", id);
        }

        IList<MessageTemplate> IDao<MessageTemplate>.FindAll(MessageTemplate condition)
        {
            return Mapper.Instance().QueryForList<MessageTemplate>("SelectMessageTemplateList", condition);
        }

        int IDao<MessageTemplate>.GetCount(MessageTemplate codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectMessageTemplateCount", codition);
        }
    }
}
