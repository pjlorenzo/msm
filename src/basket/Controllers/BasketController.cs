using basket.Entities;
using basket.Models;
using basket.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;

        public BasketController(IBasketRepository basketRepository, IProductRepository productRepository)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException();
            _productRepository = productRepository ?? throw new ArgumentNullException();
        }

        [HttpPost("{CustomerId}")]
        public IActionResult Add(string customerId, ProductDTO request)
        {
            var customerBasket = _basketRepository.Get(customerId);
            if (customerBasket == null)
            {
                var product = _productRepository.Get(request.ProductId);
                if (product != null)
                {
                    var basket = new Basket();

                    basket.Add(product.ProductId,product.Price, request.Quantity);
                    return Created("", basket);
                }
                return BadRequest();
            }
            else {
                customerBasket.Add(request.ProductId, 0M, request.Quantity);
                return Ok(customerBasket);
            }
            
        }
    }
}
