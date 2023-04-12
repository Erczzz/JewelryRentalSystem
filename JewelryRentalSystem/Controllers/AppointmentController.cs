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

        // GET: Appointment
        public async Task<IActionResult> Index()
        {
            var jRSDBContext = _context.Appointments.Include(a => a.AppointmentType).Include(a => a.Customer).Include(a => a.Location).Include(a => a.ScheduleTime);
            return View(await jRSDBContext.ToListAsync());
        }

        // GET: Appointment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.AppointmentType)
                .Include(a => a.Customer)
                .Include(a => a.Location)
                .Include(a => a.ScheduleTime)
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }


        public IActionResult Create()
        {
            ViewData["AppointmentTypeId"] = new SelectList(_context.AppointmentTypes, "AppointmentTypeId", "APTName");
            ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationName");
            ViewData["ScheduleTimeId"] = new SelectList(_context.ScheduleTimes, "TimeId", "SchedTime");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentId,CustomerId,DateOfAppointment,ScheduleTimeId,LocationId,AppointmentTypeId")] Appointment appointment)
        {
            //if (ModelState.IsValid)
            {

                appointment.CustomerId = _userManager.GetUserId(HttpContext.User);
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Transaction");
            }
/*            ViewData["AppointmentTypeId"] = new SelectList(_context.AppointmentTypes, "AppointmentTypeId", "AppointmentTypeId", appointment.AppointmentTypeId);
            ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id", appointment.CustomerId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationName", appointment.LocationId);
            ViewData["ScheduleTimeId"] = new SelectList(_context.ScheduleTimes, "TimeId", "SchedTime", appointment.ScheduleTimeId);
            return View(appointment);*/
        }

        // GET: Appointment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["AppointmentTypeId"] = new SelectList(_context.AppointmentTypes, "AppointmentTypeId", "AppointmentTypeId", appointment.AppointmentTypeId);
            ViewData["CustomerId"] = new SelectList(_context.Users, "Id", "Id", appointment.CustomerId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationName", appointment.LocationId);
            ViewData["ScheduleTimeId"] = new SelectList(_context.ScheduleTimes, "TimeId", "SchedTime", appointment.ScheduleTimeId);
            return View(appointment);
        }

        // POST: Appointment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentId,CustomerId,DateOfAppointment,ScheduleTimeId,LocationId,AppointmentTypeId")] Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return NotFound();
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
                        return NotFound();
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

        // GET: Appointment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.AppointmentType)
                .Include(a => a.Customer)
                .Include(a => a.Location)
                .Include(a => a.ScheduleTime)
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointment/Delete/5
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
