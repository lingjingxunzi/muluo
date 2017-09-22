using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MONO.Distribution.Model.Agent;

namespace MONO.Distribution.DAL.Interface.Agent
{
    public interface ICarrierMaintainDetailDao : IDao<CarrierMaintainDetails>
    {
        CarrierMaintainDetails SelectCarrierMaintainDetailsByFlowKey(int key);
    }
}
