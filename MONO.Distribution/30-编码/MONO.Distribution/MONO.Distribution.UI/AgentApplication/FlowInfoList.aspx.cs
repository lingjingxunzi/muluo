using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.BLL.Interface.BaseInfo;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Model.BaseInfo;
using MONO.Distribution.UIProcess;
using MONO.Distribution.Utility.NPOI;

namespace MONO.Distribution.UI.AgentApplication
{
    public partial class FlowInfoList : ListPageBase
    {
        public FlowInfoList()
        {
            _systemFlowPacketsService = new SystemFlowPacketsService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnLoad_OnClick(object sender, EventArgs e)
        {
            var condtion = GetQueryCondition();
            condtion.IsStartPager = false;
            condtion.StartRecordIndex = 0;
            condtion.EndRecordIndex = 0;
            var data = _systemFlowPacketsService.SelectSystemFlowPacketByUser(condtion);
            var dt = new DataTable();
            SetHeaderInfo(dt);
            SetDataTableValue(dt, data);
            ExportExcel.ExportExcelFile(Page.Response, dt, CurrentUser.Account + "-产品信息");
        }

        protected void btnPage_Click(object sender, EventArgs e)
        {
            PageHelper.SetPageIndex(int.Parse(hidePage.Value));
            BindData();
        }

        private void BindData()
        {
            var condtion = GetQueryCondition();
            SetPager(_systemFlowPacketsService.SelectSystemFlowPacketCountByUser(condtion), 10);
            var list = _systemFlowPacketsService.SelectSystemFlowPacketByUser(condtion);
            this.gvDisList.DataSource = list;
            this.gvDisList.DataBind();
        }

        private SystemFlowPackets GetQueryCondition()
        {
            return new SystemFlowPackets
            {
                IsStartPager = true,
                StartRecordIndex = PageHelper.GetStartIndex(),
                EndRecordIndex = PageHelper.GetEndIndex() < PageHelper.GetPageTotal()
                        ? PageHelper.GetPageTotal()
                        : PageHelper.GetEndIndex(),
                SysUserKey = CurrentUser.SysUserKey,
                Name = txtName.Text.Trim(),
                Status =  "Y"
            };
        }


        private void SetDataTableValue(DataTable dt, IList<SystemFlowPackets> data)
        {
            try
            {
                foreach (var con in data)
                {
                    DataRow row = dt.NewRow();
                    row[0] = con.FlowBaseInfo.Name;
                    row[1] = con.FlowBaseInfo.PlatformCode;
                    row[2] = con.FlowBaseInfo.StandardPrice;
                    row[3] = con.Discounts.Deduction;
                    row[4] = con.Price;
                    row[5] = con.FlowBaseInfo.EnumGRange == null ? "" : con.FlowBaseInfo.EnumGRange.EnumValue;
                    dt.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void SetHeaderInfo(DataTable dt)
        {
            dt.Columns.Add(new DataColumn("名称"));
            dt.Columns.Add(new DataColumn("产品编码"));
            dt.Columns.Add(new DataColumn("原价"));
            dt.Columns.Add(new DataColumn("折扣"));
            dt.Columns.Add(new DataColumn("折扣价"));
            dt.Columns.Add(new DataColumn("流量范围"));
        }
        
        private ISystemFlowPacketsService _systemFlowPacketsService;
    }
}