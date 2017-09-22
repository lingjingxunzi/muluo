using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MONO.Order.Test.Models
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
             
            if (selectSingleNode != null)
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
