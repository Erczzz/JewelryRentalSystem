using JewelryRentalSystem.Api.Data;
using JewelryRentalSystem.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly JRSDBContext _dbContext;

    public CategoriesController(JRSDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    // GET api/categories
    [HttpGet]
    public IActionResult Get()
    {
        var categories = _dbContext.Categories.ToList();
        return Ok(categories);
    }

    // GET api/categories/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var category = _dbContext.Categories.FirstOrDefault(c => c.CategoryId == id);
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }

    // POST api/categories
    [HttpPost]
    public IActionResult Post([FromBody] Category category)
    {
        _dbContext.Categories.Add(category);
        _dbContext.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = category.CategoryId }, category);
    }

    // PUT api/categories/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Category category)
    {
        if (id != category.CategoryId)
        {
            return BadRequest();
        }
        _dbContext.Entry(category).State = EntityState.Modified;
        _dbContext.SaveChanges();
        return NoContent();
    }

    // DELETE api/categories/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var category = _dbContext.Categories.FirstOrDefault(c => c.CategoryId == id);
        if (category == null)
        {
            return NotFound();
        }
        _dbContext.Categories.Remove(category);
        _dbContext.SaveChanges();
        return NoContent();
    }
}
