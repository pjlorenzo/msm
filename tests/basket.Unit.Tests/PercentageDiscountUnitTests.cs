using basket.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace basket.Unit.Tests
{
    public class PercentageDiscountUnitTests
    {
        [Fact]
        public void DiscountApplycable_ShouldReturnTrue()
        {

            var items = new List<Item>();
            items.Add(new Item { Id = 1, Price = 0.80m, ProductId = 1, Quantity = 2 });
            items.Add(new Item { Id = 2, Price = 0.80m, ProductId = 2, Quantity = 2 });

            new PercentageDiscount().DiscountApplycable(items).Should().Be(true);
            
        }

        [Fact]
        public void Given_TheConditionsToApplyTheDiscount_ShouldCalculateDiscount()
        {
            var items = new List<Item>();
            items.Add(new Item { Id = 1, Price = 0.80m, ProductId = 1, Quantity = 2 });
            items.Add(new Item { Id = 2, Price = 0.80m, ProductId = 2, Quantity = 2 });

            var discount = new PercentageDiscount();

            var total = discount.Calculate(items);

            total.Should().Be(0.50m);
        }
    }
}
