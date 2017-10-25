using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoolShow.BLL.Interface.Madou;
using CoolShow.Common;
using CoolShow.DAL.Interface.Madou;
using CoolShow.DAL.Madou;
using CoolShow.Model.Madou;

namespace CoolShow.BLL.Madou
{
    public class MadouBaseInfosService : IMadouBaseInfosService
    {
        IMadouBaseInfosDao _madouBaseInfosDao = new MadouBaseInfosDao();
        ResultMessage IService<MadouBaseInfos>.Insert(MadouBaseInfos entity)
        {
            throw new NotImplementedException();
        }

        ResultMessage IService<MadouBaseInfos>.Update(MadouBaseInfos entity)
        {
            throw new NotImplementedException();
        }

        ResultMessage IService<MadouBaseInfos>.Delete(int id)
        {
            return _madouBaseInfosDao.Delete(id);
        }

        MadouBaseInfos IService<MadouBaseInfos>.FindById(int id)
        {
            return _madouBaseInfosDao.FindById(id);
        }

        IList<MadouBaseInfos> IService<MadouBaseInfos>.FindAll(MadouBaseInfos condition)
        {
            return _madouBaseInfosDao.FindAll(condition);
        }

        int IService<MadouBaseInfos>.GetCount(MadouBaseInfos codition)
        {
            return _madouBaseInfosDao.GetCount(codition);
        }
    }
}
