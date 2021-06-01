using basket.Entities;
using basket.Models;
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

            var items = new List<ItemDTO>();
            items.Add(new ItemDTO { Id = 1, Price = 0.80m, ProductId = 1, Quantity = 2 });
            items.Add(new ItemDTO { Id = 2, Price = 0.80m, ProductId = 2, Quantity = 2 });

            var butter = new Product { Id = 1, Price = 0.80M, Quantity = 2, Description = "Butter" };
            var bread = new Product { Id = 2, Price = 1M, Quantity = 2, Description = "Bread" };

            new PercentageDiscount(bread,0.5M,butter).DiscountApplycable(items).Should().Be(true);
            
        }

        [Fact]
        public void Given_TheConditionsToApplyTheDiscount_ShouldCalculateDiscount()
        {
            var items = new List<ItemDTO>();
            items.Add(new ItemDTO { Id = 1, Price = 0.80m, ProductId = 1, Quantity = 2 });
            items.Add(new ItemDTO { Id = 2, Price = 1m, ProductId = 2, Quantity = 1 });

            var butterConditionProduct = new Product { Id = 1, Price = 0.80M, Quantity = 2, Description = "Butter" };
            var breadTargetDiscountProduct = new Product { Id = 2, Price = 1M, Quantity = 2, Description = "Bread" };

            var discount = new PercentageDiscount(breadTargetDiscountProduct, 0.5M, butterConditionProduct);

            var total = discount.Calculate(items);

            total.Should().Be(0.50m);
        }

        [Fact]
        public void Given_TheConditionsToApplyTheDiscountAndTheDiscountedProductDoesNotExit_ShouldCalculateDiscount()
        {
            var items = new List<ItemDTO>();
            items.Add(new ItemDTO { Id = 1, Price = 0.80m, ProductId = 1, Quantity = 2 });
           

            var butterConditionProduct = new Product { Id = 1, Price = 0.80M, Quantity = 2, Description = "Butter" };
            var breadTargetDiscountProduct = new Product { Id = 2, Price = 1M, Quantity = 2, Description = "Bread" };

            var discount = new PercentageDiscount(breadTargetDiscountProduct, 0.5M, butterConditionProduct);

            var total = discount.Calculate(items);

            total.Should().Be(0m);
        }
    }
}
