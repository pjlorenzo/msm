using basket.Entities;
using basket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basket.Repository
{
    public interface IBasketRepository
    {
        BasketDTO Get(string CustomerId);
        void Add(BasketDTO basket);
        void Update(BasketDTO basket);
    }
}
