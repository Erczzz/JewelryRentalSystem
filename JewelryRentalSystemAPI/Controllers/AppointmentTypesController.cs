using JewelryRentalSystemAPI.Data;
using JewelryRentalSystemAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryRentalSystemAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AppointmentTypesController : ControllerBase
    {
        private readonly JRSDBContext _dbContext;

        public AppointmentTypesController(JRSDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/appointmenttypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentType>>> GetAppointmentTypes()
        {
            return await _dbContext.AppointmentTypes.ToListAsync();
        }

        // GET: api/appointmenttypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentType>> GetAppointmentType(int id)
        {
            var appointmentType = await _dbContext.AppointmentTypes.FindAsync(id);

            if (appointmentType == null)
            {
                return NotFound();
            }

            return appointmentType;
        }

        // PUT: api/appointmenttypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointmentType(int id, AppointmentType appointmentType)
        {
            if (id != appointmentType.AppointmentTypeId)
            {
                return BadRequest();
            }

            _dbContext.Entry(appointmentType).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentTypeExists(id))
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

        // POST: api/appointmenttypes
        [HttpPost]
        public async Task<ActionResult<AppointmentType>> PostAppointmentType(AppointmentType appointmentType)
        {
            _dbContext.AppointmentTypes.Add(appointmentType);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAppointmentType), new { id = appointmentType.AppointmentTypeId }, appointmentType);
        }

        // DELETE: api/appointmenttypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointmentType(int id)
        {
            var appointmentType = await _dbContext.AppointmentTypes.FindAsync(id);
            if (appointmentType == null)
            {
                return NotFound();
            }

            _dbContext.AppointmentTypes.Remove(appointmentType);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentTypeExists(int id)
        {
            return _dbContext.AppointmentTypes.Any(e => e.AppointmentTypeId == id);
        }
    }
}
