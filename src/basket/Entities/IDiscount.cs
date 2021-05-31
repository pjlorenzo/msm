using System.Collections.Generic;

namespace basket.Entities
{
    public interface IDiscount
    {
        bool DiscountApplycable(List<Item> items);
        decimal Calculate(List<Item> items);
    }
}
