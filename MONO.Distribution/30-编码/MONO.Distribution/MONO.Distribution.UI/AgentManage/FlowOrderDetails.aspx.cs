using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.UIProcess;
using MONO.Distribution.Utility.NPOI;

namespace MONO.Distribution.UI.AgentManage
{
    public partial class FlowOrderDetails : ListPageBase
    {
        public FlowOrderDetails()
        {
            _enumerationService = new EnumerationService();
            _systemUsersService = new SystemUsersService();
            _flowDistributionRecordsService = new FlowDistributionRecordsService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtStartQueryDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtEndQueryDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                BindDdlData();
                BindData();
            }
        }



        protected void btnPage_Click(object sender, EventArgs e)
        {
            PageHelper.SetPageIndex(int.Parse(hidePage.Value));
            BindData();
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
            WriteLog("流量分销", "查询", "");
        }

        private void BindData()
        {
            var condtion = GetQueryCondition();
            SetPager(_flowDistributionRecordsService.SelectDistributionRecordForIntergalCount(condtion), 10);
            var list = _flowDistributionRecordsService.SelectDistributionRecordForIntergalList(condtion);
            this.gvDisList.DataSource = list;
            this.gvDisList.DataBind();
        }

        private FlowDistributionRecords GetQueryCondition()
        {
            return new FlowDistributionRecords
            {
                IsStartPager = true,
                StartRecordIndex = PageHelper.GetStartIndex(),
                EndRecordIndex = PageHelper.GetEndIndex() < PageHelper.GetPageTotal()
                        ? PageHelper.GetPageTotal()
                        : PageHelper.GetEndIndex(),
                SystemUserList = _systemUsersService.SelectSystemChildrensKey(new SystemUsers { SysUserKey = CurrentUser.SysUserKey }),
                OrderStatus = ddlorderStatus.SelectedValue,
                BatchNo = txtTransNo.Text,
                MobilePhone = txtPhone.Text,
                StartTime = txtStartQueryDateTime.Text.Equals("选择开始时间")?"":txtStartQueryDateTime.Text,
                EndTime = txtEndQueryDateTime.Text.Equals("选择结束时间") ? "" : txtEndQueryDateTime.Text
            };
        }

        private void BindDdlData()
        {
            var userList = _systemUsersService.SelectSystemChildrensKeyForAllInfo(new SystemUsers { SysUserKey = CurrentUser.SysUserKey });

            this.ddlUsers.DataSource = userList;
            this.ddlUsers.DataTextField = "Account";
            this.ddlUsers.DataValueField = "SysUserKey";
            this.ddlUsers.DataBind();
            this.ddlUsers.Items.Insert(0, new ListItem("请选择", "0"));


            var statusList = _enumerationService.SelectEnumerationsByTypeName("OrderSta");
            this.ddlorderStatus.DataSource = statusList;
            this.ddlorderStatus.DataTextField = "EnumValue";
            this.ddlorderStatus.DataValueField = "EnumKey";
            this.ddlorderStatus.DataBind();
            this.ddlorderStatus.Items.Insert(0, new ListItem("请选择", ""));
        }

        protected void btnLoad_OnClick(object sender, EventArgs e)
        {
            var condtion = GetQueryCondition();
            condtion.IsStartPager = false;
            condtion.StartRecordIndex = 0;
            condtion.EndRecordIndex = 0;
            var data = _flowDistributionRecordsService.SelectDistributionRecordForIntergalList(condtion);
            var dt = new DataTable();
            SetHeaderInfo(dt);
            SetDataTableValue(dt, data);
            ExportExcel.ExportExcelFile(Page.Response, dt, "订购详情-" + DateTime.Now.ToString("yyyyMMddHHmmss"));
        }


        private void SetDataTableValue(DataTable dt, IList<FlowDistributionRecords> data)
        {
            try
            {
                foreach (var con in data)
                {
                    DataRow row = dt.NewRow();
                    row[0] = con.BatchNo;
                    row[1] = con.MobilePhone;
                    row[2] = con.SystemUsers.Account;
                    row[3] = con.SystemFlowPackets.FlowBaseInfo.FlowName;
                    row[4] = (con.SystemAccountLog == null) ? "0" : (-con.SystemAccountLog.Integral).ToString("N0");
                    row[5] = con.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    row[6] = con.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    row[7] = con.DistributionRecordKey;
                    row[8] = (con.EnumStatus==null)?"":con.EnumStatus.EnumValue;
                    dt.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void SetHeaderInfo(DataTable dt)
        {
            dt.Columns.Add(new DataColumn("批次号"));
            dt.Columns.Add(new DataColumn("电话号码"));
            dt.Columns.Add(new DataColumn("分销用户"));
            dt.Columns.Add(new DataColumn("流量包"));
            dt.Columns.Add(new DataColumn("花销"));
            dt.Columns.Add(new DataColumn("订购日期"));
            dt.Columns.Add(new DataColumn("更新日期"));
            dt.Columns.Add(new DataColumn("订单编号"));
            dt.Columns.Add(new DataColumn("订购状态"));
        }


        private IEnumerationService _enumerationService;
        private ISystemUsersService _systemUsersService;
        private IFlowDistributionRecordsService _flowDistributionRecordsService;
    }
}