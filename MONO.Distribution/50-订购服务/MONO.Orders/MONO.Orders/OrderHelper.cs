using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MONO.Orders.FlowAgents;
using MONO.Orders.Models;
using MONO.Orders.Tools;

namespace MONO.Orders
{
    public class OrderHelper
    {
        public static void operationOrder()
        {
            var folder = new DirectoryInfo("E://Distribution//Waitting");

            foreach (FileInfo file in folder.GetFiles("*.txt"))
            {
                var sr = new StreamReader(file.FullName, Encoding.Default);
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    var arr = line.Split(',');
                    if (arr.Length > 0)
                    {
                        var instance = AgentManager.GetAgentInstance(arr[0]);
                        var param = new AgentParamBase
                        {
                            MobilePhone = arr[2],
                            HistoriesKey = arr[3],
                            Carrier = arr[0],
                            ProductId = arr[1],
                            PakgeSize = int.Parse(arr[4])
                        };
                        var str = instance.AgentRequest(param);
                        var url = "http://test.5liuba.cn/Order/GetOrderResultCallBack.aspx?data=" + str + "&TransKey=" + arr[3];
                        HttpWebRequestTools.GetRequestByHttpWeb(url);
                    }
                }
                sr.Close();
                file.CopyTo("E://Distribution//Actived//"+file.Name);
                file.Delete();
                break;
            }
        }
    }
}
