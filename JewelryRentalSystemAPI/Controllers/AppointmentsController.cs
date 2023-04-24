using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JewelryRentalSystemAPI.Data;
using JewelryRentalSystemAPI.Models;
using JewelryRentalSystemAPI.DTO;
using Microsoft.AspNetCore.Authorization;

namespace JewelryRentalSystemAPI.Controllers
{
    [Authorize(Roles = "Customer")]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly JRSDBContext _context;

        public AppointmentsController(JRSDBContext context)
        {
            _context = context;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointments()
        {
            var appointments = await _context.Appointments
                .Select(a => new AppointmentDto
                {
                    AppointmentId = a.AppointmentId,
                    CustomerId = a.CustomerId,
                    DateOfAppointment = a.DateOfAppointment,
                    ScheduleTimeId = a.ScheduleTimeId,
                    LocationId = a.LocationId,
                    AppointmentTypeId = a.AppointmentTypeId,
                    ConfirmAppointment = a.ConfirmAppointment
                })
                .ToListAsync();

            return appointments;
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDto>> GetAppointment(int id)
        {
            var appointment = await _context.Appointments
                .Select(a => new AppointmentDto
                {
                    AppointmentId = a.AppointmentId,
                    CustomerId = a.CustomerId,
                    DateOfAppointment = a.DateOfAppointment,
                    ScheduleTimeId = a.ScheduleTimeId,
                    LocationId = a.LocationId,
                    AppointmentTypeId = a.AppointmentTypeId,
                    ConfirmAppointment = a.ConfirmAppointment
                })
                .FirstOrDefaultAsync(a => a.AppointmentId == id);

            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
        }

        // PUT: api/Appointments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, AppointmentDto appointmentDto)
        {
            if (id != appointmentDto.AppointmentId)
            {
                return BadRequest();
            }

            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            appointment.CustomerId = appointmentDto.CustomerId;
            appointment.DateOfAppointment = appointmentDto.DateOfAppointment;
            appointment.ScheduleTimeId = appointmentDto.ScheduleTimeId;
            appointment.LocationId = appointmentDto.LocationId;
            appointment.AppointmentTypeId = appointmentDto.AppointmentTypeId;
            appointment.ConfirmAppointment = appointmentDto.ConfirmAppointment;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Appointments
        [HttpPost]
        public async Task<ActionResult<AppointmentDto>> PostAppointment(AppointmentDto appointmentDto)
        {
            var appointment = new Appointment
            {
                CustomerId = appointmentDto.CustomerId,
                DateOfAppointment = appointmentDto.DateOfAppointment,
                ScheduleTimeId = appointmentDto.ScheduleTimeId,
                LocationId = appointmentDto.LocationId,
                AppointmentTypeId = appointmentDto.AppointmentTypeId,
                ConfirmAppointment = appointmentDto.ConfirmAppointment
            };

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            appointmentDto.AppointmentId = appointment.AppointmentId;

            return CreatedAtAction(nameof(GetAppointment), new
            {
                id = appointment.AppointmentId
            }, appointmentDto);
        }
        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.AppointmentId == id);
        }
    }
}