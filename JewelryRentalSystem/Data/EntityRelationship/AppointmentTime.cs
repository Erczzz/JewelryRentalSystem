using JewelryRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelryRentalSystem.Data.EntityRelationship
{
    public static class AppointmentTime
    {
        public static void AppointmentTimeRelation(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
            .HasOne<ScheduleTime>(x => x.ScheduleTime)
            .WithMany(x => x.Appointments)
            .HasForeignKey(x => x.TimeId);
        }
    }
}
