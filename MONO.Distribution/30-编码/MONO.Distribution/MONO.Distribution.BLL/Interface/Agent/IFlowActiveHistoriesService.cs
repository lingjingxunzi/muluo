﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.Model.Agent;
using MONO.Distribution.Utility;

namespace MONO.Distribution.BLL.Interface.Agent
{
    public interface IFlowActiveHistoriesService : IService<FlowActiveHistories>
    {
        FlowActiveHistories FindById(string transKey);
        FlowActiveHistories SelectFlowActiveHistoriesByOrderId(string orders);
        ResultMessage UpdateHistoryStatus(FlowActiveHistories entity);
        void  Test(FlowActiveHistories entity);
    }
}
