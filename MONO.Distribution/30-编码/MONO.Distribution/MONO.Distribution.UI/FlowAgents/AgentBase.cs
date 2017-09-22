using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using MONO.Distribution.BLL.Interface.Sys;
using MONO.Distribution.BLL.Sys;
using MONO.Distribution.Model.AgentModel;
using MONO.Distribution.Model.Sys;
using MONO.Distribution.Utility;
using MONO.FB.BLL.Sys;

namespace MONO.Distribution.UI.FlowAgents
{
    public abstract class AgentBase
    {

        public abstract IList<AgentResultBase> ValidateInfo(AgentParamBase param);

        public abstract IList<AgentResultBase> ExecutiveOrder(AgentParamBase param);

        protected string SHA1(string text)
        {
            byte[] cleanBytes = Encoding.Default.GetBytes(text);
            byte[] hashedBytes = System.Security.Cryptography.SHA1.Create().ComputeHash(cleanBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "");
        }


        protected virtual bool CheckIpBind(string account)
        {
            var ip = GetIPHelper.GetIP();
            logMsg.Info("商户IP：" + ip);
            var info = _SystemUsersService.FindAll(new SystemUsers { Account = account });
            if (info != null && info.Count > 0)
            {
                var ipInfo = _businessIpBindService.FindAll(new BusinessIPBind { SysUserKey = info[0].SysUserKey });
                if (ipInfo == null || ipInfo.Count == 0) return false;
                if (ipInfo.Count > 0)
                {
                    if (_businessIpBindService.GetCount(new BusinessIPBind { IP = ip, SysUserKey = info[0].SysUserKey }) > 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //protected IFB_BusinessIPBindService _BusinessIpBindService = new FB_BusinessIPBindService();
        protected ISystemUsersService _SystemUsersService = new SystemUsersService();
        protected ILog logMsg;
        private IBusinessIPBindService _businessIpBindService = new FB_BusinessIPBindService();

    }
}