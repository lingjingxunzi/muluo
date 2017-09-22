using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using MONO.Distribution.BLL;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.DAL.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.FB.BLL.Sys
{
    public class FB_BusinessIPBindService : ServiceBase<BusinessIPBind>, IBusinessIPBindService
    {
        IBusinessIPBindDao  _businessIpBindDao = new FB_BusinessIPBindDao();
        ResultMessage _result = new ResultMessage();
        ResultMessage IService<BusinessIPBind>.Insert(BusinessIPBind entity)
        {
            return base.Insert(entity);
        }

        ResultMessage IService<BusinessIPBind>.Update(BusinessIPBind entity)
        {
            return _businessIpBindDao.Update(entity);
        }

        ResultMessage IService<BusinessIPBind>.Delete(int id)
        {
            return _businessIpBindDao.Delete(id);
        }

        BusinessIPBind IService<BusinessIPBind>.FindById(int id)
        {
            return _businessIpBindDao.FindById(id);
        }

        IList<BusinessIPBind> IService<BusinessIPBind>.FindAll(BusinessIPBind condition)
        {
            return _businessIpBindDao.FindAll(condition);
        }

        int IService<BusinessIPBind>.GetCount(BusinessIPBind codition)
        {
            return _businessIpBindDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(BusinessIPBind t)
        {
            return _businessIpBindDao.Insert(t);
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(BusinessIPBind t)
        {
            throw new NotImplementedException();
        }
        
    }
}
