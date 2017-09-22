using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.UIProcess;
using MONO.Distribution.Utility;

namespace MONO.Distribution.UI.BaseInfo
{
    public partial class EnumerationList : ListPageBase
    {

        public EnumerationList()
        {
            _enumerationService = new EnumerationService();

            _result = new ResultMessage();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }
        #region 事件函数
        protected void gvEnumerationList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "enable")
            {
                string[] arg = e.CommandArgument.ToString().Split(','); //注意是单引号 
                string key = arg[0];
                string enable = arg[1];
                enable = enable == "0" ? "1" : "0";
                Enable(key, enable);
            }
        }
        protected void AspNetPager_PageChanged(object src, EventArgs e)
        {
            BindGridView();
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridView();
        }
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                BindGridView();
                WriteLog("数据字典", "查询字典成功", "");
            }
            catch (Exception)
            {
                WriteLog("数据字典", "查询字典失败;错误原因" + GetNoticeForLog(_result), "");
            }

        }
        protected void btnReload_Click(object sender, EventArgs e)
        {
            IEnumerationService enumerationService = new EnumerationService();
            IList<Enumerations> _enumerations = enumerationService.FindAll(new Enumerations { Status = "1" });
            Application["EnmuMap"] = _enumerations;
        }
        #endregion

        #region 自定义函数

        /// <summary>
        /// 页面初始化
        /// </summary>
        private void BindGridView()
        {
            var condition = BuildQueryCondition();
            SetPager(condition);
            var list = _enumerationService.FindAll(BuildQueryCondition());
            gvEnumerationList.DataSource = list;
            gvEnumerationList.DataBind();
        }

        protected void btnPage_Click(object sender, EventArgs e)
        {
            PageHelper.SetPageIndex(int.Parse(hidePage.Value));
            BindGridView();
        }

        /// <summary>
        /// 页面初始化是基础类型列显示
        /// </summary>
        /// <param name="EnumTypeId"></param>
        /// <returns></returns>
        protected string BindEnumerationType(string EnumTypeId)
        {
            string returnValue = string.Empty;
            try
            {
                //returnValue = _enumerationTypeService.FindById(int.Parse(EnumTypeId)).Name;
            }
            catch (Exception)
            {
                returnValue = "没有此类型";
            }
            return returnValue;
        }
        /// <summary>
        /// 获取分页记录数
        /// </summary>
        private void SetPager(Enumerations condition)
        {
            var pageCount = _enumerationService.GetCount(condition);
            this.SetPager(pageCount, 10);
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="key"></param>
        /// <param name="status"></param>
        private void Enable(string key, string status)
        {
            Enumerations enu = _enumerationService.FindById(key);
            enu.Status = status;
            _result = _enumerationService.Update(enu);
            WriteLog("数据字典","禁用/启用字典-"+enu.EnumKey,"");
            BindGridView();//重新绑定数据
        }
        /// <summary>
        /// 构造条件
        /// </summary>
        /// <returns></returns>
        private Enumerations BuildQueryCondition()
        {
            return new Enumerations
            {
                IsStartPager = true,
                StartRecordIndex = PageHelper.GetStartIndex(),
                EndRecordIndex = PageHelper.GetEndIndex() > PageHelper.GetPageTotal()
                        ? PageHelper.GetPageTotal()
                        : PageHelper.GetEndIndex(),
                EnumValue = txtEnumValue.Text.Trim(),
                Status = string.IsNullOrEmpty(ddlStatus.SelectedValue)
                        ? null
                        : ddlStatus.SelectedValue
            };
        }
        #endregion

        private readonly IEnumerationService _enumerationService;
        private ResultMessage _result;


    }
}
