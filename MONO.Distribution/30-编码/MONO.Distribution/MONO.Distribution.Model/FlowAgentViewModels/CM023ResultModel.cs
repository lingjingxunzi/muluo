using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MONO.Distribution.Model.FlowAgentViewModels
{
    public class CM023ResultModel : VatResultBase
    {
        public string ReturnCode { get; set; }
        public string ReturnMsg { get; set; }
        public string OrderId { get; set; }

        public override string GetOrders()
        {
            return OrderId;
        }


        public override string GetMsg()
        {
            return ReturnMsg;

        }

        public override string GetResult()
        {
            return string.IsNullOrEmpty(ReturnCode) ? "99999" : (ReturnCode.Equals("100") ? "0" : ReturnCode);
        }

        public void InitInstance(string str)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(str);
            var selectSingleNode = xmlDoc.SelectSingleNode("PubInfo");
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
