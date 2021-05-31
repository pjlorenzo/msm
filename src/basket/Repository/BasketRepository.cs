using basket.Entities;
using System.Linq;

namespace basket.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly BasketDbContext _basketDbContext;

        public BasketRepository(BasketDbContext basketDbContext)
        {
            _basketDbContext = basketDbContext;
        }
        public Basket Get(string CustomerId)
        {
            return _basketDbContext.Baskets.FirstOrDefault(b => b.CustomerId == CustomerId);
        }
    }
}
