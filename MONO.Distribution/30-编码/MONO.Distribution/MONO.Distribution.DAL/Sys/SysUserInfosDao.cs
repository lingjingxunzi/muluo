using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.MappedStatements;
using MONO.Distribution.Common;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL.Sys
{
    public class SysUserInfosDao : DaoBase<SysUserInfos>, ISysUserInfosDao
    {
        ResultMessage IDao<SysUserInfos>.Insert(SysUserInfos entity)
        {
            try
            {
                object obj = Mapper.Instance().Insert("", entity);
                _result.Id = int.Parse(obj.ToString());
            }
            catch (Exception ex)
            {
                 
            }
            return _result;
        }

        ResultMessage IDao<SysUserInfos>.Update(SysUserInfos entity)
        {
            try
            {
                 Mapper.Instance().Update("", entity);
                
            }
            catch (Exception ex)
            {

            }
            return _result;
        }

        ResultMessage IDao<SysUserInfos>.Delete(int id)
        {
            try
            {
                Mapper.Instance().Delete("", id);

            }
            catch (Exception ex)
            {

            }
            return _result;
        }

        SysUserInfos IDao<SysUserInfos>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<SysUserInfos>("", id);
        }

        IList<SysUserInfos> IDao<SysUserInfos>.FindAll(SysUserInfos condition)
        {
            return Mapper.Instance().QueryForList<SysUserInfos>("", condition);
        }

        int IDao<SysUserInfos>.GetCount(SysUserInfos codition)
        {
            return Mapper.Instance().QueryForObject<int>("", codition);
        }
    }
}
