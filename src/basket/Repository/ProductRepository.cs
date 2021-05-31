using basket.Entities;
using System.Linq;

namespace basket.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly BasketDbContext _basketDbContext;

        public ProductRepository(BasketDbContext basketDbContext)
        {
            _basketDbContext = basketDbContext;
        }
        public Product Get(int id)
        {
            return _basketDbContext.Products.FirstOrDefault(p => p.ProductId == id);
        }
    }
}
