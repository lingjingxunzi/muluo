using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoolShow.Common;
using CoolShow.DAL.Interface.Madou;
using CoolShow.Model.Madou;
using IBatisNet.DataMapper;

namespace CoolShow.DAL.Madou
{
    public class MadouBaseInfosDao : IMadouBaseInfosDao
    {
        ResultMessage IDao<MadouBaseInfos>.Insert(MadouBaseInfos entity)
        {
            throw new NotImplementedException();
        }

        ResultMessage IDao<MadouBaseInfos>.Update(MadouBaseInfos entity)
        {
            throw new NotImplementedException();
        }

        ResultMessage IDao<MadouBaseInfos>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        MadouBaseInfos IDao<MadouBaseInfos>.FindById(int id)
        {
            throw new NotImplementedException();
        }

        IList<MadouBaseInfos> IDao<MadouBaseInfos>.FindAll(MadouBaseInfos condition)
        {
            return Mapper.Instance().QueryForList<MadouBaseInfos>("SelectBusinesserBaseInfoList", condition);
        }

        int IDao<MadouBaseInfos>.GetCount(MadouBaseInfos codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectBusinesserBaseInfoCount", codition);
        }
    }
}
