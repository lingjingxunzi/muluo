using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CoolShow.BLL.Interface.Madou;
using CoolShow.BLL.Madou;
using CoolShow.Model.Madou;

namespace CoolShow.UI
{
    public partial class MadouSquare : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMadouInfo();
            }
        }

        private void BindMadouInfo()
        {
            var condition = GetQueryCondition();
            var madouList = _madouBaseService.FindAll(condition);
        }

        private MadouBaseInfos GetQueryCondition()
        {
            return new MadouBaseInfos();
        }

        IMadouBaseInfosService _madouBaseService = new MadouBaseInfosService();
    }
}