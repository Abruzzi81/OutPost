using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using OutPost.Domain.Entities;

namespace OutPost.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Ta linijka mówi: "Stwórz tabelę Parcels na podstawie klasy Parcel"
    public DbSet<Parcel> Parcels => Set<Parcel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Tutaj możesz doprecyzować reguły, np. unikalny numer śledzenia
        modelBuilder.Entity<Parcel>()
            .HasIndex(p => p.TrackingNumber)
            .IsUnique();
    }
}