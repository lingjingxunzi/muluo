using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using FlowOrderConsole.FlowAgents;
using FlowOrderConsole.Models;
using FlowOrderConsole.Tools.RequestUrl;

namespace FlowOrderConsole.FilePartition
{
    public class FileBase
    { 
        /// <summary>
        /// 初始化队列数据（待处理订购信息）
        /// </summary>
        /// <param name="dm">队列</param>
        /// <param name="readFolder">读取文件文件夹地址</param>
        /// <param name="moveTo">移动文件至文件夹地址</param>
        public static void InitQueInfo(CM023DocManager dm, string readFolder, string moveTo)
        {
            if (dm == null || !dm.IsDoctumentAvailable)
            {
                var i = 0;
                var files = GetFilesAse(readFolder);//按照创建时间升序排列，每次加入队列是10个文件
                try
                {
                    foreach (FileInfo file in files)
                    {
                        if (i > 10) break;
                        var sr = new StreamReader(file.FullName, Encoding.Default);
                        String line;
                        try
                        {
                            while ((line = sr.ReadLine()) != null)
                            {
                                var arr = line.Split(',');
                                if (arr.Length > 0)
                                {
                                    var models = new OrderModels(file.Name, arr[4], arr[1], arr[2], arr[3], arr[5], arr[0], file.CreationTime,(arr.Length ==7 ?arr[6]:""));
                                    dm.AddDocument(models);
                                }
                            }
                            sr.Close();
                            try
                            {
                                MoveFile(file, readFolder, moveTo);
                            }
                            catch (Exception)
                            {
                                file.Delete();
                            }
                        }
                        catch (Exception ex)
                        {
                            sr.Close();
                        }
                        i++;
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        /// <summary>
        /// 移动文件夹
        /// </summary>
        /// <param name="file">当前文件</param>
        /// <param name="beforeFolder">移动前文件夹地址</param>
        /// <param name="moveToFolder">移动后文件夹地址</param>
        public static void MoveFile(FileInfo file, string beforeFolder, string moveToFolder)
        {
            try
            {
                if (Directory.Exists(moveToFolder))
                {
                    Directory.CreateDirectory(moveToFolder);
                }
                var activedFolder = new DirectoryInfo(moveToFolder);
                var defaultFolder = new DirectoryInfo(beforeFolder);
                if (activedFolder.GetFiles(file.Name).Length == 0 && defaultFolder.GetFiles(file.Name).Length == 1)
                {
                    file.CopyTo(moveToFolder + file.Name);
                    file.Delete();
                }
                else
                {
                    file.Delete();
                }
            }
            catch (Exception ex)
            {
                BaseCode.WriteLog(ex.Message + "filename:" + file.Name);
            }
        }

        /// <summary>
        /// 移动文件夹
        /// </summary>
        /// <param name="p">当前文件名称</param>
        /// <param name="ReadFolderName">移动前文件夹地址</param>
        /// <param name="CompleteFolderName">移动后文件夹地址</param>
        public static void MoveFile(string p, string ReadFolderName, string CompleteFolderName)
        {
            try
            {
                if (Directory.Exists(CompleteFolderName))
                {
                    Directory.CreateDirectory(CompleteFolderName);
                }
                var activedFolder = new DirectoryInfo(CompleteFolderName);
                var defaultFolder = new DirectoryInfo(ReadFolderName);
                if (defaultFolder.GetFiles(p).Length == 0) return;
                if (activedFolder.GetFiles(p).Length == 0 && defaultFolder.GetFiles(p).Length == 1)
                {
                    defaultFolder.GetFiles(p)[0].CopyTo(CompleteFolderName + p);
                    defaultFolder.GetFiles(p)[0].Delete();
                }
                else
                {
                    defaultFolder.GetFiles(p)[0].Delete();
                }
            }
            catch (Exception ex)
            {
                BaseCode.WriteLog(ex.Message + "filename:" + p);
            }
        }


        private void MoveFile(string p, string ReadFolderName, string CompleteFolderName, bool isUpdateTime)
        {
            try
            {
                if (Directory.Exists(CompleteFolderName))
                {
                    Directory.CreateDirectory(CompleteFolderName);
                }
                var activedFolder = new DirectoryInfo(CompleteFolderName);
                var defaultFolder = new DirectoryInfo(ReadFolderName);
                if (defaultFolder.GetFiles(p).Length == 0) return;
                
                if (activedFolder.GetFiles(p).Length == 0 && defaultFolder.GetFiles(p).Length == 1)
                {
                    defaultFolder.GetFiles(p)[0].CopyTo(CompleteFolderName + p);
                    defaultFolder.GetFiles(p)[0].Delete();
                }
                else
                {
                    defaultFolder.GetFiles(p)[0].Delete();
                }
            }
            catch (Exception ex)
            {
                BaseCode.WriteLog(ex.Message + "filename:" + p);
            }
        }
        /// <summary>
        /// 读取文件文件按照创建日期升序排列
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static FileInfo[] GetFilesAse(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles("*.txt");
            Array.Sort(files, delegate(FileInfo x, FileInfo y) { return x.CreationTime.CompareTo(y.CreationTime); });
            return files;
        }

       /// <summary>
       /// 获取通知地址
       /// </summary>
       /// <param name="str">请求结果字符串</param>
       /// <param name="backUrl">地址</param>
       /// <param name="orderId">订单ID</param>
       /// <returns></returns>
        public static string GetUrl(string str, string backUrl,string orderId)
        {
            return (string.IsNullOrEmpty(backUrl) ? backUrl : "http://113.207.124.143/Order/GetOrderResultCallBack.aspx") + "?data=" + str + "&TransKey=" + orderId;
        }
    }
}
