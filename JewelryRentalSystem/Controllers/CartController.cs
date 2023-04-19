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
using JewelryRentalSystem.Services;

namespace JewelryRentalSystem.Controllers
{
    public class CartController : Controller
    {
        private readonly JRSDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;

        public CartController(JRSDBContext context, UserManager<ApplicationUser> userManager,
            IUserService userService)
        {
            _context = context;
            _userManager = userManager;
            _userService = userService;
        }

        /*        public async Task<IActionResult> CountCart()
                {
                    *//*            var countCart = _context.Carts.Where(c => c.CustomerId == _userManager.GetUserId(HttpContext.User)).Count();*//*

                    var count =  _context.Carts.Where(c => c.ConfirmRent == false && c.CustomerId == _userManager.GetUserId(HttpContext.User)).Count();
                    ViewBag.Count = count;
                    return View();
                }*/

        /*        public IActionResult GetCartCount()
                {
                    int cartCount = _context.Carts.Where(c => c.ConfirmRent == false && c.CustomerId == _userManager.GetUserId(HttpContext.User)).Count();
                    return PartialView("_CartCount", cartCount);
                }*/
/*        public int GetCartItemCount()
        {
            int cartCount = 0;
            cartCount = _context.Carts.Where(c => c.ConfirmRent == false && c.CustomerId == _userManager.GetUserId(HttpContext.User)).Count();
            if (cartCount == 0)
            {
                return 0;
            }
            ViewBag.Count = cartCount;
            return cartCount;
        }*/


        public async Task<IActionResult> Index()
        {
            var count = _context.Carts.Where(c => c.ConfirmRent == false && c.CustomerId == _userManager.GetUserId(HttpContext.User)).Count();
            ViewBag.Count = count;

            var countAppointment = _context.Appointments.Where(c => c.ConfirmAppointment == false && c.CustomerId == _userManager.GetUserId(HttpContext.User)).Count();
            ViewBag.CountAppointment = countAppointment;


            var jRSDBContext = _context.Carts.Where(b => b.ConfirmRent == false && b.CustomerId == _userManager.GetUserId(HttpContext.User))
                .Include(c => c.Customer).Include(c => c.Product);
            return View(await jRSDBContext.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carts == null)
            {
                return View("NotFound", "Home");
            }

            var cart = await _context.Carts
                .Include(c => c.Customer)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (cart == null)
            {
                return View("NotFound", "Home");
            }

            return View(cart);
        }

        public IActionResult Create()
        {
            var count = _context.Carts.Where(c => c.ConfirmRent == false && c.CustomerId == _userManager.GetUserId(HttpContext.User)).Count();
            ViewBag.Count = count;

            ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
            ViewData["TransactionId"] = new SelectList(_context.Transactions, "TransactionId", "TransactionId");
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartId,CustomerId,ProductQty,RentDuration,Total,ConfirmRent,ProductId")] CartViewModel cart)
        {

            //if (ModelState.IsValid)
            {
                var userId = _userService.GetUserId();
                var user = await _userManager.Users
                .Include(u => u.CustomerClassification)
                .SingleOrDefaultAsync(u => u.Id == userId);
                var userItemLimit = user.CustomerClassification.ItemLimit;
                var userRentLimit = user.CustomerClassification.RentLimit;
                var userCart = _context.Carts.Where(c => c.ConfirmRent == false && c.CustomerId == _userManager.GetUserId(HttpContext.User)).Sum(q => q.ProductQty);

                if (userItemLimit == 5)
                {
                    if(userCart < 5)
                    {
                        var cartTotal = (cart.ProductPrice * cart.ProductQty) * cart.RentDuration;
                        ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id", cart.CustomerId);
                        ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", cart.ProductId);
                        if(cart.ProductQty > userItemLimit || cart.ProductQty > (userItemLimit - userCart))
                        {
                            TempData["ErrorMessage"] = "You have exceeded your item limit of 5";
                            return RedirectToAction("GetAllProducts", "Product");
                        }
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
                        TempData["Message"] = "Item added to your bag successfully!";
                        return RedirectToAction("GetAllProducts", "Product");
                    }
                    TempData["ErrorMessage"] = "You have exceeded your item limit of 5";
                    return RedirectToAction("GetAllProducts", "Product");
                }
                else if (userItemLimit == 10)
                {
                    if (userCart < 10)
                    {
                        var cartTotal = (cart.ProductPrice * cart.ProductQty) * cart.RentDuration;
                        ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id", cart.CustomerId);
                        ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", cart.ProductId);
                        if (cart.ProductQty > userItemLimit || cart.ProductQty > (userItemLimit - userCart))
                        {
                            TempData["ErrorMessage"] = "You have exceeded your item limit of 10";
                            return RedirectToAction("GetAllProducts", "Product");
                        }
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
                        TempData["Message"] = "Item added to your bag successfully!";
                        return RedirectToAction("GetAllProducts", "Product");
                    }
                    TempData["ErrorMessage"] = "You have exceeded your item limit of 10";
                    return RedirectToAction("GetAllProducts", "Product");
                }
                else if (userItemLimit == 20)
                {
                    if (userCart < 20)
                    {
                        var cartTotal = (cart.ProductPrice * cart.ProductQty) * cart.RentDuration;
                        ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id", cart.CustomerId);
                        ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", cart.ProductId);
                        if (cart.ProductQty > userItemLimit || cart.ProductQty > (userItemLimit - userCart))
                        {
                            TempData["ErrorMessage"] = "You have exceeded your item limit of 20";
                            return RedirectToAction("GetAllProducts", "Product");
                        }
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
                        TempData["Message"] = "Item added to your bag successfully!";
                        return RedirectToAction("GetAllProducts", "Product");
                    }
                    TempData["ErrorMessage"] = "You have exceeded your item limit of 20";
                    return RedirectToAction("GetAllProducts", "Product");
                }
                var supTotal = (cart.ProductPrice * cart.ProductQty) * cart.RentDuration;
                ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id", cart.CustomerId);
                ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", cart.ProductId);
                var supCart = new Cart
                {
                    CustomerId = cart.CustomerId,
                    ProductQty = cart.ProductQty,
                    RentDuration = cart.RentDuration,
                    Total = cart.Total * cart.ProductQty * cart.RentDuration,
                    ProductId = cart.ProductId
                };
                _context.Add(supCart);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Item added to your bag successfully!";
                return RedirectToAction("GetAllProducts", "Product");


            }
            return RedirectToAction("GetAllProducts", "Product");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Carts == null)
            {
                return View("NotFound", "Home");
            }

            var cart = await _context.Carts.FindAsync(id);
            
            if (cart == null)
            {
                return View("NotFound", "Home");
            }

            ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id", cart.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductPrice", cart.ProductId);


            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int newQty, [Bind("CartId,CustomerId,ProductQty,RentDuration,Total,ConfirmRent,ProductId,TransactionId")] Cart cart)
        {
            var cartItem = _context.Carts.Find(id);
            if (id != cart.CartId)
            {
                return View("NotFound", "Home");
            }

            // if (ModelState.IsValid)
            {
                try
                {
                    cart.Total = cart.Product.ProductPrice * cart.ProductQty * cart.RentDuration;
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.CartId))
                    {
                        return View("NotFound", "Home");
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

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carts == null)
            {
                return View("NotFound", "Home");
            }

            var cart = await _context.Carts.Include(c => c.Customer).Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (cart == null)
            {
                return View("NotFound", "Home");
            }

            return View(cart);
        }

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
            TempData["Message"] = "Item removed from your bag successfully!";
            return RedirectToAction(nameof(Index));
        }

        private bool CartExists(int id)
        {
          return (_context.Carts?.Any(e => e.CartId == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> CartItems(int id)
        {

            var cart = _context.Carts.Where(b => b.ConfirmRent == true && b.TransactionId == id)
                .Include(c => c.Customer).Include(c => c.Product);
            return View(await cart.ToListAsync());
        }
    }
}
