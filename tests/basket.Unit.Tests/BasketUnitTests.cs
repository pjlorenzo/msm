using basket.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace basket.Unit.Tests
{
    public class BasketUnitTests
    {
        [Fact]
        public void Constructor_GivenNullCustomerId_ThrowsArgumentNullException()
        {
            Action constructor = () => new Basket(null);
            constructor.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Basket_Add_ShouldAddtheItemToTheBasket()
        {
            var customerId = "123456789";
            var basket = new Basket(customerId);

            basket.Add("1",0.80M,1);

            basket.Products.Count.Should().Be(1);
        }

        [Fact]
        public void Basket_Total_ShouldCalculateTheTotalInTheBasket()
        {
            var customerId = "123456789";
            var basket = new Basket(customerId);

            basket.Add("1", 0.80M, 1);
            basket.Add("2", 1.15M, 1);
            basket.Add("3", 1M, 1);

            basket.Total().Should().Be(2.95M);
        }
    }
}
