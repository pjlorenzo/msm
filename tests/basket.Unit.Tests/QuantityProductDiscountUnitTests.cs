using basket.Entities;
using basket.Models;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace basket.Unit.Tests
{
    public class QuantityProductDiscountUnitTests
    {
        [Fact]
        public void DiscountApplycable_ShouldReturnTrue()
        {

            var items = new List<ItemDTO>();
            items.Add(new ItemDTO { Id = 1, Price = 1.15m, ProductId = 3, Quantity = 8 });
            

            var milkProductCondition = new Product { Id = 3, Price = 1.15M, Quantity = 4, Description = "Milk" };
            
            new QuantityProductDiscount(milkProductCondition, 0.5M).DiscountApplycable(items).Should().Be(true);

        }

        [Fact]
        public void Given_TheConditionsToApplyTheDiscount_ShouldCalculateDiscount()
        {
            var items = new List<ItemDTO>();
            items.Add(new ItemDTO { Id = 1, Price = 1.15m, ProductId = 3, Quantity = 8 });


            var milkProductCondition = new Product { Id = 3, Price = 1.15M, Quantity = 4, Description = "Milk" };

            var discount = new QuantityProductDiscount(milkProductCondition, 1.15M);

            var total = discount.Calculate(items);

            total.Should().Be(2.30m);
        }
    }
}
