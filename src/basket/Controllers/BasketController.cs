using AutoMapper;
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
        private readonly IEnumerable<IDiscount> _discounts;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepository, IProductRepository productRepository, IEnumerable<IDiscount> discounts, IMapper mapper)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException();
            _productRepository = productRepository ?? throw new ArgumentNullException();
            _discounts = discounts ?? throw new ArgumentNullException();
            _mapper = mapper ?? throw new ArgumentNullException();
        }

        [HttpPost("{CustomerId}")]
        public IActionResult Add(string CustomerId, ProductDTO request)
        {
            var customerBasket = _basketRepository.Get(CustomerId);
            if (customerBasket == null)
            {
                var product = _productRepository.Get(request.ProductId);
                if (product != null)
                {
                    var basketDTO = new BasketDTO(CustomerId, _discounts);

                    basketDTO.Add(product.Id,product.Price, request.Quantity);
                    
                    _basketRepository.Add(basketDTO);

                    return Created("", basketDTO);
                }
               
            }
            else {
                var product = _productRepository.Get(request.ProductId);
                if (product != null)
                {   
                    customerBasket.Add(product.Id, product.Price, request.Quantity);
                    _basketRepository.Update(customerBasket);
                    return Ok(customerBasket);
                }
                
            }
            return BadRequest();
        }
    }
}
