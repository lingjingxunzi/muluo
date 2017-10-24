using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;

namespace CoolShow.Common.Log
{
    public class LogMessage : IRequiresSessionState
    {
        public LogMessage(string message)
            : this()
        {
            Message = message;
        }

        public LogMessage()
        {
            this.UserId = MyContext.Instance.UserId.ToString();
            this.UserName = MyContext.Instance.UserName;
            this.IP = string.IsNullOrEmpty(IPUtil.GetUserIP()) ? "" : IPUtil.GetUserIP();
            //this.PhysicalAddress = GetPhysicalAddress(IPUtil.GetUserIP());
            this.PhysicalAddress ="127.0.0.1";
        }

        public string UserId
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string IP
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public string PhysicalAddress
        {
            get;
            set;
        }

        public string Exception
        {
            get;
            set;
        }
        public override string ToString()
        {
            return Message.ToString();
        }

        private string GetPhysicalAddress(string mip)
        {
            var items = HttpContext.Current.Application["IpPhysicalAddress"] as IList<Hashtable>;

            foreach (var hashtable in items)
            {
                if (hashtable["IP"].ToString() == mip)
                {
                    return hashtable["PhysicalAddress"].ToString();
                }
            }
            var physicalAddress = IPUtil.GetPhysicalAddressByIp(mip);
            if (!string.IsNullOrEmpty(physicalAddress))
            {
                Hashtable item = new Hashtable();
                item.Add("IP", mip);
                item.Add("PhysicalAddress", physicalAddress);
                items.Add(item);
                HttpContext.Current.Application["IpPhysicalAddress"] = items;
            }

            return physicalAddress;
        }
    }
}
