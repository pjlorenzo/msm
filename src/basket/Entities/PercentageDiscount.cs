using basket.Models;
using System.Collections.Generic;
using System.Linq;

namespace basket.Entities
{
    public class PercentageDiscount : IDiscount
    {
        private readonly Product _productTarget;
        private readonly decimal _discount;
        private readonly Product _condition;

        public PercentageDiscount(Product productTarget, decimal discount, Product condition)
        {
            _productTarget = productTarget;
            _discount = discount;
            _condition = condition;
        }
        public decimal Calculate(List<ItemDTO> items)
        {
            
            var requiredItemsForDiscount = items.Where(p => p.ProductId == _condition.Id).Sum(q => q.Quantity);
            var applyDiscountToCount = items.Where(p => p.ProductId == _productTarget.Id).Sum(q => q.Quantity);
            var targetProduct = items.FirstOrDefault(p => p.ProductId == _productTarget.Id);

            if (applyDiscountToCount == 0)
                return 0;

            var discountApplicables = requiredItemsForDiscount / _condition.Quantity;

            if (applyDiscountToCount <= discountApplicables)
            {
                discountApplicables = discountApplicables - (discountApplicables - applyDiscountToCount);
            }

            var discountAmount = (_discount) * targetProduct.Price;

            return discountApplicables * discountAmount;
        }

        public bool DiscountApplycable(List<ItemDTO> items)
        {
            //butter id =1
            var requiredItemsForDiscount = items.Where(p => p.ProductId == _condition.Id).Sum(q=>q.Quantity);

            return (requiredItemsForDiscount == 0 || requiredItemsForDiscount < 2) ? false : true; 

        } 
    }
}