using Microsoft.EntityFrameworkCore;
using Itinerary_Management.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinerary_Management.DAL {
    public class ItineraryDbContext : DbContext{
        public ItineraryDbContext(DbContextOptions<ItineraryDbContext> options) : base(options) { }

        public DbSet<Itinerary> Itineraries { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Stay> Stays { get; set; }
        public DbSet<Models.Activity> Activities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Server=ASTRA\\SQLEXPRESS;Database=ItineraryDatabase;Integrated Security=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // entities
            // flight
            modelBuilder.Entity<Flight>(entity =>
            {
                // define primary key
                entity.HasKey(f => f.FlightId);

                // define column properties
                entity.Property(f => f.Airline)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(f => f.FlightNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(f => f.DepartureDate)
                    .IsRequired();

                entity.Property(f => f.ArrivalDate)
                    .IsRequired();
            });

            // stay
            modelBuilder.Entity<Stay>(entity =>
            {
                entity.HasKey(s => s.StayId);

                entity.Property(s => s.AccommodationName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(s => s.CheckInDate)
                    .IsRequired();

                entity.Property(s => s.CheckOutDate)
                    .IsRequired();
            });

            // activity 
            modelBuilder.Entity<Models.Activity>(entity =>
            {
                entity.HasKey(a => a.ActivityId);

                entity.Property(a => a.ActivityName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(a => a.Location)
                    .HasMaxLength(255);

                entity.Property(a => a.StartTime)
                    .IsRequired();

                entity.Property(a => a.EndTime)
                    .IsRequired();
            });

            // itinerary
            modelBuilder.Entity<Itinerary>(entity =>
            {
                entity.HasKey(i => i.ItineraryId);

                entity.Property(i => i.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(i => i.StartDate)
                    .IsRequired();

                entity.Property(i => i.EndDate)
                    .IsRequired();
            });

            // Configure relationships for Itinerary and Flight
            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Itinerary)
                .WithMany(i => i.Flights)
                .HasForeignKey(f => f.ItineraryId)
                .OnDelete(DeleteBehavior.Cascade); // Delete related Flights when an Itinerary is deleted

            // Configure relationships for Itinerary and Stay
            modelBuilder.Entity<Stay>()
                .HasOne(s => s.Itinerary)
                .WithMany(i => i.Stays)
                .HasForeignKey(s => s.ItineraryId)
                .OnDelete(DeleteBehavior.Cascade); // Delete related Stays when an Itinerary is deleted

            // Configure relationships for Itinerary and Activity
            modelBuilder.Entity<Models.Activity>()
                .HasOne(a => a.Itinerary)
                .WithMany(i => i.Activities)
                .HasForeignKey(a => a.ItineraryId)
                .OnDelete(DeleteBehavior.Cascade); // Delete related Activities when an Itinerary is deleted
        }
    }
}
