using AutoMapper;
using JewelryRentalSystemAPI.DTO;
using JewelryRentalSystemAPI.Interface;
using JewelryRentalSystemAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace JewelryRentalSystemAPI.Controllers
{
    [Authorize(Roles = "Administrator")]
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleTimeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IScheduleTimeRepository _scheduleTimeRepository;

        public ScheduleTimeController(IMapper mapper, IScheduleTimeRepository scheduleTimeRepository)
        {
            _mapper = mapper;
            _scheduleTimeRepository = scheduleTimeRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<ScheduleTimeDto> GetScheduleTimeById(int id)
        {
            try
            {
                var scheduleTime = _scheduleTimeRepository.GetScheduleTimeById(id);

                return Ok(scheduleTime);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<ScheduleTimeDto>> GetAllScheduleTimes()
        {
            var scheduleTimes = _scheduleTimeRepository.GetAllScheduleTimes();

            return Ok(scheduleTimes);
        }

        [HttpPost]
        public ActionResult<int> CreateScheduleTime(ScheduleTimeDto scheduleTimeDto)
        {
            try
            {
                var scheduleTimeId = _scheduleTimeRepository.CreateScheduleTime(scheduleTimeDto);

                return Ok(scheduleTimeId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateScheduleTime(int id, ScheduleTimeDto scheduleTimeDto)
        {
            try
            {
                _scheduleTimeRepository.UpdateScheduleTime(id, scheduleTimeDto);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
