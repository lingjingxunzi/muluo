using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.UIProcess;
using MONO.Distribution.Utility.NPOI;

namespace MONO.Distribution.UI.AgentApplication
{
    public partial class FlowCardDetails : ListPageBase
    {
        public FlowCardDetails()
        {
            _flowActiveCardDetailsService = new FlowActiveCardDetailsService();
            _flowActiveCardService = new FlowActiveCardService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }




        protected void btnPage_Click(object sender, EventArgs e)
        {
            PageHelper.SetPageIndex(int.Parse(hidePage.Value));
            BindData();
        }



        protected void AspNetPager_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void gvFlowCardDetailsList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Status")
            {
                string id = e.CommandArgument.ToString();
                var cards = _flowActiveCardDetailsService.FindById(id);
                cards.Status = "KMTKSQ";
                _flowActiveCardDetailsService.Update(cards);
            }
            BindData();
        }


        protected void btnExport_Click(object sender, EventArgs e)
        {
            var condition = new FlowActiveCardDetails { TransNo = Request.QueryString["NO"] };
            var data = _flowActiveCardDetailsService.FindAll(condition);
            DataTable dt = new DataTable();
            SetHeaderInfo(dt);
            SetDataTableValue(dt, data);
            ExportExcel.ExportExcelFile(Page.Response, dt, "卡密提取" + DateTime.Now.ToString("yyyyMMddHHmmss"));
        }



        private void BindData()
        {
            var condition = GetQueryContidion();
            SetPager(condition);
            var data = _flowActiveCardDetailsService.FindAll(condition);
            this.gvFlowCardDetailsList.DataSource = data;
            this.gvFlowCardDetailsList.DataBind();

        }

        private void SetPager(FlowActiveCardDetails condition)
        {
            SetPager(_flowActiveCardDetailsService.GetCount(condition), 10);
        }

        private FlowActiveCardDetails GetQueryContidion()
        {
            return new FlowActiveCardDetails
                       {
                           IsStartPager = true,
                           StartRecordIndex = PageHelper.GetStartIndex(),
                           EndRecordIndex = PageHelper.GetEndIndex() < PageHelper.GetPageTotal()
                                   ? PageHelper.GetPageTotal()
                                   : PageHelper.GetEndIndex(),
                           TransNo = Request.QueryString["NO"]
                       };
        }

        private void SetDataTableValue(DataTable dt, IList<FlowActiveCardDetails> data)
        {
            foreach (var con in data)
            {
                DataRow row = dt.NewRow();
                row[0] = con.TransNo;
                row[1] = con.CardID;
                row[2] = con.Serect;
                row[3] = con.MobilePhone;
                row[4] = (con.Status.Equals("KMYLQ") && con.FlowPaBaseInfo != null)
                             ? con.FlowPaBaseInfo.Name
                             : "";
                row[5] = con.Status.Equals("KMYLQ") ? con.RechargeTime.ToString("yyyy-MM-dd HH:mm:ss") : "";
                row[6] = con.EnumStatus.EnumValue;
                dt.Rows.Add(row);
            }
        }

        private void SetHeaderInfo(DataTable dt)
        {
            dt.Columns.Add(new DataColumn("批次号"));
            dt.Columns.Add(new DataColumn("卡号"));
            dt.Columns.Add(new DataColumn("密码"));
            dt.Columns.Add(new DataColumn("电话号码"));
            dt.Columns.Add(new DataColumn("流量包"));
            dt.Columns.Add(new DataColumn("提取时间"));
            dt.Columns.Add(new DataColumn("状态"));
        }

        private IFlowActiveCardService _flowActiveCardService;
        private IFlowActiveCardDetailsService _flowActiveCardDetailsService;


    }
}