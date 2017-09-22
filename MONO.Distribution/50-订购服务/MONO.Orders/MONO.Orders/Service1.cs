using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using MONO.Orders.FlowAgents;
using MONO.Orders.Models;
using MONO.Orders.Tools;


namespace MONO.Orders
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();

            this.ServiceName = "MyServiceForShowTime";
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;

            #region 定时器事件
            Timer aTimer = new Timer();       //System.Timers，不是form的  
            aTimer.Elapsed += new ElapsedEventHandler(TimedEvent);
            aTimer.Interval = 100 * 1000;    //配置文件中配置的秒数  
            aTimer.Enabled = true;
            #endregion
        }

        protected override void OnStart(string[] args)
        {
            FileStream fs = new FileStream(@"d:\mcWindowsService.txt", FileMode.OpenOrCreate, FileAccess.Write);

            StreamWriter m_streamWriter = new StreamWriter(fs);

            m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);

            m_streamWriter.WriteLine("mcWindowsService: Service Started" + DateTime.Now.ToString() + "\n");

            m_streamWriter.Flush();

            m_streamWriter.Close();

            fs.Close();

        }

        protected override void OnStop()
        {
            FileStream fs = new FileStream(@"d:\mcWindowsService.txt", FileMode.OpenOrCreate, FileAccess.Write);

            StreamWriter m_streamWriter = new StreamWriter(fs);

            m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);

            m_streamWriter.WriteLine(" mcWindowsService: Service Stopped " + DateTime.Now.ToString() + "\n");

            m_streamWriter.Flush();

            m_streamWriter.Close();

            fs.Close();

        }


        public static void TimedEvent(object source, ElapsedEventArgs e)         //运行期间执行  
        {
            OrderHelper.operationOrder();
        }

        
    }
}
