using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using MONO.Distribution.DAL.Interface.Reports;
using MONO.Distribution.Model.Reports;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL.Reports
{
    public class PassagewayDataModelsDao : DaoBase<PassagewayDataModels>, IPassagewayDataModelsDao
    {
        ResultMessage IDao<PassagewayDataModels>.Insert(PassagewayDataModels entity)
        {
            throw new NotImplementedException();
        }

        ResultMessage IDao<PassagewayDataModels>.Update(PassagewayDataModels entity)
        {
            throw new NotImplementedException();
        }

        ResultMessage IDao<PassagewayDataModels>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        PassagewayDataModels IDao<PassagewayDataModels>.FindById(int id)
        {
            throw new NotImplementedException();
        }

        IList<PassagewayDataModels> IDao<PassagewayDataModels>.FindAll(PassagewayDataModels condition)
        {
            throw new NotImplementedException();
        }

        int IDao<PassagewayDataModels>.GetCount(PassagewayDataModels codition)
        {
            throw new NotImplementedException();
        }

        IList<PassagewayDataModels> IPassagewayDataModelsDao.GetPassagewayDatas(PassagewayDataModels condition)
        {
            return Mapper.Instance().QueryForList<PassagewayDataModels>("SelectPassagewayDataByCarrier", condition);
        }


        IList<PassagewayDataModels> IPassagewayDataModelsDao.SelectUpperStatisticByDate(string date)
        {
            return Mapper.Instance().QueryForList<PassagewayDataModels>("SelectUpperStatisticByDate", date);
        }


        IList<PassagewayDataModels> IPassagewayDataModelsDao.SelectLowerStatisticByDate(string date)
        {
            return Mapper.Instance().QueryForList<PassagewayDataModels>("SelectLowerStatisticByDate", date);
        }
    }
}
