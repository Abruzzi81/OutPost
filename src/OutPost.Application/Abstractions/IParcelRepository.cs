using OutPost.Domain.Entities;
namespace OutPost.Application.Abstractions;

public interface IParcelRepository
{
    // Pobieranie paczki po Tracking Number (to co widzi klient)
    Task<Parcel?> GetByTrackingNumberAsync(string trackingNumber);

    // Dodawanie nowej paczki do kolejki zapisu
    Task AddAsync(Parcel parcel);

    // Zapisywanie wszystkich zmian w bazie danych (Unit of Work)
    Task SaveChangesAsync();
}