using JewelryRentalSystemAPI.DTO;
using System.Collections.Generic;

namespace JewelryRentalSystemAPI.Interface
{
    public interface IScheduleTimeRepository
    {
        ScheduleTimeDto GetScheduleTimeById(int id);
        IEnumerable<ScheduleTimeDto> GetAllScheduleTimes();
        int CreateScheduleTime(ScheduleTimeDto scheduleTimeDto);
        void UpdateScheduleTime(int id, ScheduleTimeDto scheduleTimeDto);
    }
}
