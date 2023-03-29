namespace JewelryRentalSystem.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public TimeOnly Time { get; set; }
        public string Location { get; set; }
        public int Duration { get; set; }
        
        public Appointment() { }

        public Appointment(int appointmentId, TimeOnly time, string location, int duration)
        {
            AppointmentId = appointmentId;
            Time = time;
            Location = location;
            Duration = duration;
        }
    }
}
