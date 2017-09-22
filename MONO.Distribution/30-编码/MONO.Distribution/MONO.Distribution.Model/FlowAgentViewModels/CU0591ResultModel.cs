using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MONO.Distribution.Model.FlowAgentViewModels
{
    public class CU0591ResultModel : VatResultBase
    {
        public string Response { get; set; }

        public string RspCode { get; set; }

        public string RspInfo { get; set; }

        public string RspTime { get; set; }
        public string AccountTime { get; set; }


        public override string GetResult()
        {
            return Response.Equals("0000") ? "0" : Response;
        }

        public override string GetMsg()
        {
            return RspInfo;
        }


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
