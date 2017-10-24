using System.Linq;
using System.Reflection;
using CoolShow.Common;
using log4net;

namespace CoolShow.BLL
{
    /// <summary>
    /// 商业逻辑服务提供实现基类
    /// </summary>
    public abstract class ServiceBase<T>
        where T : new()
    {

        #region 变量
        ResultMessage _result;
        protected readonly ILog _log;
        #endregion

        #region 构造函数

        protected ServiceBase()
        {
            this._result = new ResultMessage();
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
        #endregion

        #region 方法

        #region Insert操作
        protected ResultMessage Insert(T t)
        {
            _result = BeforeInsert(t);
            if (_result.IsOk)
            {
                _result = ExecuteInsert(t);
                if (_result.Errors.Count > 0)
                {
                    _log.Info(_result.Errors.First().Value);
                }
                else
                {
                    _result = AfterInsert(t);
                    if (!_result.IsOk)
                    {
                        foreach (var err in _result.Errors)
                        {
                            _log.Info(err);
                        }
                        
                    }
                }
                if (t.ToString().ToLower() != "JSG.OA.Models.Sys.OnlineUser".ToLower())
                    _log.Info(string.Format("框架日志：{0}进行插入操作.", t));
            }
            return _result;
        }

        protected virtual ResultMessage AfterInsert(T t)
        {
            return _result;
        }
        protected virtual ResultMessage BeforeInsert(T t)
        {
            Assert.NotAllowNull(t);
            return _result;
        }
        protected abstract ResultMessage ExecuteInsert(T t);
        #endregion

        #region Delete操作

        protected ResultMessage Delete(int id)
        {
            _result = BeforeDelete(id);
            if (_result.IsOk)
            {
                _result = ExecuteDelete(id);
                _log.Info(string.Format("框架日志：进行删除操作."));
            }
            return _result;
        }
        protected virtual ResultMessage BeforeDelete(int id)
        {
            return _result;
        }
        protected abstract ResultMessage ExecuteDelete(int id);
        #endregion

        #region Update操作

        protected ResultMessage Update(T t)
        {
            _result = BeforeUpdate(t);
            if (_result.IsOk)
            {
                _result = ExecuteUpdate(t);
                _log.Info(string.Format("框架日志：{0}进行修改操作.", t));
                AfterUpdate(t);
            }
            return _result;
        }

        protected virtual ResultMessage AfterUpdate(T t)
        {
            return _result;
        }

        protected virtual ResultMessage BeforeUpdate(T t)
        {
            Assert.NotAllowNull(t);
            return _result;
        }

        protected abstract ResultMessage ExecuteUpdate(T t);

        #endregion


        protected int GetResultId()
        {
            return _result.Id;
        }

        protected void WriteErrors(string error)
        {
            _log.Info(string.Format("错误信息", error));
        }

        #endregion
    }
}
