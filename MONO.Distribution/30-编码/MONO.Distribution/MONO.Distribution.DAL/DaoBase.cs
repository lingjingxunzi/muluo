using System;
using System.Reflection;
using IBatisNet.Common.Logging;
using MONO.Distribution.Common;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL
{
    public abstract class DaoBase<T>
     where T : new()
    {
        #region 变量
        protected ResultMessage _result;
        protected readonly ILog _log;
        #endregion

        #region 构造函数


        protected DaoBase()
        {
            this._result = new ResultMessage();
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        protected void AddInsertError(string method, string err)
        {
            _result.Errors.Add(Guid.NewGuid() + method + "Insert", err);
        }

        protected void AddUpdateError(string method, string err)
        {
            _result.Errors.Add(Guid.NewGuid() + method + "Update", err);
        }

        protected void AddDeleteError(string method, string err)
        {
            _result.Errors.Add(Guid.NewGuid() + method + "Delete", err);
        }
        #endregion



    }
}
