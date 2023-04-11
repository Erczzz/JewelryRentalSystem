using JewelryRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelryRentalSystem.Data.EntityRelationship
{
    public static class AppointmentRelationship
    {
        public static void AppointmentRelation(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(au => au.Appointments)
                .WithOne(a => a.Customer)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

/*            modelBuilder.Entity<Cart>()
            .HasOne<Transaction>(x => x.Transaction)
            .WithMany(x => x.Carts);*/
        }

    }
}
