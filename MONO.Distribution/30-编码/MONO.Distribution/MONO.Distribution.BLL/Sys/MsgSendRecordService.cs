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
    public class MsgSendRecordService : ServiceBase<MsgSendRecord>, IMsgSendRecordService
    {
        IMsgSendRecordDao _msgSendRecordDao = new MsgSendRecordDao();
        ResultMessage IService<MsgSendRecord>.Insert(MsgSendRecord entity)
        {
            return _msgSendRecordDao.Insert(entity);
        }

        ResultMessage IService<MsgSendRecord>.Update(MsgSendRecord entity)
        {
            return _msgSendRecordDao.Update(entity);
        }

        ResultMessage IService<MsgSendRecord>.Delete(int id)
        {
            return _msgSendRecordDao.Delete(id);
        }

        MsgSendRecord IService<MsgSendRecord>.FindById(int id)
        {
            return _msgSendRecordDao.FindById(id);
        }

        IList<MsgSendRecord> IService<MsgSendRecord>.FindAll(MsgSendRecord condition)
        {
            return _msgSendRecordDao.FindAll(condition);
        }

        int IService<MsgSendRecord>.GetCount(MsgSendRecord codition)
        {
            return _msgSendRecordDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(MsgSendRecord t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(MsgSendRecord t)
        {
            throw new NotImplementedException();
        }
    }
}
