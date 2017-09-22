using MONO.Distribution.Model.BaseInfo;

namespace MONO.Distribution.DAL.Interface.BaseInfo
{
    public interface IDiscountsDao : IDao<Discounts>
    {

       

        Discounts SelectDiscountsByDeduction(decimal deduction);
    }
}

