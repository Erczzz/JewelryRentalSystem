namespace JewelryRentalSystem.Models
{
    public class AppointmentType
    {
        public int AppointmentTypeId { get; set; }
        public string APTName { get; set;}

        public AppointmentType() { }

        public AppointmentType(int appointmentTypeId, string aPTName)
        {
            AppointmentTypeId = appointmentTypeId;
            APTName = aPTName;
        }
    }
}
