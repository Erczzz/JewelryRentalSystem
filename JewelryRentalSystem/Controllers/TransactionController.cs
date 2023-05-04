using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JewelryRentalSystem.Data;
using JewelryRentalSystem.Models;
using Microsoft.AspNetCore.Identity;
using JewelryRentalSystem.ViewModels;

namespace JewelryRentalSystem.Controllers
{
    public class TransactionController : Controller
    {
        private readonly JRSDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TransactionController(JRSDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Transaction
        public async Task<IActionResult> Index()
        {
            var count = _context.Carts.Where(c => c.ConfirmRent == false && c.CustomerId == _userManager.GetUserId(HttpContext.User)).Count();
            ViewBag.Count = count;

            var countTransaction = _context.Transactions.Where(c => c.Appointment.CustomerId == _userManager.GetUserId(HttpContext.User)).Count();
            ViewBag.countTransaction = countTransaction;

            var jRSDBContext = _context.Transactions.Include(t => t.Appointment).Where(u => u.Appointment.CustomerId == _userManager.GetUserId(HttpContext.User));
            return View(await jRSDBContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return View("NotFound", "Home");
            }

            var transaction = await _context.Transactions
                .Include(t => t.Appointment)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return View("NotFound", "Home");
            }

            return View(transaction);
        }

        public IActionResult Create()
        {
            var count = _context.Carts.Where(c => c.ConfirmRent == false && c.CustomerId == _userManager.GetUserId(HttpContext.User)).Count();
            ViewBag.Count = count;
            ViewData["AppointmentId"] = new SelectList(_context.Appointments.Where(b => b.ConfirmAppointment == false), "AppointmentId", "CustomerId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionId,AppointmentId")] Transaction transaction)
        {
            //if (ModelState.IsValid)
            {
                var count = _context.Carts.Where(c => c.ConfirmRent == false && c.CustomerId == _userManager.GetUserId(HttpContext.User)).Count();
                ViewBag.Count = count;
                var userId = _userManager.GetUserId(HttpContext.User);
                var userAppointment = _context.Appointments
                    .Where(a => a.ConfirmAppointment == false && 
                    a.CustomerId == userId).ToList();
                ViewBag.userAppointment = userAppointment;

                _context.Add(transaction);
                await _context.SaveChangesAsync();
                var cart = _context.Carts.Where(x => x.ConfirmRent == false && x.CustomerId == userId).ToList();
                var cartItems = await _context.Carts
                .Where(c => c.ConfirmRent == false)
                .Join(_context.Products, c => c.ProductId, p => p.ProductId, (cart, product) => new
                {
                    Cart = cart,
                    Product = product
                })
                .Where(cp => cp.Product.ProductId == cp.Cart.ProductId && cp.Cart.ProductQty <= cp.Product.ProductStock)
                .ToListAsync();


                foreach (var item in cartItems)
                {
                    // Update the product stock by subtracting the cart quantity
                    item.Product.ProductStock -= item.Cart.ProductQty;

                    // Mark the cart item as confirmed
                    item.Cart.ConfirmRent = true;
                    item.Cart.TransactionId = transaction.TransactionId;

                    // Save the changes to the database
                    _context.Update(item.Product);
                    _context.Update(item.Cart);
                    await _context.SaveChangesAsync();
                }


                var appointment = _context.Appointments.Where(x => x.ConfirmAppointment == false).ToList();
                foreach (var item in appointment)
                {
                    item.ConfirmAppointment = true;
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "Transaction created successfully!";
                }
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppointmentId"] = new SelectList(_context.Appointments.Where(b => b.ConfirmAppointment == false), "AppointmentId", "CustomerId", transaction.AppointmentId);
            return View(transaction);
        }

        // GET: Transaction/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return View("NotFound", "Home");
            }

            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return View("NotFound", "Home");
            }
            ViewData["AppointmentId"] = new SelectList(_context.Appointments, "AppointmentId", "CustomerId", transaction.AppointmentId);
            return View(transaction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionId,AppointmentId")] Transaction transaction)
        {
            if (id != transaction.TransactionId)
            {
                return View("NotFound", "Home");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.TransactionId))
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
            ViewData["AppointmentId"] = new SelectList(_context.Appointments, "AppointmentId", "CustomerId", transaction.AppointmentId);
            return View(transaction);
        }

        // GET: Transaction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return View("NotFound", "Home");
            }

            var transaction = await _context.Transactions
                .Include(t => t.Appointment)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return View("NotFound", "Home");
            }

            return View(transaction);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transactions == null)
            {
                return Problem("Entity set 'JRSDBContext.Transactions'  is null.");
            }
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
          return (_context.Transactions?.Any(e => e.TransactionId == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> OrderItems(int id)
        {
            var count = _context.Carts.Where(c => c.ConfirmRent == false && c.CustomerId == _userManager.GetUserId(HttpContext.User)).Count();
            ViewBag.Count = count;

            var transaction = await _context.Transactions
            .Include(t => t.Appointment)
            .FirstOrDefaultAsync(m => m.TransactionId == id);

            var jRSDBContext = _context.Carts.Where(b => b.ConfirmRent == false && b.CustomerId == _userManager.GetUserId(HttpContext.User))
                .Include(c => c.Customer).Include(c => c.Product);
            return View(await jRSDBContext.ToListAsync());
        }

        public async Task<IActionResult> CancelTransaction(int id)
        {
            var lastAppointment =  _context.Appointments.OrderByDescending(a => a.AppointmentId).FirstOrDefault();
            if(lastAppointment!= null)
            {
                _context.Appointments.Remove(lastAppointment);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Cart");
        }
    }
}
