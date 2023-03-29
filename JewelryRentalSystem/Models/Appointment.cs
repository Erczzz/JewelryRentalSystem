namespace JewelryRentalSystem.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime Time { get; set; }
        public string Location { get; set; }
        public int Duration { get; set; }
        
        public Appointment() { }

        public Appointment(int appointmentId, DateTime time, string location, int duration)
        {
            AppointmentId = appointmentId;
            Time = time;
            Location = location;
            Duration = duration;
        }
    }
}
