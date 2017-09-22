using System;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using FlowOrderConsole.FilePartition;
using FlowOrderConsole.MappingModels;
using System.IO;
using FlowOrderConsole.Tools.RequestUrl;
namespace FlowOrderConsole
{
    class Program
    {
        public static System.Windows.Forms.Timer timerRun = new System.Windows.Forms.Timer();//状态获取循环
        public static string[] CstrS;
        public static bool isLoaded = true;
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.CursorVisible = false;
            Console.Title = "流量包订购统一处理";
            timerRun.Enabled = true;
            timerRun.Interval = 1000 * 10;
            timerRun.Tick += new EventHandler(timerRun_Tick);

            Console.WriteLine(DateTime.Now + "商户账户更新处理");
            BaseCode.WriteLog("商户账户更新处理");
            LoadSettingInfo();
            while (true)
            {
                Application.DoEvents();
                if (isLoaded)
                {
                    isLoaded = false;
                    Console.WriteLine(DateTime.Now + "开始订购....");
                    BaseCode.WriteLog("开始订购....");
                    Thread t = new Thread(new ThreadStart(keep_monitiorTest));
                    t.Start();
                }
                Thread.Sleep(10000);
            }
        }
        /// <summary>
        /// 10秒钟一次更新下家账户积分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void timerRun_Tick(object sender, EventArgs e)
        {
            Console.Title = "商户账户更新处理";
            var updateUrl = "http://113.207.124.143/BackupOperate/UpdateAccountTimer.aspx";
            HttpWebRequestTools.GetRequestByHttpWebDefault(updateUrl);
            Console.WriteLine(DateTime.Now + "商户账户更新处理");
        }




        public static FileInfo[] GetFilesAse(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles("*.txt");
            Array.Sort(files, delegate(FileInfo x, FileInfo y) { return x.CreationTime.CompareTo(y.CreationTime); });
            return files;
        }


        #region 循环监控

        public static void keep_monitiorTest()
        {
            try
            {
                Parallel.Invoke(file_ct023, file_cm023, File_All);
            }
            catch (Exception ex)
            {
                BaseCode.WriteLog(ex.Message);
            }
            isLoaded = true;
        }
        #endregion

        public static void keep_monitior()
        {
            try
            {
                Parallel.Invoke(file_cm023, File_01, File_02, File_03, File_04, File_05, File_06, File_07, File_08);
            }
            catch (Exception ex)
            {
                BaseCode.WriteLog(ex.Message);
            }
            isLoaded = true;
        }

        public static void file_cm023()
        {
            if (dm_cm023.t == null || dm_cm023.t.ThreadState == ThreadState.Stopped)
            {
                FileCM023.Start(dm_cm023);
            }
        }

        public static void file_cm023_02()
        {
            if (dm_cm023_02.t == null || dm_cm023_02.t.ThreadState == ThreadState.Stopped)
            {
                FileCM023_02.Start(dm_cm023_02);
            }
        }

        public static void file_cm023_03()
        {
            if (dm_cm023_03.t == null || dm_cm023_03.t.ThreadState == ThreadState.Stopped)
            {
                FileCM023_03.Start(dm_cm023_03);
            }
        }
        public static void file_cm023_04()
        {
            if (dm_cm023_04.t == null || dm_cm023_04.t.ThreadState == ThreadState.Stopped)
            {
                FileCM023_04.Start(dm_cm023_04);
            }
        }

        public static void file_ct023()
        {
            if (dm_ct023.t == null || dm_ct023.t.ThreadState == ThreadState.Stopped)
            {
                FileCT023.Start(dm_ct023);
            }
        }

        public static void File_All()
        {
            if (dm_all.t == null || dm_all.t.ThreadState == ThreadState.Stopped)
            {
                FileWaitting.Start(dm_all);
            }
        }

        public static void File_01()//以文件方式单线程处理订购订单（01）
        {
            if (dm_01.t == null || dm_01.t.ThreadState == ThreadState.Stopped)
            {
                FileWaitting_01.Start(dm_01);
            }
        }

        public static void File_02()//以文件方式单线程处理订购订单（02）
        {
            if (dm_02.t == null || dm_02.t.ThreadState == ThreadState.Stopped)
            {
                FileWaitting_02.Start(dm_02);
            }
        }

        public static void File_03()//以文件方式单线程处理订购订单（03）
        {
            if (dm_03.t == null || dm_03.t.ThreadState == ThreadState.Stopped)
            {
                FileWaitting_03.Start(dm_03);
            }
        }

        public static void File_04()//以文件方式单线程处理订购订单（04）
        {
            if (dm_04.t == null || dm_04.t.ThreadState == ThreadState.Stopped)
            {
                FileWaitting_04.Start(dm_04);
            }
        }

        public static void File_05()//以文件方式单线程处理订购订单（05）
        {
            if (dm_05.t == null || dm_05.t.ThreadState == ThreadState.Stopped)
            {
                FileWaitting_05.Start(dm_05);
            }
        }

        public static void File_06()//以文件方式单线程处理订购订单（06）
        {
            if (dm_06.t == null || dm_06.t.ThreadState == ThreadState.Stopped)
            {
                FileWaitting_06.Start(dm_06);
            }
        }

        public static void File_07()//以文件方式单线程处理订购订单（07）
        {
            if (dm_07.t == null || dm_07.t.ThreadState == ThreadState.Stopped)
            {
                FileWaitting_07.Start(dm_07);
            }
        }

        public static void File_08()//以文件方式单线程处理订购订单（08）
        {
            if (dm_08.t == null || dm_08.t.ThreadState == ThreadState.Stopped)
            {
                FileWaitting_08.Start(dm_08);
            }
        }

        public static void File_Exception()//以文件方式单线程处理订购订单（此文件夹处理订购异常订单，若仍出现异常，则移动至08文件夹继续处理）
        {
            if (dm_ex.t == null || dm_ex.t.ThreadState == ThreadState.Stopped)
            {
                FileException.Start(dm_ex);
            }
        }

        public static void File_CT023BD()//以文件方式单线程处理订购订单（此文件夹处理订购异常订单，若仍出现异常，则移动至08文件夹继续处理）
        {
            if (dm_ct023bd.t == null || dm_ct023bd.t.ThreadState == ThreadState.Stopped)
            {
                FileException.Start(dm_ct023bd);
            }
        }

        public static void FilePush()
        {
            new PushStatusToBusiness().GoToResearch();
        }

        private static void LoadSettingInfo()
        {
            XmlDocument xmlDoc;
            try
            {
                xmlDoc = new XmlDocument();
                xmlDoc.Load(Environment.CurrentDirectory + "/ChannelBaseInfo.xml");
                XmlNode root = xmlDoc.SelectSingleNode("ChannelInfoModels");
                ChannelInfoModels.CM023_04 = new CM023_04();
                ChannelInfoModels.CM023 = new CM023();
                ChannelInfoModels.CM023_02 = new CM023_02();
                ChannelInfoModels.CM023_03 = new CM023_03();
                ChannelInfoModels.Ct023All = new CT023XmlModels();
                ChannelInfoModels.Ct023Pro = new CT023XmlModels();
                foreach (XmlNode item in root.ChildNodes)
                {
                    XmlElement element = (XmlElement)item;
                    if (element.GetAttribute("name").Equals("CM023_04"))
                    {
                        ChannelInfoModels.CM023_04.UserKey = element.GetAttribute("UserKey");
                        ChannelInfoModels.CM023_04.UserSec = element.GetAttribute("UserSec");
                    }
                    if (element.GetAttribute("name").Equals("CM023"))
                    {
                        ChannelInfoModels.CM023.UserKey = element.GetAttribute("UserKey");
                        ChannelInfoModels.CM023.UserSec = element.GetAttribute("UserSec");
                    }
                    if (element.GetAttribute("name").Equals("CM023_02"))
                    {
                        ChannelInfoModels.CM023_02.UserKey = element.GetAttribute("UserKey");
                        ChannelInfoModels.CM023_02.UserSec = element.GetAttribute("UserSec");
                    }
                    if (element.GetAttribute("name").Equals("CM023_03"))
                    {
                        ChannelInfoModels.CM023_03.UserKey = element.GetAttribute("UserKey");
                        ChannelInfoModels.CM023_03.UserSec = element.GetAttribute("UserSec");
                    }

                    if (element.GetAttribute("name").Equals("CT023_A"))
                    {
                        ChannelInfoModels.Ct023All.UserKey = element.GetAttribute("UserKey");
                        ChannelInfoModels.Ct023All.UserSec = element.GetAttribute("UserSec");
                        ChannelInfoModels.Ct023All.Contract = element.GetAttribute("Contract");
                        ChannelInfoModels.Ct023All.ProductType = element.GetAttribute("ProductType");
                        ChannelInfoModels.Ct023All.Url = element.GetAttribute("Urls");
                    }
                    if (element.GetAttribute("name").Equals("CT023_A_O"))
                    {
                        ChannelInfoModels.Ct023Pro.UserKey = element.GetAttribute("UserKey");
                        ChannelInfoModels.Ct023Pro.UserSec = element.GetAttribute("UserSec");
                        ChannelInfoModels.Ct023Pro.Contract = element.GetAttribute("Contract");
                        ChannelInfoModels.Ct023Pro.ProductType = element.GetAttribute("ProductType");
                        ChannelInfoModels.Ct023Pro.Url = element.GetAttribute("Urls");
                    }
                }
            }
            catch (Exception ex)
            {
                BaseCode.WriteLog(ex.Message);
            }
        }

        static CM023DocManager dm_01 = new CM023DocManager();
        static CM023DocManager dm_02 = new CM023DocManager();
        static CM023DocManager dm_03 = new CM023DocManager();
        static CM023DocManager dm_04 = new CM023DocManager();
        static CM023DocManager dm_05 = new CM023DocManager();
        static CM023DocManager dm_06 = new CM023DocManager();
        static CM023DocManager dm_07 = new CM023DocManager();
        static CM023DocManager dm_08 = new CM023DocManager();
        static CM023DocManager dm_ex = new CM023DocManager();
        static CM023DocManager dm_cm023 = new CM023DocManager();
        static CM023DocManager dm_cm023_02 = new CM023DocManager();
        static CM023DocManager dm_cm023_03 = new CM023DocManager();
        static CM023DocManager dm_cm023_04 = new CM023DocManager();
        static CM023DocManager dm_all = new CM023DocManager();
        static CM023DocManager dm_ct023 = new CM023DocManager();
        static CM023DocManager dm_ct023bd = new CM023DocManager();
    }
}
