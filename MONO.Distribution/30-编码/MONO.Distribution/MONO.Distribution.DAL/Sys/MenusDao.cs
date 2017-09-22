using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using IBatisNet.DataMapper;
using MONO.Distribution.Common;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL.Sys
{
    public class MenusDao : DaoBase<Menus>, IMenusDao
    {
        ResultMessage IDao<Menus>.Insert(Menus entity)
        {
            try
            {
                object obj = Mapper.Instance().Insert("InsertMenu", entity);
                _result.Id = int.Parse(obj.ToString());
            }
            catch (Exception ex)
            {

            }
            return _result;
        }

        ResultMessage IDao<Menus>.Update(Menus entity)
        {
            try
            {
                Mapper.Instance().Update("UpdateMenu", entity);

            }
            catch (Exception ex)
            {

            }
            return _result;
        }

        ResultMessage IDao<Menus>.Delete(int id)
        {
            try
            {
                Mapper.Instance().Update("DeleteMenu", id);
            }
            catch (Exception ex)
            {

            }
            return _result;
        }

        Menus IDao<Menus>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<Menus>("SelectMenuByKey", id);
        }

        IList<Menus> IDao<Menus>.FindAll(Menus condition)
        {
            return Mapper.Instance().QueryForList<Menus>("SelectMenuList", condition);
        }

        int IDao<Menus>.GetCount(Menus codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectMenuCount", codition);
        }

        IList<Menus> IMenusDao.SelectMenuByUserKey(int SysUserKey)
        {
            return Mapper.Instance().QueryForList<Menus>("SelectMenuByUserKey", SysUserKey);
        }
    }
}
