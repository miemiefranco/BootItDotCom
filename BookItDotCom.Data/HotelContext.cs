using BookItDotCom.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookItDotCom.Data
{
    public class HotelContext : IdentityDbContext
    {
        public HotelContext()
        {
                
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelOutlet> HotelOutlets { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Address>()
           .HasOne(p => p.HotelOutlet)
           .WithOne(i => i.Address)
           .HasForeignKey<HotelOutlet>(a => a.AddressRef);

            builder.Entity<BookedRoomReference>()
                .HasOne(p => p.Room)
                .WithOne(i => i.BookedRoomReference)
                .HasForeignKey<Room>(a => a.BookedRoomRefId);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=BookItDotCom;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

    }
}
