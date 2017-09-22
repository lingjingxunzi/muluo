using System.Collections.Generic;
using MONO.Distribution.Common;
using MONO.Distribution.Utility;

namespace MONO.Distribution.DAL
{
    public interface IDao<T> where T : new()
    {
        #region 方法
        /// <summary>
        /// 向类型T的映射表新增一条记录
        /// </summary>
        /// <param name="entity">待新增实体</param>
        /// <returns>因新增记录，而产生的自增长ID</returns>
        ResultMessage Insert(T entity);

        /// <summary>
        /// 根据指定ID，修改对应表记录。
        /// </summary>
        /// <param name="entity">待修改记录主键</param>
        /// <returns>修改影响行数</returns>
        ResultMessage Update(T entity);

        /// <summary>
        /// 根据指定ID，删除对应表记录。
        /// </summary>
        /// <param name="id">待删除记录主键</param>
        /// <returns>删除影响行数</returns>
        ResultMessage Delete(int id);

        /// <summary>
        /// 根据指定ID，返回表对应记录的实体对象。
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>表对应记录的实体对象</returns>
        T FindById(int id);

        /// <summary>
        /// 根据指定条件，返回表对应记录的实体对象集。
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>实体对象集</returns>
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
