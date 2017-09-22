using System.Collections.Generic;
using MONO.Distribution.Model.Sys;

namespace MONO.Distribution.BLL.Interface.Sys
{
  public interface IEnumerationService:IService<Enumerations>
  {
      Enumerations FindById(string key);
      IList<Enumerations> SelectEnumerationsByTypeName(string name);
      IList<Enumerations> SelectEnumerationByCarriers(string name);
  }
}

