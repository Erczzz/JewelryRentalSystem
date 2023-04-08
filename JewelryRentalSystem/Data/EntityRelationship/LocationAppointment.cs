using JewelryRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelryRentalSystem.Data.EntityRelationship
{
    public static class LocationAppointment
    {
        public static void LocationAppointmentrelation(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
            .HasOne<Location>(x => x.Location)
            .WithMany(x => x.Appointments)
            .HasForeignKey(x => x.LocationId);
        }
    }
}
