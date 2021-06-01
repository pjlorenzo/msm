using basket.Models;
using System.Collections.Generic;
using System.Linq;

namespace basket.Entities
{
    public class QuantityProductDiscount : IDiscount
    {
        private readonly Product _condition;
        private readonly decimal _discount;

        public QuantityProductDiscount(Product condition, decimal discount)
        {
            _condition = condition;
            _discount = discount;
        }
        public decimal Calculate(List<ItemDTO> items)
        {
            var conditionQuantity = items.Where(x => x.ProductId == _condition.Id).Sum(x => x.Quantity);

            return (conditionQuantity / _condition.Quantity) * _discount;
        }

        public bool DiscountApplycable(List<ItemDTO> items)
        {
            var conditionQuantity = items.Where(x => x.ProductId == _condition.Id).Sum(x => x.Quantity);

            return (conditionQuantity == 0 || conditionQuantity < _condition.Quantity) ? false : true;
        }
    }
}
