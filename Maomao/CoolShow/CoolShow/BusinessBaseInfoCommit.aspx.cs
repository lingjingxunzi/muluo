using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CoolShow.BLL.Business;
using CoolShow.BLL.Interface.Business;
using CoolShow.Model.Business;

namespace CoolShow.UI
{
    public partial class BusinessBaseInfoCommit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void BtnCommitClick(object sender, EventArgs e)
        {
            var info = new BusinesserBaseInfos
            {
                JoinDate = DateTime.Now,
                MobilePhone = txtMobilePhone.Text.Trim(),
                QQNumber = txtQQ.Text.Trim(),
                Status = 2,
                StoreUrl = txtStoreName.Text.Trim(),
                WeChart = txtWechart.Text.Trim()
            };
           var result = _businesserBaseInfosService.Insert(info);
        }

        IBusinesserBaseInfosService _businesserBaseInfosService = new BusinesserBaseInfosService();
    }
}