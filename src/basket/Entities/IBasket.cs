using System.Collections.Generic;

namespace basket.Entities
{
    public interface IBasket
    {
        string CustomerId { get; }
        List<Item> Items { get; }

        decimal Total { get; }

        void Add(int productId, decimal price, int quantity);
        
    }
}