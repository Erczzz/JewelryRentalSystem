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
    public class AppointmentTypeController : Controller
    {
        private readonly JRSDBContext _context;

        public AppointmentTypeController(JRSDBContext context)
        {
            _context = context;
        }

        // GET: AppointmentType
        public async Task<IActionResult> Index()
        {
              return _context.AppointmentTypes != null ? 
                          View(await _context.AppointmentTypes.ToListAsync()) :
                          Problem("Entity set 'JRSDBContext.AppointmentTypes'  is null.");
        }

        // GET: AppointmentType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AppointmentTypes == null)
            {
                return NotFound();
            }

            var appointmentType = await _context.AppointmentTypes
                .FirstOrDefaultAsync(m => m.AppointmentTypeId == id);
            if (appointmentType == null)
            {
                return NotFound();
            }

            return View(appointmentType);
        }

        // GET: AppointmentType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppointmentType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentTypeId,APTName,APTDescription")] AppointmentType appointmentType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointmentType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appointmentType);
        }

        // GET: AppointmentType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AppointmentTypes == null)
            {
                return NotFound();
            }

            var appointmentType = await _context.AppointmentTypes.FindAsync(id);
            if (appointmentType == null)
            {
                return NotFound();
            }
            return View(appointmentType);
        }

        // POST: AppointmentType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentTypeId,APTName,APTDescription")] AppointmentType appointmentType)
        {
            if (id != appointmentType.AppointmentTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointmentType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentTypeExists(appointmentType.AppointmentTypeId))
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
            return View(appointmentType);
        }

        // GET: AppointmentType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AppointmentTypes == null)
            {
                return NotFound();
            }

            var appointmentType = await _context.AppointmentTypes
                .FirstOrDefaultAsync(m => m.AppointmentTypeId == id);
            if (appointmentType == null)
            {
                return NotFound();
            }

            return View(appointmentType);
        }

        // POST: AppointmentType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AppointmentTypes == null)
            {
                return Problem("Entity set 'JRSDBContext.AppointmentTypes'  is null.");
            }
            var appointmentType = await _context.AppointmentTypes.FindAsync(id);
            if (appointmentType != null)
            {
                _context.AppointmentTypes.Remove(appointmentType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentTypeExists(int id)
        {
          return (_context.AppointmentTypes?.Any(e => e.AppointmentTypeId == id)).GetValueOrDefault();
        }
    }
}
