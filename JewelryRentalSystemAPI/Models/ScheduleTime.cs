using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JewelryRentalSystemAPI.Models
{
    public class ScheduleTime
    {
        [Key]
        public int TimeId { get; set; }

        [Required]
        [DisplayName("Time")]
        public string SchedTime { get; set; }

        public ScheduleTime()
        {
        }

        public ScheduleTime(int timeId, string schedTime)
        {
            TimeId = timeId;
            SchedTime = schedTime;
        }
    }
}
