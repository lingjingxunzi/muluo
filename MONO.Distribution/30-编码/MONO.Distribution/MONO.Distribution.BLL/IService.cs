using System.Collections.Generic;
using MONO.Distribution.Common;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL
{
    public interface IService<T> where T : new()
    {
        #region 方法
        /// <summary>
        /// 将传递的实体对象entity持久化至数据库
        /// </summary>
        /// <param name="entity">待持久化的实体对象</param>
        /// <returns>持久化结果</returns>
        ResultMessage Insert(T entity);
        
        /// <summary>
        /// 将传递的实体对象entity持久化至数据库
        /// </summary>
        /// <param name="entity">待持久化的实体对象</param>
        /// <returns>持久化结果</returns>
        ResultMessage Update(T entity);
        
        /// <summary>
        /// 根据主键，物理删除对应数据记录
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>物理删除操作的结果信息</returns>
        ResultMessage Delete(int id);
        
        /// <summary>
        /// 根据主键查找，返回实体对象
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>实体对象</returns>
        T FindById(int id);
        
        /// <summary>
        /// 根据查询条件返回记录集
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>返回的记录集</returns>
        IList<T> FindAll(T condition);
        
        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name="codition">条件</param>
        /// <returns>记录数</returns>
        int GetCount(T codition);
        #endregion
    }
}
