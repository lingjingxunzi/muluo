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
    public partial class MadouReview : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetBaseInfo();
            }
        }

        private void SetBaseInfo()
        {
            var id = Request.QueryString["id"];
            var baseInfo = _madouBaseInfosService.FindById(int.Parse(id));
            this.txtAge.InnerText = baseInfo.AgeRange;
            this.txtEare.InnerText = baseInfo.AreaRegion;
            this.txtHeight.InnerText = baseInfo.Hight+"cm";
            this.txtImageStyle.InnerText = baseInfo.ImageStyle;
            this.txtImageTools.InnerText = baseInfo.ImageTools;
            this.txtIsGive.InnerText = baseInfo.IsGive;
            this.txtNick.InnerText = baseInfo.Nick;
            this.txtOcc.InnerText = baseInfo.Occupation;
            this.txtSalary.InnerText = baseInfo.ExpectedSalary;
            this.txtWangLevel.InnerText = baseInfo.WangLevel;
            this.txtWeight.InnerText = baseInfo.Weight+"kg";
            this.txtPopularity.InnerText = "50";
            this.txtScore.InnerText = baseInfo.ScoreName;
            SetImageUrl(baseInfo);
        }

        protected void linkpopular_OnClick(object sender, EventArgs e)
        {
            
        }

        private void SetImageUrl(MadouBaseInfos info)
        {
            this.img1.Src = info.ImagePath;
            this.imgtrue1.Src = info.ImagePath;
        }

        IMadouBaseInfosService _madouBaseInfosService =new MadouBaseInfosService();

        
    }
}