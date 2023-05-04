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

namespace JewelryRentalSystem.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly JRSDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AppointmentController(JRSDBContext context, 
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var count = _context.Carts.Where(c => c.ConfirmRent == false && c.CustomerId == _userManager.GetUserId(HttpContext.User)).Count();
            ViewBag.Count = count;

            var jRSDBContext = _context.Appointments.Include(a => a.AppointmentType).Include(a => a.Customer).Include(a => a.Location).Include(a => a.ScheduleTime);
            return View(await jRSDBContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            var count = _context.Carts.Where(c => c.ConfirmRent == false && c.CustomerId == _userManager.GetUserId(HttpContext.User)).Count();
            ViewBag.Count = count;

            if (id == null || _context.Appointments == null)
            {
                return View("NotFound", "Home");
            }

            var appointment = await _context.Appointments
                .Include(a => a.AppointmentType)
                .Include(a => a.Customer)
                .Include(a => a.Location)
                .Include(a => a.ScheduleTime)
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return View("NotFound", "Home");
            }

            return View(appointment);
        }


        public IActionResult Create()
        {
            var productStocks = _context.Products.Select(p => p.ProductStock).ToList();
            var cartQty = _context.Carts.Where(p => p.ConfirmRent == false).Select(q => q.ProductQty).ToList();

            var invalidCartItems = from c in _context.Carts
                                   join p in _context.Products on c.ProductId equals p.ProductId
                                   where c.ProductQty > p.ProductStock && c.ConfirmRent == false
                                   select new { Cart = c, Product = p, ProductStock = p.ProductStock };

            if (invalidCartItems.Any())
            {
                foreach (var item in invalidCartItems)
                {
                    /*Console.WriteLine($"Invalid cart item: ProductId = {item.Cart.ProductId}, ProductQty = {item.Cart.ProductQty}, ProductStock = {item.ProductStock}");*/
                    TempData["InvalidCartItem"] = $"Invalid cart item: {item.Product.ProductName} has {item.ProductStock} stocks left. Please decrease your cart item of {item.Cart.ProductQty} to available stocks.";
                    return RedirectToAction("Index", "Cart");
                }
            }

            ViewData["AppointmentTypeId"] = new SelectList(_context.AppointmentTypes, "AppointmentTypeId", "APTName");
            ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "UserName");
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationName");
            ViewData["ScheduleTimeId"] = new SelectList(_context.ScheduleTimes, "TimeId", "SchedTime");
            var count = _context.Carts.Where(c => c.ConfirmRent == false && c.CustomerId == _userManager.GetUserId(HttpContext.User)).Count();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentId,CustomerId,DateOfAppointment,ScheduleTimeId,LocationId,AppointmentTypeId")] Appointment appointment, int id)
        {

            // Get the current user ID
            string currentUserId = _userManager.GetUserId(HttpContext.User);

            // Set the appointment customer ID to the current user ID
            appointment.CustomerId = currentUserId;

            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Transaction");
            }
            ViewData["AppointmentTypeId"] = new SelectList(_context.AppointmentTypes, "AppointmentTypeId", "AppointmentTypeId", appointment.AppointmentTypeId);
            ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "UserName", appointment.CustomerId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationName", appointment.LocationId);
            ViewData["ScheduleTimeId"] = new SelectList(_context.ScheduleTimes, "TimeId", "SchedTime", appointment.ScheduleTimeId);
            return View(appointment);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            var count = _context.Carts.Where(c => c.ConfirmRent == false && c.CustomerId == _userManager.GetUserId(HttpContext.User)).Count();
            ViewBag.Count = count;
            if (id == null || _context.Appointments == null)
            {
                return View("NotFound", "Home");
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return View("NotFound", "Home");
            }
            ViewData["AppointmentTypeId"] = new SelectList(_context.AppointmentTypes, "AppointmentTypeId", "AppointmentTypeId", appointment.AppointmentTypeId);
            ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id", appointment.CustomerId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationName", appointment.LocationId);
            ViewData["ScheduleTimeId"] = new SelectList(_context.ScheduleTimes, "TimeId", "SchedTime", appointment.ScheduleTimeId);
            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentId,CustomerId,DateOfAppointment,ScheduleTimeId,LocationId,AppointmentTypeId")] Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return View("NotFound", "Home");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.AppointmentId))
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
            ViewData["AppointmentTypeId"] = new SelectList(_context.AppointmentTypes, "AppointmentTypeId", "AppointmentTypeId", appointment.AppointmentTypeId);
            ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id", appointment.CustomerId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationName", appointment.LocationId);
            ViewData["ScheduleTimeId"] = new SelectList(_context.ScheduleTimes, "TimeId", "SchedTime", appointment.ScheduleTimeId);
            return View(appointment);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var count = _context.Carts.Where(c => c.ConfirmRent == false && c.CustomerId == _userManager.GetUserId(HttpContext.User)).Count();
            ViewBag.Count = count;
            if (id == null || _context.Appointments == null)
            {
                return View("NotFound", "Home");
            }

            var appointment = await _context.Appointments
                .Include(a => a.AppointmentType)
                .Include(a => a.Customer)
                .Include(a => a.Location)
                .Include(a => a.ScheduleTime)
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return View("NotFound", "Home");
            }

            return View(appointment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Appointments == null)
            {
                return Problem("Entity set 'JRSDBContext.Appointments'  is null.");
            }
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
          return (_context.Appointments?.Any(e => e.AppointmentId == id)).GetValueOrDefault();
        }
    }
}
