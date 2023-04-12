﻿using JewelryRentalSystem.Models;
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

/*            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Transaction)
                .WithOne(a => a.Appointment)
                .HasForeignKey<Transaction>(a => a.TransactionId)
                .OnDelete(DeleteBehavior.NoAction);*/

        }

    }
}
