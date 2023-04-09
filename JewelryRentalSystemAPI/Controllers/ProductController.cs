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

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Product>))]
        public IActionResult GetProducts()
        {
            var products = _productRepository.GetProducts();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(products);
        }
    }
}
