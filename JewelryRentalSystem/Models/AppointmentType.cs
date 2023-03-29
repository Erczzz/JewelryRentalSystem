namespace JewelryRentalSystem.Models
{
    public class AppointmentType
    {
        public int AppointmentTypeId { get; set; }
        public string APTName { get; set;}
        public string APTDescription { get; set;}

        public AppointmentType() { }

        public AppointmentType(int appointmentTypeId, string aPTName, string aPTDescription)
        {
            AppointmentTypeId = appointmentTypeId;
            APTName = aPTName;
            APTDescription = aPTDescription;
        }
    }
}
