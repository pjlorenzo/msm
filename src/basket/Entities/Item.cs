using System.ComponentModel.DataAnnotations.Schema;

namespace basket.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
