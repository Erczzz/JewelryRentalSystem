using AutoMapper;
using JewelryRentalSystemAPI.DTO;
using JewelryRentalSystemAPI.Interface;
using JewelryRentalSystemAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace JewelryRentalSystemAPI.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    [Route("api/v1/[controller]")]
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

        //Listing of Products
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Product>))]
        public IActionResult GetProducts()
        {
            var products = _mapper.Map<List<ProductDto>>(_productRepository.GetProducts());

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(products);
        }

        //Listing of Products by Id
        [HttpGet("{productId}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(400)]
        public IActionResult GetProductById(int productId) 
        {
            var product = _mapper.Map<ProductDto>(_productRepository.GetProductById(productId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(product);
        }

        //Delete Product(s)
        [HttpDelete("{productId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteProduct([FromRoute] int productId)
        {
            if (productId == 0)
                return BadRequest();
            var product = _productRepository.GetProductById(productId);
            if (product == null)
                return NotFound("No Resource Found.");
            return Accepted(_productRepository.DeleteProduct(productId));
        }

        //Add Product(s)
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddProduct([FromBody] ProductDto productDto)
        {
            if (productDto == null)
                return BadRequest("No data has been provided.");
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(productDto);

                var newProduct = _productRepository.AddProduct(product);
                return CreatedAtAction("GetProductById", new { productId = newProduct.ProductId }, newProduct);
            }
            return BadRequest(ModelState);
        }

        //Update Product(s)
        [HttpPut("{productId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateProduct(int productId, [FromBody] ProductDto productDto) 
        {
            if (productDto == null)
                return BadRequest("No data provided");

            var product = _productRepository.GetProductById(productId);
            var updatedProduct = _mapper.Map<Product>(productDto);

            _productRepository.UpdateProduct(product.ProductId, updatedProduct);
            return Ok();
        }
    }
}
