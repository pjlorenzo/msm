using System;
using System.Collections.Generic;
using System.Linq;

namespace basket.Entities
{
    public class PercentageDiscount : IDiscount
    {
        public decimal Calculate(List<Item> items)
        {
            // bread = 2
            var requiredItemsForDiscount = items.Where(p => p.ProductId == 1).Sum(q => q.Quantity);
            var applyDiscountToCount = items.Where(p => p.ProductId == 2).Sum(q => q.Quantity);
            var targetProduct = items.FirstOrDefault(p => p.ProductId == 2);

            var discountApplicables = requiredItemsForDiscount / 2;

            if (applyDiscountToCount <= discountApplicables)
            {
                discountApplicables = discountApplicables - (discountApplicables - applyDiscountToCount);
            }

            var discountAmount = (0.5M) * targetProduct.Price;

            return discountApplicables * discountAmount;
        }

        public bool DiscountApplycable(List<Item> items)
        {
            //butter id =1
            var requiredItemsForDiscount = items.Where(p => p.ProductId == 1).Sum(q=>q.Quantity);

            return (requiredItemsForDiscount == 0 || requiredItemsForDiscount < 2) ? false : true; 

        } 
    }
}