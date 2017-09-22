using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using MONO.Distribution.Model.Reports;

namespace MONO.Distribution.BLL.Interface.Reports
{
    public interface IPassagewayDataModelsService : IService<PassagewayDataModels>
    {
        IList<PassagewayDataModels> GetPassagewayDatas(PassagewayDataModels condition);
        IList<PassagewayDataModels> SelectUpperStatisticByDate(string date);
        IList<PassagewayDataModels> SelectLowerStatisticByDate(string date);
    }
}
