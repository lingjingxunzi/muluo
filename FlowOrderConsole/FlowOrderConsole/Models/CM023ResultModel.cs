using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FlowOrderConsole.Models
{
    public class CM023ResultModel
    {
        public string ReturnCode { get; set; }
        public string ReturnMsg { get; set; }
        public void InitInstance(string str)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(str);
            var selectSingleNode = xmlDoc.SelectSingleNode("//AdvPay//PubInfo");
            var exceptionNode = xmlDoc.SelectSingleNode("//AdvPay//PubInfo//ChargeDetail");
            if (exceptionNode != null)
            {
                XmlNodeList xn0 = exceptionNode.ChildNodes;

                foreach (XmlNode node in xn0)
                {
                    if (node.Name == "OrderStatus")
                    {
                        this.ReturnCode = node.InnerText.Trim().Equals("1") ? "100" : node.InnerText.Trim();
                    }
                    if (node.Name == "FailureSeason")
                    {
                        this.ReturnMsg = node.InnerText.Trim();
                    }
                }
            }
            if (exceptionNode == null && selectSingleNode != null)
            {
                XmlNodeList xn0 = selectSingleNode.ChildNodes;

                foreach (XmlNode node in xn0)
                {
                    if (node.Name == "ReturnCode")
                    {
                        this.ReturnCode = node.InnerText.Trim(); //匹配二级节点的内容
                    }

                    if (node.Name == "ReturnMsg")
                    {
                        this.ReturnMsg = node.InnerText.Trim(); //匹配二级节点的内容
                    }

                }
            }
        }
    }
}
