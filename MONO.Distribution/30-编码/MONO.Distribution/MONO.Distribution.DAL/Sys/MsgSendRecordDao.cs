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
    public class MsgSendRecordDao : DaoBase<MsgSendRecord>, IMsgSendRecordDao
    {
        ResultMessage IDao<MsgSendRecord>.Insert(MsgSendRecord entity)
        {
            try
            {
                Mapper.Instance().Insert("InsertMsgSendRecord", entity);
            }
            catch (Exception ex)
            {
                AddInsertError(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<MsgSendRecord>.Update(MsgSendRecord entity)
        {
            try
            {
                Mapper.Instance().Update("UpdateMsgSendRecord", entity);
            }
            catch (Exception ex)
            {
                AddInsertError(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<MsgSendRecord>.Delete(int id)
        {
            try
            {
                Mapper.Instance().Delete("DeleteMsgSendRecord", id);
            }
            catch (Exception ex)
            {
                AddInsertError(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        MsgSendRecord IDao<MsgSendRecord>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<MsgSendRecord>("SelectMsgSendRecordByKey", id);
        }

        IList<MsgSendRecord> IDao<MsgSendRecord>.FindAll(MsgSendRecord condition)
        {
            return Mapper.Instance().QueryForList<MsgSendRecord>("SelectMsgSendRecordList", condition);
        }

        int IDao<MsgSendRecord>.GetCount(MsgSendRecord codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectMsgSendRecordCount", codition);
        }
    }
}
