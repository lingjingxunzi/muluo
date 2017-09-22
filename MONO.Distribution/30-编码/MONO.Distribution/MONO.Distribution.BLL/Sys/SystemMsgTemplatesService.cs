using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.DAL.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.Sys
{
    public class SystemMsgTemplatesService : ServiceBase<SystemMsgTemplates>, ISystemMsgTemplatesService
    {
        ISystemMsgTemplatesDao _systemMsgTemplatesDao = new SystemMsgTemplatesDao();
        ResultMessage IService<SystemMsgTemplates>.Insert(SystemMsgTemplates entity)
        {
            return _systemMsgTemplatesDao.Insert(entity);
        }

        ResultMessage IService<SystemMsgTemplates>.Update(SystemMsgTemplates entity)
        {
            return _systemMsgTemplatesDao.Update(entity);
        }

        ResultMessage IService<SystemMsgTemplates>.Delete(int id)
        {
            return _systemMsgTemplatesDao.Delete(id);
        }

        SystemMsgTemplates IService<SystemMsgTemplates>.FindById(int id)
        {
            return _systemMsgTemplatesDao.FindById(id);
        }

        IList<SystemMsgTemplates> IService<SystemMsgTemplates>.FindAll(SystemMsgTemplates condition)
        {
            return _systemMsgTemplatesDao.FindAll(condition);
        }

        int IService<SystemMsgTemplates>.GetCount(SystemMsgTemplates codition)
        {
            return _systemMsgTemplatesDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(SystemMsgTemplates t)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(SystemMsgTemplates t)
        {
            throw new NotImplementedException();
        }
    }
}
