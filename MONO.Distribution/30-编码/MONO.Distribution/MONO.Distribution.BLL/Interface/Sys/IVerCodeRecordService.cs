using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.DAL.Sys;
using MONO.Distribution.Model.Sys;

namespace MONO.Distribution.BLL.Interface.Sys
{
    public interface IVerCodeRecordService : IService<VerCodeRecords>
    {
        IList<VerCodeRecords> SelectVerCodeByIP(string IP);

        void Delete(string VerCodeKey);
    }
}
