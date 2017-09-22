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
    public class MenuGroupsDao : DaoBase<MenuGroups>, IMenuGroupsDao
    {
        ResultMessage IDao<MenuGroups>.Insert(MenuGroups entity)
        {
            try
            {
                object obj = Mapper.Instance().Insert("InsertMenuGroup", entity);
                _result.Id = int.Parse(obj.ToString());
            }
            catch (Exception ex)
            {
                //_result.Errors.Add("",);
            }
            return _result;
        }

        ResultMessage IDao<MenuGroups>.Update(MenuGroups entity)
        {
            try
            {
                Mapper.Instance().Update("UpdateMenuGroup", entity);
            }
            catch (Exception ex)
            {
                //_result.Errors.Add("",);
            }
            return _result;
        }

        ResultMessage IDao<MenuGroups>.Delete(int id)
        {
            try
            {
                Mapper.Instance().Delete("DeleteMenuGroup", id);
            }
            catch (Exception ex)
            {
                //_result.Errors.Add("",);
            }
            return _result;
        }

        MenuGroups IDao<MenuGroups>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<MenuGroups>("SelectMenuGroupByKey", id);
        }

        IList<MenuGroups> IDao<MenuGroups>.FindAll(MenuGroups condition)
        {
            return Mapper.Instance().QueryForList<MenuGroups>("SelectMenuGroupList", condition);
        }

        int IDao<MenuGroups>.GetCount(MenuGroups codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectMenuGroupCount", codition);
        }

         
    }
}
