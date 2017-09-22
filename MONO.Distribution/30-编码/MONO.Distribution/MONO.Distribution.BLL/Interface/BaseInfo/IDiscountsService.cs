using MONO.Distribution.Model.BaseInfo;

namespace MONO.Distribution.BLL.Interface.BaseInfo
{
  public interface IDiscountsService:IService<Discounts>
  {
      Discounts SelectDiscountsByDeduction(decimal deduction);
  }
}

