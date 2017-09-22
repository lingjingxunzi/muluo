using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.UIProcess;
using MONO.Distribution.Utility;

namespace MONO.Distribution.UI.BaseInfo
{
    public partial class EnumerationEdit : EditPageBase
    {
        protected IEnumerationService EnumerationService = new EnumerationService();
        ResultMessage _result = new ResultMessage();

        protected void Page_Load(object sender, EventArgs e)
        {
            IsOpenTabNav = false;
            if (!IsPostBack)
            {
                BindDDLEnumType();
                SetAttribute();
                BindPage();
            }
        }
        #region 页面设置
        protected override void SetUpdate()
        {
            base.SetUpdate();
            txtEnumKey.Enabled = false;
            btnSave.Visible = false;
            SetEnumerationInfo();
        }

        private void SetEnumerationInfo()
        {
            var info = EnumerationService.FindById(Request.QueryString["Key"]);
            txtEnumValue.Text = info.EnumValue;
            txtEnumKey.Text = info.EnumKey;
            txtRemarks.Text = info.Remark;
            ddlEnumType.SelectedValue = info.EnumParent;
        }

        protected override void SetInsert()
        {
            base.SetInsert();
            btnUpdate.Visible = false;
        }
        #endregion

        #region 事件处理
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Update();
        }
        #endregion



        #region 自定义函数
        private void SetAttribute()
        {
            txtEnumKey.Attributes.Add("onkeyup", "value=value.replace(/[\\W]/g,'')");
            txtEnumKey.Attributes.Add("onbeforepaste", "clipboardData.setData('text',clipboardData.getData('text').replace(/[^/d]/g,''))");
        }

        private void BindPage()
        {
            if (Id == 0) return;
            var typeId = GetTypeId();
            if (typeId != 0)
            {
                ddlEnumType.SelectedValue = typeId.ToString(CultureInfo.InvariantCulture);
            }
        }
        /// <summary>
        /// 页面初始化绑定类型选项
        /// </summary>
        private void BindDDLEnumType()
        {
            IList<Enumerations> listEnumerationType = EnumerationService.FindAll(new Enumerations { EnumParent = "0" });

            ddlEnumType.Items.Add(new ListItem("请选择", "0"));
            foreach (var item in listEnumerationType)
            {
                ddlEnumType.Items.Add(new ListItem(item.EnumValue, item.EnumKey));
            }
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        private Enumerations GetModel()
        {
            var enumeration = new Enumerations
            {
                EnumKey = txtEnumKey.Text.Trim(),
                EnumValue = txtEnumValue.Text.Trim(),
                Remark = txtRemarks.Text.Trim(),
                Status = ddlStatus.SelectedValue,
                EnumParent = ddlEnumType.SelectedValue
            };
            return enumeration;
        }

        private void Save()
        {
            _result = SavingValidate();
            if (!_result.IsOk)
            {
                WriteLog("数据字典", "新增字典失败;错误原因" + GetNoticeForLog(_result), "");
                return;
            }
            var model = GetModel();
            ResultMessage = EnumerationService.Insert(model);
            OperationEnd("数据字典", "新增字典" + model.EnumKey);
        }

        private ResultMessage SavingValidate()
        {
            if (txtEnumKey.Text.Trim().Length > 20 || txtEnumKey.Text.Trim().Length < 2)
            {
                _result.Errors.Add("EnumKeyLengthError", "“字典代码”长度必须是2-20位！");
            }

            if (txtRemarks.Text.Trim().Length > 250)
            {
                _result.Errors.Add("RemarksLengthError", "“备注”不能超过250个字符！");
            }

            return _result;
        }

        private void Update()
        {
            _result = SavingValidate();
            if (!_result.IsOk)
            {
                WriteLog("数据字典", "修改字典失败;错误原因" + GetNoticeForLog(_result), "");

                return;
            }
            var model = GetModel();
            ResultMessage = EnumerationService.Update(model);
            OperationEnd("数据字典", "修改字典" + model.EnumKey);
        }
        private int GetTypeId()
        {
            return Convert.ToInt32(string.IsNullOrEmpty(Request["TypeId"]) ? "0" : Request["TypeId"]);
        }

        #endregion


    }
}
