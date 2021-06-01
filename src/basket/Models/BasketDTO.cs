using basket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace basket.Models
{
    public class BasketDTO
    {
        private readonly IEnumerable<IDiscount> _discounts;

        public int Id { get; set; }
        public string CustomerId { get; set; }
        public List<ItemDTO> Items { get; set; }
        public decimal Total { get; set; }

        public BasketDTO()
        {
            Items = new List<ItemDTO>();
            var _di = new List<IDiscount>();
            var butterConditionProduct = new Product { Id = 1, Price = 0.80M, Quantity = 2, Description = "Butter" };
            var breadTargetDiscountProduct = new Product { Id = 3, Price = 1M, Quantity = 2, Description = "Bread" };
            _di.Add(new PercentageDiscount(breadTargetDiscountProduct, 0.5M, butterConditionProduct));
            var milkProductCondition = new Product { Id = 2, Price = 1.15M, Quantity = 4, Description = "Milk" };
            _di.Add(new QuantityProductDiscount(milkProductCondition, 1.15M));

            _discounts = _di.AsEnumerable<IDiscount>();
            
        }

        public BasketDTO(string customerId, IEnumerable<IDiscount> discounts)
        {
            CustomerId = customerId ?? throw new ArgumentNullException();
            _discounts = discounts ?? throw new ArgumentNullException();
            Items = new List<ItemDTO>();
        }

        public void Add(int productId, decimal price, int quantity)
        {
            if (Items.Any(p => p.ProductId == productId))
            {
                Items.FirstOrDefault(p => p.ProductId == productId).Quantity += quantity; 
            }
            else
            {
                Items.Add(new ItemDTO { ProductId = productId, Price = price, Quantity = quantity });
            }
            Total = CalculateTotal();
        }

        internal decimal CalculateTotal()
        {
            var total = Items.Sum(p => p.Quantity * p.Price);
            foreach (var discount in _discounts)
            {
                if (discount.DiscountApplycable(Items))
                {
                    total = total - discount.Calculate(Items);

                }
            }

            return total;
        }
    }
}
