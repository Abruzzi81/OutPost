using OutPost.Domain.Entities;
namespace OutPost.Application.Abstractions;

public interface IParcelRepository
{
    // Pobieranie paczki po Tracking Number
    Task<Parcel?> GetByTrackingNumberAsync(string trackingNumber);
    //Pobieranie wszystkich paczek
    Task<IEnumerable<Parcel>> GetAllParcelsAsync();

    // Dodawanie nowej paczki do kolejki zapisu
    Task AddAsync(Parcel parcel);

    // Zapisywanie wszystkich zmian w bazie danych (Unit of Work)
    Task SaveChangesAsync();

    Task UpdateAsync(Parcel parcel);
}