using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MONO.Order.Test.Models;
using MONO.Order.Test.Tools;

namespace MONO.Order.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = int.Parse(textBox1.Text) * 1000;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            //OrderHelper.operationOrder();
            btnStop.Enabled = true;
            btnStart.Enabled = false;
            //timBackup.Start();
            //timOpera.Start();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //timer1.Stop();
            
            //timBackup.Stop();
            //timOpera.Stop();
            timer1.Interval = int.Parse(textBox1.Text) * 1000;
            timBackup.Interval = int.Parse(textBox1.Text) * 1000;
            timOpera.Interval = int.Parse(textBox1.Text) * 1000;
            timer1.Start();
            //timBackup.Start();
            //timOpera.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            btnStop.Enabled = false;
            btnStart.Enabled = true;
        }

        private void OnTick_Click(object sender, EventArgs e)
        {
            try
            {
                OrderHelper.operationOrder();
            }
            catch (Exception ex)
            {

            }
        }

        private void timBackup_Tick(object sender, EventArgs e)
        {
            var folder = new DirectoryInfo("E://Distribution//Backups");
            foreach (FileInfo file in folder.GetFiles("*.txt"))
            {
                var sr = new StreamReader(file.FullName, Encoding.Default);
                String line;

                while ((line = sr.ReadLine()) != null)
                {
                    var arr = line.Split(',');
                    if (arr.Length > 0)
                    {
                        var param = new BackupViewModel
                      {
                          DataBackupKey = arr[0],
                          BackNumber = arr[1],
                          BackStyle = arr[2],
                          BackupTime = arr[3],
                          BackupUrl = arr[4],
                          Cycle = arr[5],
                          TableName = arr[6],
                          Style = arr[7],
                          BackupNextDate = Convert.ToDateTime(arr[3])
                      };
                        if (param.Style.Equals("ADD"))
                        {
                            backupClycleViewModels.Add(param);
                        }
                        if (param.Style.Equals("Del"))
                        {
                            backupClycleViewModels.Remove(param);
                        }
                    }
                }
                sr.Close();
                file.CopyTo("E://Distribution//BackupFolderExist//" + file.Name);
                file.Delete();
                break;
            }
        }

        private void timOpera_Tick(object sender, EventArgs e)
        {
            backupClycleViewModels = backupClycleViewModels.OrderBy(m => m.BackupNextDate).ToList();
            if (backupClycleViewModels.Count > 0)
            {
                var current = backupClycleViewModels.First();
                if (current.BackupNextDate <= DateTime.Now)
                {
                    var url = "http://113.207.124.164/BackupOperate/BackupDatabase.aspx?Id=" + current.BackNumber;
                    HttpWebRequestTools.GetRequestByHttpWebDefault(url);
                    if (current.Cycle.Equals("OnceTime"))
                    {
                        backupClycleViewModels.Remove(current);
                    }
                    if (current.Cycle.Equals("OnceAWeek"))
                    {
                        backupClycleViewModels.First().BackupNextDate = current.BackupNextDate.AddDays(7);
                    }
                    if (current.Cycle.Equals("OnceAWeek"))
                    {
                        backupClycleViewModels.First().BackupNextDate = current.BackupNextDate.AddMonths(1);
                    }
                }
            }

        }

        IList<BackupViewModel> backupClycleViewModels = new List<BackupViewModel>();
    }
}
