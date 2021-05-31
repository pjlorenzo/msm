using System;
using System.Collections.Generic;
using System.Linq;

namespace basket.Entities
{
    public class Basket
    {

        public string CustomerId { get; private set; }
        public List<Product> Products { get; internal set; }

        public Basket(string customerId)
        {
            CustomerId = customerId ?? throw new ArgumentNullException();
            Products = new List<Product>();
        }

        public void Add(string productId, decimal price, int quantity)
        {
            Products.Add(new Product(productId, price, quantity));
        }

        public decimal Total()
        {
            return Products.Sum(p => p.Quantity * p.Price);
        }
    }
}