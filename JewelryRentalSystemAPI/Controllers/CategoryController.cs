using AutoMapper;
using JewelryRentalSystemAPI.DTO;
using JewelryRentalSystemAPI.Interface;
using JewelryRentalSystemAPI.Models;
using JewelryRentalSystemAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JewelryRentalSystemAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategoryById(int categoryId)
        {
            var category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategoryById(categoryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }

        [HttpGet("product/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        [ProducesResponseType(400)]
        public IActionResult GetProductByCategoryId(int categoryId)
        {
           var products = _mapper.Map<List<ProductDto>>(
               _categoryRepository.GetProductByCategory(categoryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(products);
        }

        [HttpDelete("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCategory([FromRoute] int categoryId)
        {
            if (categoryId == 0)
                return BadRequest();
            var category = _categoryRepository.GetCategoryById(categoryId);
            if (category == null)
                return NotFound("No Resource Found.");
            return Accepted(_categoryRepository.DeleteCategory(categoryId));
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddCategory([FromBody] CategoryDto categoryDto)
        {
            if (categoryDto == null)
                return BadRequest("No data has been provided.");
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(categoryDto);

                var newCategory = _categoryRepository.AddCategory(category);
                return CreatedAtAction("GetCategoryById", new { categoryId = newCategory.CategoryId }, newCategory);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCategory(int categoryId, [FromBody] CategoryDto categoryDto)
        {
            if (categoryDto == null)
                return BadRequest("No data provided");

            var category = _categoryRepository.GetCategoryById(categoryId);
            var updatedCategory = _mapper.Map<Category>(categoryDto);

            _categoryRepository.UpdateCategory(category.CategoryId, updatedCategory);
            return Ok();
        }
    }
}
