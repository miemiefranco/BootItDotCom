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
        public DbSet<Room> Rooms { get; set; }
        public DbSet<BookedRoomReference> BookedRoomReferences { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Address>()
           .HasOne(p => p.HotelOutlet)
           .WithOne(i => i.Address)
           .HasForeignKey<HotelOutlet>(a => a.AddressRef);

            //builder.Entity<Room>()
            //    .HasOne(p => p.BookedRoomReference)
            //    .WithOne(i => i.Room)
            //    .HasForeignKey<BookedRoomReference>(a => a.RoomRefId);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=BookItDotCom;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

    }
}
