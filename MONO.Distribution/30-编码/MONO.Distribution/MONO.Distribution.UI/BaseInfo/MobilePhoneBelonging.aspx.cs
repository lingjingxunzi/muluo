using System;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.BaseInfo;
using MONO.Distribution.BLL.Interface.BaseInfo;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.UIProcess;

namespace MONO.Distribution.UI.BaseInfo
{
    public partial class MobilePhoneBelonging : ListPageBase
    {
        public MobilePhoneBelonging()
        {
            _mobileAreaService = new MobileAreaService();
            _areaService = new AreasService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDdlData();
                BindBelongData();
            }
        }

        #region
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindBelongData();
        }

        protected void btnPage_Click(object sender, EventArgs e)
        {
            PageHelper.SetPageIndex(int.Parse(hidePage.Value));
            BindBelongData();
        }


        protected void gvPhoneBelongList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }


        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlProvince.SelectedValue))
            {
                ddlCity.Items.Clear();
                var child = _areaService.FindAll(new Areas { ParentKey = ddlProvince.SelectedValue });
                foreach (var fbProvincese in child)
                {
                    ddlCity.Items.Add(new ListItem(fbProvincese.Name, fbProvincese.Name));
                }
                ddlCity.Items.Insert(0, new ListItem("请选择", ""));
            }
        }
        #endregion

        private void BindBelongData()
        {
            var condition = GetQueryCondition();
            SetPager(condition);
            var list = _mobileAreaService.FindAll(condition);
            gvPhoneBelongList.DataSource = list;
            gvPhoneBelongList.DataBind();
        }

        private MobileArea GetQueryCondition()
        {
            return new MobileArea
                       {
                           IsStartPager = true,
                           StartRecordIndex = PageHelper.GetStartIndex(),
                           EndRecordIndex = PageHelper.GetEndIndex() < PageHelper.GetPageTotal()
                                   ? PageHelper.GetPageTotal()
                                   : PageHelper.GetEndIndex(),
                           AreaKey = ddlProvince.SelectedItem.Text.Equals("请选择") ? "" : ddlProvince.SelectedValue,
                           MobileHead = txtPhoneHead.Text.Trim()
                       };
        }

        private void SetPager(MobileArea condition)
        {
            SetPager(_mobileAreaService.GetCount(condition), 10);
        }

        private void BindDdlData()
        {
            var list = _areaService.FindAll(new Areas(){ParentKey = "0"});
            foreach (var fbProvincese in list)
            {
                ddlProvince.Items.Add(new ListItem(fbProvincese.Name, fbProvincese.AreaKey));
            }
            ddlProvince.Items.Insert(0, new ListItem("请选择", "0"));
        }

        private IMobileAreaService _mobileAreaService;
        private IAreaService _areaService;
    }
}