using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.UIProcess;

namespace MONO.Distribution.UI.Sys
{
    public partial class FlowDiscountList : ListPageBase
    {
        private GridView gv = null;
        public FlowDiscountList()
        {
            _enumerationService = new EnumerationService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            var condition = GetQueryCondition();
            var list = _enumerationService.SelectEnumerationByCarriers("Carriers");
            DataTable dt = new DataTable();
            foreach (var items in list)
            {
                dt.Columns.Add(items.EnumKey, typeof(string));
            }

            for (var i = 0; i < list.Count; i++)
            {
                if (list[i].Carriers.Any())
                {
                    for (var j = 0; j < list[i].Carriers.Count; j++)
                    {
                        var values = (list[i].Carriers[j].AreaName == null ? "" : list[i].Carriers[j].AreaName.Name) + list[i].Carriers[j].EnumFrom.EnumValue + " " + list[i].Carriers[j].EnumFromRanges.EnumValue+" 折扣："+list[i].Carriers[j].Discounts.Deduction;

                        if (dt.Rows.Count > j)
                        {
                            dt.Rows[j][i] = values;
                        }
                        else
                        {
                            DataRow row = dt.NewRow();
                            row[i] = values;
                            dt.Rows.Add(row);
                        }
                    }
                }
            }
            BindDataGrid(dt, list);
        }



        private Enumerations GetQueryCondition()
        {
            return new Enumerations();
        }




        protected void btnQuery_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }



        public void BindDataGrid(DataTable dt, IList<Enumerations> list)
        {
            gv = new GridView();
            gv.AutoGenerateColumns = false;
            gv.CssClass = "tablelist";
            gv.DataSource = dt;
            for (var i = 0; i < list.Count; i++)
            {
                var bc = new BoundField { DataField = list[i].EnumKey, HeaderText = list[i].EnumValue };
                gv.Columns.Add(bc);
            }
            gv.DataBind();
            gv_div.Controls.Add(gv);
        }
        private IEnumerationService _enumerationService;

    }
}