using basket.Controllers;
using basket.Entities;
using basket.Models;
using basket.Repository;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace basket.Unit.Tests.Controllers
{
    public class BasketControllerTests
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;

        public BasketControllerTests()
        {
            _basketRepository = A.Fake<IBasketRepository>();
            _productRepository = A.Fake<IProductRepository>();

        }
        [Fact]
        public void ShouldBeAssignableToController()
        {
            typeof(BasketController).Should().BeAssignableTo<Controller>();
        }

        [Fact]
        public void ShouldBeDecoratedWithApiControllerAttribute()
        {
            typeof(BasketController).Should().BeDecoratedWith<ApiControllerAttribute>();
        }

        [Fact]
        public void Constructor_GivenANullBasketRepository_ShouldThrowArgumentNullExcepton()
        {
            Action controller = () => new BasketController(null,_productRepository);
            controller.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_GivenANullProductRepository_ShouldThrowArgumentNullExcepton()
        {
            Action controller = () => new BasketController(_basketRepository, null);
            controller.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Add_GivenaValidRequest_WhenCustomerAddFirstItem_ShouldReturn201()
        {
            var request = new ProductDTO {ProductId = 1, Quantity= 1 };
            var customerId = "123456789";

            A.CallTo(() => _basketRepository.Get(A<string>.Ignored)).Returns(null);

            var _controller = new BasketController(_basketRepository,_productRepository);

            var response = _controller.Add(customerId, request) as CreatedResult;

            response.Should().NotBeNull();

            response.StatusCode.Should().Be((int)HttpStatusCode.Created);

        }

        [Fact]
        public void Add_GivenaValidRequest_WhenCustomerAddSecondItem_ShouldReturn200()
        {
            var request = new ProductDTO { ProductId = 2, Quantity = 1 };
            var customerId = "123456789";

            var basket = new Basket();
            basket.Add(1, 1.23M, 1);

            A.CallTo(() => _basketRepository.Get(A<string>.Ignored)).Returns(basket);

            var _controller = new BasketController(_basketRepository, _productRepository);

            var response = _controller.Add(customerId, request) as OkObjectResult;

            response.Should().NotBeNull();

            response.StatusCode.Should().Be((int)HttpStatusCode.OK);
            ((Basket)response.Value).Items.Count.Should().Be(2);
            

        }
    }
}
