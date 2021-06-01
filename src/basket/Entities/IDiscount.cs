using basket.Models;
using System.Collections.Generic;

namespace basket.Entities
{
    public interface IDiscount
    {
        bool DiscountApplycable(List<ItemDTO> items);
        decimal Calculate(List<ItemDTO> items);
    }
}
