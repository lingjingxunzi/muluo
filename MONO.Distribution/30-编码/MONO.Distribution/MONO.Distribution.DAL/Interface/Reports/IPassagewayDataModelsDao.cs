using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.Model.Reports;

namespace MONO.Distribution.DAL.Interface.Reports
{
    public interface IPassagewayDataModelsDao : IDao<PassagewayDataModels>
    {
        IList<PassagewayDataModels> GetPassagewayDatas(PassagewayDataModels condition);

        IList<PassagewayDataModels> SelectUpperStatisticByDate(string date);

        IList<PassagewayDataModels> SelectLowerStatisticByDate(string date);
    }
}
