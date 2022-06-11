using BookingManagement.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagement.Repository
{
    public class BookingDbContext: DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
        {
        }

        public virtual DbSet<BookflightTbl> BookflightTbls { get; set; }
        public virtual DbSet<UserDetailTbl> UserDetailTbls { get; set; }

        public virtual DbSet<InventoryDetails> InventoryTbls { get; set; }
        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            model.Entity<BookflightTbl>(entity =>
            {
                entity.ToTable("bookflightTbl");
                entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("Id");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.FlightNumber).HasMaxLength(50);

                entity.Property(e => e.Meal).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.peopleid).HasColumnName("peopleid");

                entity.Property(e => e.Pnr).HasMaxLength(50);

            });

            model.Entity<UserDetailTbl>(entity =>
            {

                entity.ToTable("UserDetailTbl");
                entity.Property(e => e.PeopleId)
                    .ValueGeneratedNever()
                    .HasColumnName("PeopleId");
                entity.Property(e => e.Age)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Class).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

        }
    }
   
}
