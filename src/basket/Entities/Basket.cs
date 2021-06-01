using System.Collections.Generic;

namespace basket.Entities
{
    public class Basket
    {   
        public int Id { get; set; }
        public string CustomerId { get; private set; }
        public List<Item> Items { get; set; }
        
        public Basket()
        {  
            Items = new List<Item>();
        }
    }
}