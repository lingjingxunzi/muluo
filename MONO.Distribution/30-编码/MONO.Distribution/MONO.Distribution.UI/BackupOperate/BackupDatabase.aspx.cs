using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.UIProcess;
using MONO.Distribution.Utility;

namespace MONO.Distribution.UI.BackupOperate
{
    public partial class BackupDatabase : Page
    {
        public BackupDatabase()
        {
            _dataBackupsService = new DataBackupsService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var id = Request.QueryString["Id"];
                if (string.IsNullOrEmpty(id)) return;
                var currentBackup = _dataBackupsService.SelectDataBackupByBackNumber(new DataBackups { BackNumber = id });

                if (currentBackup.BackStyle.Equals("BackupSome"))
                {
                    currentBackup.TableNameBack = currentBackup.TableName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    currentBackup.TableName = currentBackup.TableName;
                    var result = _dataBackupsService.BackupSingleTables(currentBackup);
                    WriteLog("数据备份", "数据备份项：" + currentBackup.BackNumber + "，备份时间：" + DateTime.Now + ",备份结果：" + (result.IsOk ? "备份成功" : "备份失败，失败原因:" + result.Errors.First().Value), "");
                }
                if (currentBackup.BackStyle.Equals("BackupAll"))
                {
                    currentBackup.FileName = currentBackup.BackNumber + "-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    currentBackup.FilePath = currentBackup.BackupUrl.Replace('/', '\\') + "\\" + currentBackup.BackNumber;
                    var errorStr = _dataBackupsService.ExecFullBackup(currentBackup);
                    WriteLog("数据备份", "数据备份项：" + currentBackup.BackNumber + "，备份时间：" + DateTime.Now + ",备份结果：" + (string.IsNullOrEmpty(errorStr) ? "备份成功" : "备份失败，失败原因:" + errorStr), "");
                }
            }
        }


        public void WriteLog(string module, string content, string level)
        {
            var log = new SystemLogs
            {
                SystemLogKey = Guid.NewGuid(),
                SysUserKey = 1,
                Module = module,
                Content = content,
                Level = "1",
                IP = GetIPHelper.GetIP()
            };
            _systemLogsService.Insert(log);
        }

        ISystemLogsService _systemLogsService = new SystemLogsService();

        private IDataBackupsService _dataBackupsService;

    }
}