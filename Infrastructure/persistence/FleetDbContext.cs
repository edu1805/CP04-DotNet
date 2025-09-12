using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.persistence
{
    class FleetDbContext : DbContext
    {
        public FleetDbContext(DbContextOptions<FleetDbContext> options)
            : base(options) { }

        public DbSet<Fleet> Fleets { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<Driver> Drivers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Value Object: LicensePlate
            modelBuilder.Entity<Vehicle>()
                .OwnsOne(v => v.Plate, plate =>
                {
                    plate.Property(p => p.Value)
                         .HasColumnName("Plate")
                         .HasMaxLength(10)
                         .IsRequired();
                });

            // Entidades
            modelBuilder.Entity<Fleet>(entity =>
            {
                entity.HasKey(f => f.Id);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(v => v.Id);
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasKey(d => d.Id);
            });

            // Relacionamentos do agregado Fleet
            modelBuilder.Entity<Fleet>()
                .HasMany(f => f.Vehicles)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Fleet>()
                .HasMany(f => f.Drivers)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
