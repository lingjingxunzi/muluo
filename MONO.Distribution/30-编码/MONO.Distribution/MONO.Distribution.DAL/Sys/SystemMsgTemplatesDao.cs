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
    public class SystemMsgTemplatesDao : DaoBase<SystemMsgTemplates>, ISystemMsgTemplatesDao
    {
        ResultMessage IDao<SystemMsgTemplates>.Insert(SystemMsgTemplates entity)
        {
            try
            {
                object obj = Mapper.Instance().Insert("InsertMsgTemplate", entity);
                _result.Id = int.Parse(obj.ToString());
            }
            catch (Exception ex)
            {
                AddInsertError("SystemMsgTemplates", ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<SystemMsgTemplates>.Update(SystemMsgTemplates entity)
        {
            try
            {
                Mapper.Instance().Update("UpdateMsgTemplate", entity);
                
            }
            catch (Exception ex)
            {
                AddUpdateError("SystemMsgTemplates", ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<SystemMsgTemplates>.Delete(int id)
        {
            try
            {
                Mapper.Instance().Delete("DeleteMsgTemplate", id);
                
            }
            catch (Exception ex)
            {
                AddDeleteError("SystemMsgTemplates", ex.Message);
            }
            return _result;
        }

        SystemMsgTemplates IDao<SystemMsgTemplates>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<SystemMsgTemplates>("SelectMsgTemplateByKey", id);
        }

        IList<SystemMsgTemplates> IDao<SystemMsgTemplates>.FindAll(SystemMsgTemplates condition)
        {
            return Mapper.Instance().QueryForList<SystemMsgTemplates>("SelectMsgTemplateList", condition);
        }

        int IDao<SystemMsgTemplates>.GetCount(SystemMsgTemplates codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectMsgTemplateCount", codition);
        }
    }
}
