using basket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basket.Repository
{
    public interface IBasketRepository
    {
        Basket Get(string CustomerId);
    }
}
