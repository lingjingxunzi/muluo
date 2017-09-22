using System;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.BaseInfo;
using MONO.Distribution.BLL.Interface.BaseInfo;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.UIProcess;
using MONO.Distribution.Utility;

namespace MONO.Distribution.UI.BaseInfo
{
    public partial class MobilePhoneBelongEdit : EditPageBase
    {
        public MobilePhoneBelongEdit()
        {
            _mobileAreaService = new MobileAreaService();
            ResultMessage = new ResultMessage();
            _areaService = new AreasService();
            _result = new ResultMessage();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDdlData();
            }
        }


        protected override void SetInsert()
        {
            base.SetInsert();
            btnUpdate.Visible = false;
        }


        protected override void SetUpdate()
        {
            base.SetUpdate();
            btnSave.Visible = false;
            var info = _mobileAreaService.FindById(Id);
            SetMobilePhoneBelong(info);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var info = new MobileArea();
            GetMobilePhoneBelong(info);
            ResultMessage = _mobileAreaService.Insert(info);
            OperationEnd();
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ValiateInfo();
            if (!_result.IsOk)
            {
                return;
            }
            var info = _mobileAreaService.FindById(Id);
            GetMobilePhoneBelong(info);
            _mobileAreaService.Update(info);
            OperationEnd();
        }

        private ResultMessage ValiateInfo()
        {
            if (txtHead.Text.Trim().Length != 7)
            {
                _result.Errors.Add("EnumKeyLengthError", "“号码头”长度必须是7位！");
            }

            if (ddlAreas.SelectedValue.Equals("0"))
            {
                _result.Errors.Add("RemarksLengthError", "请选择区域");
            }

            return _result;
        }



        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(ddlProvince.SelectedValue))
            //{
            //    ddlCity.Items.Clear();
            //    var child = _provincesService.FindAll(new FB_Provinces { ParentKey = int.Parse(ddlProvince.SelectedValue) });
            //    foreach (var fbProvincese in child)
            //    {
            //        ddlCity.Items.Add(new ListItem(fbProvincese.Name, fbProvincese.ProvinceKey.ToString()));
            //    }
            //    ddlCity.Items.Insert(0, new ListItem("请选择", ""));
            //}
        }


        private void BindDdlData()
        {
            var list = _areaService.FindAll(new Areas());
            foreach (var fbProvincese in list)
            {
                ddlAreas.Items.Add(new ListItem(fbProvincese.Name, fbProvincese.AreaKey));
            }
            ddlAreas.Items.Insert(0, new ListItem("请选择", "0"));
        }

        private void GetMobilePhoneBelong(MobileArea info)
        {
            info.MobileHead = txtHead.Text.Trim();
            info.AreaKey = ddlAreas.SelectedValue;
        }

        private void SetMobilePhoneBelong(MobileArea info)
        {
            if (info != null)
            {
                txtHead.Text = info.MobileHead;
                ddlAreas.SelectedValue = info.AreaKey;
            }
        }

        private IMobileAreaService _mobileAreaService;

        private IAreaService _areaService;
        private ResultMessage _result;
    }
}