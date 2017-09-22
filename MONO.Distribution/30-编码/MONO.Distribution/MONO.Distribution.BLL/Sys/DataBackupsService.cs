using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.DAL.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.Sys
{
    public class DataBackupsService : ServiceBase<DataBackups>, IDataBackupsService
    {
        IDataBackupsDao _dataBackupsDao = new DataBackupsDao();
        ResultMessage IService<DataBackups>.Insert(DataBackups entity)
        {
            return base.Insert(entity);
        }

        ResultMessage IService<DataBackups>.Update(DataBackups entity)
        {
            return _dataBackupsDao.Update(entity);
        }

        ResultMessage IService<DataBackups>.Delete(int id)
        {
            return _dataBackupsDao.Delete(id);
        }

        DataBackups IService<DataBackups>.FindById(int id)
        {
            return _dataBackupsDao.FindById(id);
        }

        IList<DataBackups> IService<DataBackups>.FindAll(DataBackups condition)
        {
            return _dataBackupsDao.FindAll(condition);
        }

        int IService<DataBackups>.GetCount(DataBackups codition)
        {
            return _dataBackupsDao.GetCount(codition);
        }

        protected override ResultMessage ExecuteInsert(DataBackups t)
        {
            return _dataBackupsDao.Insert(t);
        }

        protected override ResultMessage ExecuteDelete(int id)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage ExecuteUpdate(DataBackups t)
        {
            throw new NotImplementedException();
        }

        IList<string> IDataBackupsService.SelectTableNames(DataBackups condition)
        {
            return _dataBackupsDao.SelectTableNames(condition);
        }


        protected override ResultMessage AfterInsert(DataBackups t)
        {

            var content = t.DataBackupKey + "," + t.BackNumber + "," + t.BackStyle + "," + t.BackupTime + "," + t.BackupUrl + "," + t.Cycle +
                          "," + t.TableName + ",ADD";
            TxtWriteHandler.FileStreamWrite(t.FileFolder, t.BackNumber + ".txt", content);
            return base.AfterInsert(t);
        }


        ResultMessage IDataBackupsService.BackupSingleTables(DataBackups condition)
        {
            return _dataBackupsDao.BackupSingleTables(condition);
        }

        string IDataBackupsService.ExecFullBackup(DataBackups condition)
        {
            return _dataBackupsDao.ExecFullBackup(condition);
        }


        DataBackups IDataBackupsService.SelectDataBackupByBackNumber(DataBackups condition)
        {
            return _dataBackupsDao.SelectDataBackupByBackNumber(condition);
        }
    }
}
