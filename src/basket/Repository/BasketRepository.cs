using AutoMapper;
using basket.Entities;
using basket.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace basket.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly BasketDbContext _basketDbContext;
        private readonly IMapper _mapper;

        public BasketRepository(BasketDbContext basketDbContext, IMapper mapper)
        {
            _basketDbContext = basketDbContext;
            _mapper = mapper;
        }

        public void Add(BasketDTO basketDTO)
        {
            var basket = _mapper.Map<Basket>(basketDTO);
            _basketDbContext.Add(basket);
            _basketDbContext.SaveChanges();
        }

        public BasketDTO Get(string CustomerId)
        {
            var basket = _basketDbContext.Baskets.Include(b => b.Items).ThenInclude(o=> o.Product).FirstOrDefault(b => b.CustomerId == CustomerId);

            var basketDTO = _mapper.Map<BasketDTO>(basket);

            return basketDTO;
        }

        public void Update(BasketDTO basketDTO)
        {
                      
            
            _basketDbContext.SaveChanges();
        }
    }
}
