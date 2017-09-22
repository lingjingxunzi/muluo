using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.Interface.Sys
{
    public interface IDataBackupsService : IService<DataBackups>
    {
        IList<string> SelectTableNames(DataBackups condition);
        ResultMessage BackupSingleTables(DataBackups condition);
        string ExecFullBackup(DataBackups condition);
        DataBackups SelectDataBackupByBackNumber(DataBackups condition);

    }
}
