using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace basket.Entities
{
    public class Basket : IBasket
    {

        public int Id { get; set; }
        public string CustomerId { get; private set; }
        public List<Item> Items { get; set; }
        [NotMapped]
        public decimal Total { get; set; }

        public Basket()
        {
            Items = new List<Item>();
        }

        public Basket(string customerId, IDiscount discount) : base()
        {
            CustomerId = customerId ?? throw new ArgumentNullException();
            Items = new List<Item>();
        }

        public void Add(int productId, decimal price, int quantity)
        {
            Items.Add(new Item { ProductId = productId, Price = price, Quantity = quantity });

            Total = CalculateTotal();
        }

        internal decimal CalculateTotal()
        {
            return Items.Sum(p => p.Quantity * p.Price);
        }
    }
}