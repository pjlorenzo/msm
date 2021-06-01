using basket.Entities;
using basket.Models;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace basket.Unit.Tests
{
    public class BasketDTOUnitTests
    {
        private readonly string _customerId;
        private readonly IEnumerable<IDiscount> _discount;
        private readonly BasketDTO _basket;

        public BasketDTOUnitTests()
        {
            _customerId = "123456789";
            _discount = A.Fake<IEnumerable<IDiscount>>();
            _basket = new BasketDTO(_customerId, _discount);
        }
        [Fact]
        public void Constructor_GivenNullCustomerId_ThrowsArgumentNullException()
        {
            Action constructor = () => new BasketDTO(null,_discount);
            constructor.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_GivenNullIDiscount_ThrowsArgumentNullException()
        {
            Action constructor = () => new BasketDTO(_customerId, null);
            constructor.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Basket_Add_ShouldAddtheItemToTheBasket()
        {
            _basket.Add(1,0.80M,1);

            _basket.Items.Count.Should().Be(1);
        }

        [Fact]
        public void Basket_Total_ShouldCalculateTheTotalInTheBasket()
        {
            
            _basket.Add(1, 0.80M, 1);
            _basket.Add(2, 1.15M, 1);
            _basket.Add(3, 1M, 1);

            _basket.Total.Should().Be(2.95M);
            _basket.Items.Count.Should().Be(3);
        }
    }
}
