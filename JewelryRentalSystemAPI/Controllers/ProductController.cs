using AutoMapper;
using JewelryRentalSystemAPI.DTO;
using JewelryRentalSystemAPI.Interface;
using JewelryRentalSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace JewelryRentalSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Product>))]
        public IActionResult GetProducts()
        {
            var products = _mapper.Map<List<ProductDto>>(_productRepository.GetProducts());

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(products);
        }

        [HttpGet("{prodId}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(400)]
        public IActionResult GetProductById(int prodId) 
        {
            var product = _mapper.Map<ProductDto>(_productRepository.GetProductById(prodId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(product);
        }

            
    }
}
