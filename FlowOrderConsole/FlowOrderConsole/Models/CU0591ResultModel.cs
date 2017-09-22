using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FlowOrderConsole.Models
{
    public class CU0591ResultModel 
    {
        public string Response { get; set; }

        public string RspCode { get; set; }

        public string RspInfo { get; set; }

        public string RspTime { get; set; }
        public string AccountTime { get; set; }
     

        public void InitInstance(string str)
        {
            XmlDocument xmlDoc = new XmlDocument();
            //如果是xml字符串，则用以下形式
            xmlDoc.LoadXml(str);

            var selectSingleNode = xmlDoc.SelectSingleNode("Response");
            if (selectSingleNode != null)
            {
                XmlNodeList xn0 = selectSingleNode.ChildNodes;

                foreach (XmlNode node in xn0)
                {
                    if (node.Name == "RspCode")
                    {
                        this.RspCode = node.InnerText.Trim(); //匹配二级节点的内容
                    }

                    if (node.Name == "RspInfo")
                    {
                        RspInfo = node.InnerText.Trim(); //匹配二级节点的内容
                    }

                }
            }
        }
    }
}
