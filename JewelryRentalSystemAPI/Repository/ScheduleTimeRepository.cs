using AutoMapper;
using JewelryRentalSystemAPI.Data;
using JewelryRentalSystemAPI.DTO;
using JewelryRentalSystemAPI.Interface;
using JewelryRentalSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JewelryRentalSystemAPI.Repository
{
    public class ScheduleTimeRepository : IScheduleTimeRepository
    {
        private readonly JRSDBContext _context;
        private readonly IMapper _mapper;

        public ScheduleTimeRepository(JRSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ScheduleTimeDto GetScheduleTimeById(int id)
        {
            var scheduleTime = _context.ScheduleTimes.FirstOrDefault(x => x.TimeId == id);

            if (scheduleTime == null)
            {
                throw new Exception($"Schedule time with ID {id} not found.");
            }

            return _mapper.Map<ScheduleTimeDto>(scheduleTime);
        }

        public IEnumerable<ScheduleTimeDto> GetAllScheduleTimes()
        {
            var scheduleTimes = _context.ScheduleTimes.ToList();

            return _mapper.Map<IEnumerable<ScheduleTimeDto>>(scheduleTimes);
        }

        public int CreateScheduleTime(ScheduleTimeDto scheduleTimeDto)
        {
            var scheduleTime = _mapper.Map<ScheduleTime>(scheduleTimeDto);

            _context.ScheduleTimes.Add(scheduleTime);
            _context.SaveChanges();

            return scheduleTime.TimeId;
        }

        public void UpdateScheduleTime(int id, ScheduleTimeDto scheduleTimeDto)
        {
            var scheduleTime = _context.ScheduleTimes.FirstOrDefault(x => x.TimeId == id);

            if (scheduleTime == null)
            {
                throw new Exception($"Schedule time with ID {id} not found.");
            }

            scheduleTime.SchedTime = scheduleTimeDto.SchedTime;

            _context.Entry(scheduleTime).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

