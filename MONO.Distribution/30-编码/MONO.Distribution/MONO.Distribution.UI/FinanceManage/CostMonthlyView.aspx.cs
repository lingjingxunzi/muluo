using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Interface.Reports;
using MONO.Distribution.BLL.Reports;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Model.Reports;
using MONO.Distribution.UIProcess;
using MONO.Distribution.Utility;
using MONO.Distribution.Utility.NPOI;

namespace MONO.Distribution.UI.FinanceManage
{
    public partial class CostMonthlyView : ListPageBase
    {
        public CostMonthlyView()
        {
            _passagewayDataModelsService = new PassagewayDataModelsService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtStartQueryDateTime.Text = DateTime.Now.ToString("yyyy-MM");
                BindData();
            }
        }

        private void BindData()
        {
            lblCycle.Text = GetCycleText();
            var list = _passagewayDataModelsService.SelectUpperStatisticByDate(txtStartQueryDateTime.Text.Trim('-'));
            this.rep_FlowTotal.DataSource = list;
            this.rep_FlowTotal.DataBind();
            this.lblTotal.Text = ((decimal)list.Sum(m => m.counts) / 100).ToString();
        }


        private string GetCycleText()
        {
            var date = Convert.ToDateTime(this.txtStartQueryDateTime.Text + "-01");
            return date.ToString("yyyy年MM月dd日") + "--" + SpecialDateTools.GetDateTimeMonthLastDay(Convert.ToDateTime(this.txtStartQueryDateTime.Text + "-01")).ToString("yyyy年MM月dd日");
        }


        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }



        protected void btnLoad_OnClick(object sender, EventArgs e)
        {
            var list = _passagewayDataModelsService.SelectUpperStatisticByDate(txtStartQueryDateTime.Text.Trim('-'));

            var dt = new DataTable();
            SetHeaderInfo(dt);
            SetDataTableValue(dt, list);
            ExportExcel.ExportExcelFile(Page.Response, dt, lblCycle.Text + "-向上统计");
        }


        private void SetDataTableValue(DataTable dt, IList<PassagewayDataModels> data)
        {
            try
            {
                foreach (var con in data)
                {
                    DataRow row = dt.NewRow();
                    row[0] = con.EnumName == null ? "" : con.EnumName.EnumValue;
                    row[1] = Convert.ToDecimal(con.counts) / 100;
                    dt.Rows.Add(row);
                }
                DataRow total = dt.NewRow();
                total[0] = "总计";
                total[1] = Convert.ToDecimal(data.Sum(m => m.counts)) / 100;
                dt.Rows.Add(total);
            }
            catch (Exception ex)
            {

            }
        }

        private void SetHeaderInfo(DataTable dt)
        {
            dt.Columns.Add(new DataColumn("接口商"));
            dt.Columns.Add(new DataColumn("金额"));
        }


        private IPassagewayDataModelsService _passagewayDataModelsService;

    }
}