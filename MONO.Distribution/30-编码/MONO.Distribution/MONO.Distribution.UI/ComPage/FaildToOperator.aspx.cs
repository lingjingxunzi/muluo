using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MONO.Distribution.BLL.Agent;
using MONO.Distribution.BLL.Interface.Agent;
using MONO.Distribution.Model.Agent;

namespace MONO.Distribution.UI.ComPage
{
    public partial class FaildToOperator : Page
    {
        public FaildToOperator()
        {
            _flowDistributionRecordsService = new FlowDistributionRecordsService();
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
            var list = _flowDistributionRecordsService.FindAll(new FlowDistributionRecords { MobilePhone = Request.QueryString["Phone"], OrderStatus = "Temp" });
            this.gvSavedList.DataSource = list;
            this.gvSavedList.DataBind();
            iNumbers.InnerText = list.Count + "个";
            iphone.InnerText = Request.QueryString["Phone"];
        }

        private IFlowDistributionRecordsService _flowDistributionRecordsService;
    }
}