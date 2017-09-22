using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using FlowOrderConsole.FlowAgents;
using FlowOrderConsole.Models;
using FlowOrderConsole.Tools;
using System.IO;

namespace FlowOrderConsole
{
    public class CM023DocProcess
    {
        private CM023DocManager documentManager;
        public CM023DocProcess(CM023DocManager dm)
        {
            this.documentManager = dm;
        }
        public static void Start(CM023DocManager dm)
        {
            new Thread(new CM023DocProcess(dm).Run).Start();
        }
        public void Run()
        {
            while (true)
            {
                if (documentManager.IsDoctumentAvailable)
                {
                    OrderModels doc = documentManager.GetDocument();
                    var instance = AgentManager.GetAgentInstance(doc.Carrier);
                    var param = new AgentParamBase
                    {
                        MobilePhone = doc.Mobile,
                        HistoriesKey = doc.HisKey,
                        Carrier = doc.Carrier,
                        ProductId = doc.Code,
                        PakgeSize = int.Parse(doc.Size)
                    };
                    var str = instance.AgentRequest(param);
                    if (!string.IsNullOrEmpty(str))
                    {
                           var cm023result = new CM023ResultModel();
                           try
                           {
                               BaseCode.WriteLog(doc.Name+"请求返回:"+str);
                               cm023result.InitInstance(str);
                           }
                            catch (Exception ex)
                            {    
                                

                                var exFolder = new DirectoryInfo("E://Distribution//exception");

                                if (exFolder.GetFiles(doc.Name).Length == 0)
                                {
                                    file.CopyTo("E://Distribution//exception//" + file.Name);
                                    file.Delete();
                                }
                                else
                                {
                                    file.Delete();
                                }
                                break;
                            }
                            str = "{\"ReturnCode\":\"" + cm023result.ReturnCode + "\",\"ReturnMsg\":\"" + cm023result.ReturnMsg + "\"}";
                        }
                    }
                }
            }
        }
    }
}
