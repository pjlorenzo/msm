﻿namespace basket.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        public Product()
        {

        }

    }
}