using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystemAPI.DTO
{
    public class ScheduleTimeDto
    {
        [Required]
        [DisplayName("Time")]
        public string SchedTime { get; set; }

        public ScheduleTimeDto()
        {

        }

        public ScheduleTimeDto(string schedTime)
        {
            SchedTime = schedTime;
        }
    }
}
