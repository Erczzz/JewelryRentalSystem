using JewelryRentalSystemAPI.Data;
using JewelryRentalSystemAPI.DTO;
using JewelryRentalSystemAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles = "Customer")]
[Route("api/v1/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly JRSDBContext _context;

    public CartController(JRSDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CartDto>>> GetCarts()
    {
        var carts = await _context.Carts.ToListAsync();
        return Ok(carts.Select(c => new CartDto
        {
            CartId = c.CartId,
            CustomerId = c.CustomerId,
            ProductQty = c.ProductQty,
            RentDuration = c.RentDuration,
            Total = c.Total,
            ConfirmRent = c.ConfirmRent,
            ProductId = c.ProductId,
            TransactionId = c.TransactionId
        }));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CartDto>> GetCart(int id)
    {
        var cart = await _context.Carts.FindAsync(id);

        if (cart == null)
        {
            return NotFound();
        }

        return Ok(new CartDto
        {
            CartId = cart.CartId,
            CustomerId = cart.CustomerId,
            ProductQty = cart.ProductQty,
            RentDuration = cart.RentDuration,
            Total = cart.Total,
            ConfirmRent = cart.ConfirmRent,
            ProductId = cart.ProductId,
            TransactionId = cart.TransactionId
        });
    }

    [HttpPost]
    public async Task<ActionResult<CartDto>> CreateCart(CartDto cartDto)
    {
        var cart = new Cart
        {
            CustomerId = cartDto.CustomerId,
            ProductQty = cartDto.ProductQty,
            RentDuration = cartDto.RentDuration,
            Total = cartDto.Total,
            ConfirmRent = cartDto.ConfirmRent,
            ProductId = cartDto.ProductId,
            TransactionId = cartDto.TransactionId
        };

        _context.Carts.Add(cart);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCart), new { id = cart.CartId }, new CartDto
        {
            CartId = cart.CartId,
            CustomerId = cart.CustomerId,
            ProductQty = cart.ProductQty,
            RentDuration = cart.RentDuration,
            Total = cart.Total,
            ConfirmRent = cart.ConfirmRent,
            ProductId = cart.ProductId,
            TransactionId = cart.TransactionId
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCart(int id, CartDto cartDto)
    {
        if (id != cartDto.CartId)
        {
            return BadRequest();
        }

        var cart = await _context.Carts.FindAsync(id);

        if (cart == null)
        {
            return NotFound();
        }

        cart.CustomerId = cartDto.CustomerId;
        cart.ProductQty = cartDto.ProductQty;
        cart.RentDuration = cartDto.RentDuration;
        cart.Total = cartDto.Total;
        cart.ConfirmRent = cartDto.ConfirmRent;
        cart.ProductId = cartDto.ProductId;
        cart.TransactionId = cartDto.TransactionId;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /*[HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCart(int id)
    {
        var cart = await _context.Carts.FindAsync(id);

        if (cart == null)
        {
            return NotFound();
        }

        _context.Carts.Remove(cart);
        await _context.SaveChangesAsync();

        return NoContent();
    }*/
}

