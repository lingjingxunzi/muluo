using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using MONO.Distribution.DAL.Interface.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL.Sys
{
    public class DataBackupsDao : DaoBase<DataBackups>, IDataBackupsDao
    {
        ResultMessage IDao<DataBackups>.Insert(DataBackups entity)
        {
            try
            {
                Mapper.Instance().Insert("InsertDataBackup", entity);
            }
            catch (Exception ex)
            {
                AddInsertError(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<DataBackups>.Update(DataBackups entity)
        {
            try
            {
                Mapper.Instance().Update("UpdateDataBackup", entity);
            }
            catch (Exception ex)
            {
                AddInsertError(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        ResultMessage IDao<DataBackups>.Delete(int id)
        {
            try
            {
                Mapper.Instance().Delete("DeleteDataBackup", id);
            }
            catch (Exception ex)
            {
                AddInsertError(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        DataBackups IDao<DataBackups>.FindById(int id)
        {
            return Mapper.Instance().QueryForObject<DataBackups>("SelectDataBackupByKey", id);
        }

        IList<DataBackups> IDao<DataBackups>.FindAll(DataBackups condition)
        {
            return Mapper.Instance().QueryForList<DataBackups>("SelectDataBackupList", condition);
        }

        int IDao<DataBackups>.GetCount(DataBackups codition)
        {
            return Mapper.Instance().QueryForObject<int>("SelectDataBackupCount", codition);
        }

        IList<string> IDataBackupsDao.SelectTableNames(DataBackups condition)
        {
            return Mapper.Instance().QueryForList<string>("SelectTableNames", condition);
        }


        ResultMessage IDataBackupsDao.BackupSingleTables(DataBackups condition)
        {
            try
            {
                var ht = new Hashtable { { "TableNameBack", condition.TableNameBack }, { "TableName", condition.TableName } };
                Mapper.Instance().QueryForObject("BackupSingleTables", ht);
            }
            catch (Exception ex)
            {
                _result.Errors.Add(Guid.NewGuid().ToString(), ex.Message);
            }
            return _result;
        }

        string IDataBackupsDao.ExecFullBackup(DataBackups condition)
        {
            var ht = new Hashtable { { "FileName", condition.FileName }, { "FilePath", condition.FilePath } };
            return Mapper.Instance().QueryForObject<string>("ExecFullBackup", ht);
        }


        DataBackups IDataBackupsDao.SelectDataBackupByBackNumber(DataBackups condition)
        {
            return Mapper.Instance().QueryForObject<DataBackups>("SelectDataBackupByBackNumber", condition);
        }
    }
}
