using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JewelryRentalSystem.Data;
using JewelryRentalSystem.Models;
using JewelryRentalSystem.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace JewelryRentalSystem.Controllers
{
    public class CartController : Controller
    {
        private readonly JRSDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(JRSDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> CountCart()
        {
            /*            var countCart = _context.Carts.Where(c => c.CustomerId == _userManager.GetUserId(HttpContext.User)).Count();*/
            var count = 0;
            var cart = _context.Carts.ToList();
            foreach(var item in cart)
            {
                if(item.CustomerId == _userManager.GetUserId(HttpContext.User))
                {
                    if (item.ConfirmRent == false)
                    {
                        count++;
                    }
                }
            }
            ViewBag.Count = count;
            return View(count);
        }

        // GET: Cart
        public async Task<IActionResult> Index()
        {
            var count = _context.Carts.Where(c => c.ConfirmRent == false && c.CustomerId == _userManager.GetUserId(HttpContext.User)).Count();
            ViewBag.Count = count;

            var countAppointment = _context.Appointments.Where(c => c.ConfirmAppointment == false && c.CustomerId == _userManager.GetUserId(HttpContext.User)).Count();
            ViewBag.CountAppointment = countAppointment;

            var jRSDBContext = _context.Carts.Where(b => b.ConfirmRent == false)
                .Include(c => c.Customer).Include(c => c.Product);
            return View(await jRSDBContext.ToListAsync());
        }

        // GET: Cart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carts == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .Include(c => c.Customer)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Cart/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
            ViewData["TransactionId"] = new SelectList(_context.Transactions, "TransactionId", "TransactionId");
            
            return View();
        }

        // POST: Cart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartId,CustomerId,ProductQty,RentDuration,Total,ConfirmRent,ProductId")] CartViewModel cart)
        {

            //if (ModelState.IsValid)
            {
                var cartTotal = (cart.ProductPrice * cart.ProductQty) * cart.RentDuration;
                ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id", cart.CustomerId);
                ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", cart.ProductId);
                var newCart = new Cart
                {
                    CustomerId = cart.CustomerId,
                    ProductQty = cart.ProductQty,
                    RentDuration = cart.RentDuration,
                    Total = cart.Total * cart.ProductQty * cart.RentDuration,
                    ProductId = cart.ProductId
                };
                _context.Add(newCart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }            
        }

        // GET: Cart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Carts == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id", cart.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductDescription", cart.ProductId);
            return View(cart);
        }

        // POST: Cart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CartId,CustomerId,ProductQty,RentDuration,Total,ConfirmRent,ProductId,TransactionId")] Cart cart)
        {
            if (id != cart.CartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.CartId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id", cart.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductDescription", cart.ProductId);
            return View(cart);
        }

        // GET: Cart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carts == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts.Include(c => c.Customer).Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: Cart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Carts == null)
            {
                return Problem("Entity set 'JRSDBContext.Carts'  is null.");
            }
            var cart = await _context.Carts.FindAsync(id);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartExists(int id)
        {
          return (_context.Carts?.Any(e => e.CartId == id)).GetValueOrDefault();
        }
    }
}
