using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basket.Entities
{
    public class Promotion1 : IDiscount
    {
        public Promotion1()
        {
        }

        public decimal Calculate(List<Item> items)
        {
            throw new NotImplementedException();
        }

        public bool DiscountApplycable(List<Item> items)
        {
            throw new NotImplementedException();
        }
    }
}
