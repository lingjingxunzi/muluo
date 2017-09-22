using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.BLL.Interface.Reports;
using MONO.Distribution.DAL.Interface.Reports;
using MONO.Distribution.DAL.Reports;
using MONO.Distribution.Model.Reports;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.Reports
{
    public class PassagewayDataModelsService : IPassagewayDataModelsService
    {
        IPassagewayDataModelsDao _passagewayDataModelsDao = new PassagewayDataModelsDao();
        ResultMessage IService<PassagewayDataModels>.Insert(PassagewayDataModels entity)
        {
            throw new NotImplementedException();
        }

        ResultMessage IService<PassagewayDataModels>.Update(PassagewayDataModels entity)
        {
            throw new NotImplementedException();
        }

        ResultMessage IService<PassagewayDataModels>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        PassagewayDataModels IService<PassagewayDataModels>.FindById(int id)
        {
            throw new NotImplementedException();
        }

        IList<PassagewayDataModels> IService<PassagewayDataModels>.FindAll(PassagewayDataModels condition)
        {
            throw new NotImplementedException();
        }

        int IService<PassagewayDataModels>.GetCount(PassagewayDataModels codition)
        {
            throw new NotImplementedException();
        }

        IList<PassagewayDataModels> IPassagewayDataModelsService.GetPassagewayDatas(PassagewayDataModels condition)
        {
            return _passagewayDataModelsDao.GetPassagewayDatas(condition);
        }


        IList<PassagewayDataModels> IPassagewayDataModelsService.SelectUpperStatisticByDate(string date)
        {
            return _passagewayDataModelsDao.SelectUpperStatisticByDate(date);
        }


        IList<PassagewayDataModels> IPassagewayDataModelsService.SelectLowerStatisticByDate(string date)
        {
            return _passagewayDataModelsDao.SelectLowerStatisticByDate(date);
        }
    }
}
