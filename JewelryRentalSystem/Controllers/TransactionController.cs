using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JewelryRentalSystem.Data;
using JewelryRentalSystem.Models;

namespace JewelryRentalSystem.Controllers
{
    public class TransactionController : Controller
    {
        private readonly JRSDBContext _context;

        public TransactionController(JRSDBContext context)
        {
            _context = context;
        }

        // GET: Transaction
        public async Task<IActionResult> Index()
        {
            var jRSDBContext = _context.Transactions.Include(t => t.Appointment);
            return View(await jRSDBContext.ToListAsync());
        }

        public async Task<IActionResult> OrderList()
        {
            var jRSDBContext = _context.Transactions.Include(t => t.Appointment)
                .Include(c => c.Carts);
            return View(await jRSDBContext.ToListAsync());
        }

        // GET: Transaction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.Appointment)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        public IActionResult Create()
        {
            ViewData["AppointmentId"] = new SelectList(_context.Appointments.Where(b => b.ConfirmAppointment == false), "AppointmentId", "CustomerId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionId,AppointmentId")] Transaction transaction)
        {
            //if (ModelState.IsValid)
            {
              
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                var cart = _context.Carts.Where(x => x.ConfirmRent == false).ToList();

                foreach (var item in cart)
                {
                    item.ConfirmRent = true;
                    item.TransactionId = transaction.TransactionId;
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }

                var appointment = _context.Appointments.Where(x => x.ConfirmAppointment == false).ToList();
                foreach (var item in appointment)
                {
                    item.ConfirmAppointment = true;
                    _context.Update(item);
                    await _context.SaveChangesAsync();
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
                return NotFound();
            }

            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["AppointmentId"] = new SelectList(_context.Appointments, "AppointmentId", "CustomerId", transaction.AppointmentId);
            return View(transaction);
        }

        // POST: Transaction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionId,AppointmentId")] Transaction transaction)
        {
            if (id != transaction.TransactionId)
            {
                return NotFound();
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
                        return NotFound();
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
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.Appointment)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transaction/Delete/5
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
    }
}
