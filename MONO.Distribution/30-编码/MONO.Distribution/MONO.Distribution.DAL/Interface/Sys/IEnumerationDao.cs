using System.Collections.Generic;
using MONO.Distribution.Model.Sys;

namespace MONO.Distribution.DAL.Interface.Sys
{
    public interface IEnumerationDao : IDao<Enumerations>
    {

        Enumerations FindById(string key);

        IList<Enumerations> SelectEnumerationsByTypeName(string name);

        IList<Enumerations> SelectEnumerationByCarriers(string name);
    }
}

