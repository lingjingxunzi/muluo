using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoolShow.Model.Madou
{
    public class MadouBaseInfos : ModelBase
    {
        public int MadouBaseInfoKey { get; set; }
        public string Nick { get; set; }
        public string AgeRange { get; set; }
        public string Occupation { get; set; }
        public string ImageStyle { get; set; }
        public string ImageTools { get; set; }
        public DateTime JoinDate { get; set; }
        public string ExpectedSalary { get; set; }
        public string Remark { get; set; }
        public string Wechart { get; set; }
        public int Hight { get; set; }
        public int Weight { get; set; }
        public string AreaRegion { get; set; }
        public string WangLevel { get; set; }
        public string IsGive { get; set; }
        public string ImagePath { get; set; }
        public decimal Score { get; set; }

        /// <summary>
        /// 人气
        /// </summary>
        public int Popularity { get; set; }

        public string ScoreName
        {
            get { return Score > 0 ? Score.ToString("N2") : "暂无评分"; }
            set
            {

            }
        }
    }
}
