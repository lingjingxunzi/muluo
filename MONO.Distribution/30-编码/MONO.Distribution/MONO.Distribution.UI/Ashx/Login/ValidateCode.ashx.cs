using System;
using System.Drawing;
using System.Reflection;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using log4net;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;

namespace MONO.Distribution.UI.Ashx.Login
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ValidateCode : IHttpHandler, IRequiresSessionState
    {
        public ValidateCode()
        {
            LogMsg = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
           
            _verCodeRecordService = new VerCodeRecordService();
        }
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";
            string code = GetRndStr();
            UpdateCode(code);
            using (Bitmap img = CreateImages(code, "ch"))
            {
                img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void UpdateCode(string code)
        {
            try
            {

                var IP = GetIPHelper.GetIP();
                var instance = _verCodeRecordService.SelectVerCodeByIP(IP);
                if (instance != null)
                {
                    _verCodeRecordService.Delete(IP);
                }
                _verCodeRecordService.Insert(new VerCodeRecords { VerCodeKey = code, IP = GetIPHelper.GetIP() });

            }
            catch (Exception ex)
            {
                LogMsg.Info(ex);
                throw  new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 数字随机数
        /// </summary>
        /// <returns></returns>
        private string GetRndNum()
        {
            string code = string.Empty;
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                code += random.Next(9);
            }
            return code;
        }
        /// <summary>
        ///  英文随机
        /// </summary>
        /// <returns></returns>
        private string GetRndStr()
        {
            string Vchar = "的一在不了有和人这中大为上个国我以要他时来用们生到作地于出就分对成会可主发年动同工也能下过子说产种面而方后多定行学法所民得经十三之进着等部度家电力里如水化高自二理起小物现实加量都两体制机当使点从业本去把性好应开它合还因由其些然前外天政四日那社义事平形相全表间样与关各重新线内数正心反你明看原又么利比或但质气第向道命此变条只没结解问意建月公无系军很情者最立代想已通并提直题党程展五果料象员革位入常文总次品式活设及管特件长求老头基资边流路级少图山统接知较将组见计别她手角期根论运农指几九区强放决西被干做必战先回则任取据处队南给色光门即保治北造百规热领七海口东导器压志世金增争济阶油思术极交受联什认六共权收证改清己美再采转更单风切打白教速花带安场身车例真务具万每目至达走积示议声报斗完类八离华名确才科张信马节话米整空元况今集温传土许步群广石记需段研界拉林律叫且究观越织装影算低持音众书布复容儿须际商非验连断深难近矿千周委素技备半办青省列习响约支般史感劳便团往酸历市克何除消构府称太准精值号率族维划选标写存候毛亲快效斯院查江型眼王按格养易置派层片始却专状育厂京识适属圆包火住调满县局照参红细引听该铁价严";
            char[] chastr = Vchar.ToCharArray();
            string checkCode = string.Empty;
            Random rand = new Random();
            for (int i = 0; i < 6; i++)
            {
                int t = rand.Next(chastr.Length);
                checkCode += chastr[t];
            }
            return checkCode;
        }
        /// <summary>
        /// 中文随机
        /// </summary>
        /// <returns></returns>
        private string GetRndCh()
        {
            System.Text.Encoding gb = System.Text.Encoding.Default;//获取GB2312编码页（表）
            object[] bytes = CreateRegionCode(6);//生4个随机中文汉字编码
            string[] str = new string[6];
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                //根据汉字编码的字节数组解码出中文汉字
                str[i] = gb.GetString((byte[])Convert.ChangeType(bytes[i], typeof(byte[])));
                sb.Append(str[i].ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// 产生随机中文字符
        /// </summary>
        /// <param name="strlength"></param>
        /// <returns></returns>
        private static object[] CreateRegionCode(int strlength)
        {
            //定义一个字符串数组储存汉字编码的组成元素
            string[] rBase = new String[16] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
            Random rnd = new Random();
            object[] bytes = new object[strlength];

            for (int i = 0; i < strlength; i++)
            {
                //区位码第1位
                int r1 = rnd.Next(11, 14);
                string strR1 = rBase[r1].Trim();
                //区位码第2位
                rnd = new Random(r1 * unchecked((int)DateTime.Now.Ticks) + i);
                int r2;
                if (r1 == 13)
                {
                    r2 = rnd.Next(0, 7);
                }
                else
                {
                    r2 = rnd.Next(0, 16);
                }
                string strR2 = rBase[r2].Trim();

                //区位码第3位
                rnd = new Random(r2 * unchecked((int)DateTime.Now.Ticks) + i);//更换随机种子
                int r3 = rnd.Next(10, 16);
                string strR3 = rBase[r3].Trim();

                //区位码第4位
                rnd = new Random(r3 * unchecked((int)DateTime.Now.Ticks) + i);
                int r4;
                if (r3 == 10)
                {
                    r4 = rnd.Next(1, 16);
                }
                else if (r3 == 15)
                {
                    r4 = rnd.Next(0, 15);
                }
                else
                {
                    r4 = rnd.Next(0, 16);
                }
                string strR4 = rBase[r4].Trim();
                //定义两个字节变量存储产生的随机汉字区位码
                byte byte1 = Convert.ToByte(strR1 + strR2, 16);
                byte byte2 = Convert.ToByte(strR3 + strR4, 16);

                //将两个字节变量存储在字节数组中
                byte[] strR = new byte[] { byte1, byte2 };

                //将产生的一个汉字的字节数组放入object数组中
                bytes.SetValue(strR, i);
            }
            return bytes;
        }
        /// <summary>
        /// 画图片的背景图+干扰线 
        /// </summary>
        /// <param name="checkCode"></param>
        /// <returns></returns>
        private Bitmap CreateImages(string checkCode, string type)
        {
            int step = 0;
            if (type == "ch")
            {
                step = 5;//中文字符，边界值做大
            }
            int iwidth = (int)(checkCode.Length * (13 + step));
            var image = new System.Drawing.Bitmap(iwidth, 22);
            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.White);//清除背景色
            Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };//定义随机颜色
            string[] font = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };
            Random rand = new Random();

            for (int i = 0; i < 50; i++)
            {
                int x1 = rand.Next(image.Width);
                int x2 = rand.Next(image.Width);
                int y1 = rand.Next(image.Height);
                int y2 = rand.Next(image.Height);
                g.DrawLine(new Pen(Color.LightGray, 1), x1, y1, x2, y2);//根据坐标画线
            }

            for (int i = 0; i < checkCode.Length; i++)
            {
                int cindex = rand.Next(7);
                int findex = rand.Next(5);

                Font f = new System.Drawing.Font(font[findex], 10, System.Drawing.FontStyle.Bold);
                Brush b = new System.Drawing.SolidBrush(c[cindex]);
                int ii = 4;
                if ((i + 1) % 2 == 0)
                {
                    ii = 2;
                }
                g.DrawString(checkCode.Substring(i, 1), f, b, 3 + (i * (12 + step)), ii);

            }
            g.DrawRectangle(new Pen(Color.Black, 0), 0, 0, image.Width - 1, image.Height - 1);
            var ms = new System.IO.MemoryStream();
            return image;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        private IVerCodeRecordService _verCodeRecordService;
        private ILog LogMsg;
    }
}
