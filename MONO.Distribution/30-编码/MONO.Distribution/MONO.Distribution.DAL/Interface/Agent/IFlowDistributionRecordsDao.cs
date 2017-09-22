using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.Model.Agent;

namespace MONO.Distribution.DAL.Interface.Agent
{
    public interface IFlowDistributionRecordsDao : IDao<FlowDistributionRecords>
    {
        FlowDistributionRecords FindById(string p);

        IList<FlowDistributionRecords> SelectDistributionRecordListForQueryBySysUserKey(FlowDistributionRecords condition);

        IList<FlowDistributionRecords> SelectTransIdIsExistsCount(string BatchNo);

        IList<FlowDistributionRecords> SelectDistributionRecordForIntergalList(FlowDistributionRecords condition);



        int SelectDistributionRecordForIntergalCount(FlowDistributionRecords condition);
    }
}
