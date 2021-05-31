using System;
using System.Collections.Generic;
using System.Linq;

namespace basket.Entities
{
    public class PercentageDiscount : IDiscount
    {
        public decimal Calculate(List<Item> items)
        {
            throw new NotImplementedException();
        }

        public bool DiscountApplycable(List<Item> items)
        {
            //butter id =1
            //var requiredItemsForDiscount = items.Where(p => p.ProductId == 1).ToList();
            //var minimunRequiredItems = requiredItemsForDiscount.Sum(p => p.Quantity);

            // bread id =2
            var itemToApplyTheDiscount = items.Where(p => p.ProductId == 2).ToList();
            var minimunRequiredItemsToApplyDiscount = itemToApplyTheDiscount.Sum(p => p.Quantity);

            if (MinimunRequiredItems(items) || minimunRequiredItemsToApplyDiscount < 1)
            { return false; }
            else
            {
                return true;            
            }
        }

        private bool MinimunRequiredItems(List<Item> items)
        {
            var requiredItemsForDiscount = items.Where(p => p.ProductId == 1).ToList();
            var minimunRequiredItems = requiredItemsForDiscount.Sum(p => p.Quantity);

            return minimunRequiredItems == 0 || minimunRequiredItems < 2 ? false : true;
        }
    }
}