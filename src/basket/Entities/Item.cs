using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace basket.Entities
{
    public class Item
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public int Quantity { get; set; }

        [NotMapped]
        public decimal Price { get; set; }
    }
}
