using System;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.BaseInfo;
using MONO.Distribution.BLL.Interface.BaseInfo;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.UIProcess;

namespace MONO.Distribution.UI.BaseInfo
{
    public partial class FlowPakgeList : ListPageBase
    {
        public FlowPakgeList()
        {
            _flowPacketInfosService = new FlowBaseInfoService();
            _enumerationService = new EnumerationService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDdlData();
                BindFlowPakgeData();
            }
        }


        #region
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindFlowPakgeData();
        }

        protected void btnPage_Click(object sender, EventArgs e)
        {
            PageHelper.SetPageIndex(int.Parse(hidePage.Value));
            BindFlowPakgeData();
        }


        protected void gvFlowPacketList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id;
            if (e.CommandName == "Status")
            {
                id = Convert.ToInt32(e.CommandArgument);
                var info = _flowPacketInfosService.FindById(id);
                info.Status = info.Status == "Y" ? "N" : "Y";
                _flowPacketInfosService.Update(info);
            }
            if (e.CommandName == "ChannelStatus")
            {
                id = Convert.ToInt32(e.CommandArgument);
                var info = _flowPacketInfosService.FindById(id);
                info.ChannelStatus = info.ChannelStatus == "Y" ? "N" : "Y";
                _flowPacketInfosService.Update(info);
            }
            BindFlowPakgeData();
        }

        protected void AspNetPager_PageChanged(object src, EventArgs e)
        {
            BindFlowPakgeData();
        }
        #endregion




        private void BindFlowPakgeData()
        {
            var condtion = GetQueryCondtion();
            SetPager(condtion);
            var list = _flowPacketInfosService.FindAll(condtion);
            gvFlowPacketList.DataSource = list;
            gvFlowPacketList.DataBind();
            
        }

        private void SetPager(FlowBaseInfo conditon)
        {
            SetPager(_flowPacketInfosService.GetCount(conditon), 10);
        }

        private FlowBaseInfo GetQueryCondtion()
        {
            var info = new FlowBaseInfo
                           {
                               IsStartPager = true,
                               StartRecordIndex = PageHelper.GetStartIndex(),
                               EndRecordIndex = PageHelper.GetEndIndex() < PageHelper.GetPageTotal()
                                       ? PageHelper.GetPageTotal()
                                       : PageHelper.GetEndIndex(),
                               Status = ddlStatus.SelectedValue,
                               From = ddlFrom.SelectedValue,
                               Range = ddlRange.SelectedValue,
                               Name = txtTitle.Text
                           };

            return info;
        }

        private void BindDdlData()
        {
            //var fromList = _enumerationService.SelectEnumerationsByTypeName("流量包来源");
            //foreach (var fbEnumeration in fromList)
            //{
            //    ddlFrom.Items.Add(new ListItem(fbEnumeration.EnumValue, fbEnumeration.EnumKey));
            //}
            //ddlFrom.Items.Insert(0, new ListItem("请选择", ""));
            //var rangList = _enumerationService.SelectEnumerationsByTypeName("流量包范围");
            //foreach (var fbEnumeration in rangList)
            //{
            //    ddlRange.Items.Add(new ListItem(fbEnumeration.EnumValue, fbEnumeration.EnumKey));
            //}
            //ddlRange.Items.Insert(0, new ListItem("请选择", ""));
            //var usedList = _enumerationService.SelectEnumerationsByTypeName("使用状态");
            //foreach (var fbEnumeration in usedList)
            //{
            //    ddlStatus.Items.Add(new ListItem(fbEnumeration.EnumValue, fbEnumeration.EnumKey));
            //}
            //ddlStatus.Items.Insert(0, new ListItem("请选择", ""));
        }



        private readonly IFlowBaseInfoService _flowPacketInfosService;
        private IEnumerationService _enumerationService;
    }
}