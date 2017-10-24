using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoolShow.BLL.Interface.Madou;

namespace CoolShow.BLL.Madou
{
    public class MadouBaseInfosService:IMadouBaseInfosService
    {
        Common.ResultMessage IService<Model.Madou.MadouBaseInfos>.Insert(Model.Madou.MadouBaseInfos entity)
        {
            throw new NotImplementedException();
        }

        Common.ResultMessage IService<Model.Madou.MadouBaseInfos>.Update(Model.Madou.MadouBaseInfos entity)
        {
            throw new NotImplementedException();
        }

        Common.ResultMessage IService<Model.Madou.MadouBaseInfos>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Model.Madou.MadouBaseInfos IService<Model.Madou.MadouBaseInfos>.FindById(int id)
        {
            throw new NotImplementedException();
        }

        IList<Model.Madou.MadouBaseInfos> IService<Model.Madou.MadouBaseInfos>.FindAll(Model.Madou.MadouBaseInfos condition)
        {
            throw new NotImplementedException();
        }

        int IService<Model.Madou.MadouBaseInfos>.GetCount(Model.Madou.MadouBaseInfos codition)
        {
            throw new NotImplementedException();
        }
    }
}
