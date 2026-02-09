using Microsoft.EntityFrameworkCore;
using OutPost.Domain.Entities;

namespace OutPost.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Ta linijka mówi: "Stwórz tabelę Parcels na podstawie klasy Parcel"
    public DbSet<Parcel> Parcels => Set<Parcel>();
    public DbSet<Courier> Couriers => Set<Courier>();
    public DbSet<Client> Clients => Set<Client>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Tutaj możesz doprecyzować reguły, np. unikalny numer śledzenia
        modelBuilder.Entity<Parcel>(entity =>
        {
            // Definicja indeksu (jeśli go masz)
            entity.HasIndex(p => p.TrackingNumber).IsUnique();

            // Definicja relacji - HasOne musi być wywołane na 'entity', nie na indeksie!
            entity.HasOne(p => p.Sender)
                  .WithMany(c => c.SentParcels)
                  .HasForeignKey(p => p.SenderId);
        });

        modelBuilder.Entity<Courier>();

        modelBuilder.Entity<Client>()
            .HasIndex(c => c.Email).IsUnique();
    }
}