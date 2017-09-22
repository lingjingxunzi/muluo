using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MONO.Distribution.Utility
{
    public class GetPhoneFromsHandler
    {

        private GetPhoneFromsHandler()
        {
            titleDic.Clear();

            var cmArr = "134,135,136,137,138,139,150,151,152,157,158,159,182,183,184,187,178,188,147,1705";
            var cuArr = "130,131,132,145,155,156,176,185,186,1709";
            var ctArr = "133,153,177,180,181,189,1349,1700";
            foreach (var item in cmArr.Split(','))
            {
                titleDic.Add(item, "CM");
            }
            foreach (var item in cuArr.Split(','))
            {
                titleDic.Add(item, "CU");
            }
            foreach (var item in ctArr.Split(','))
            {
                titleDic.Add(item, "CT");
            }
        }


        public static GetPhoneFromsHandler GetInstance()
        {
            if (_instance == null)
                _instance = new GetPhoneFromsHandler();
            return _instance;
        }

        public string GetFroms(string userPhone)
        {
            try
            {
                return titleDic[userPhone.Substring(0, 3)];
            }
            catch (Exception)
            {
                try
                {
                    return titleDic[userPhone.Substring(0, 4)];
                }
                catch (Exception)
                {

                    return "";
                }
            }
        }

        private static GetPhoneFromsHandler _instance = null;

        private IDictionary<string, string> titleDic = new Dictionary<string, string>();
    }
}
