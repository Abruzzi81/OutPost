using OutPost.Application.DTOs;

namespace OutPost.Application.Interfaces;

public interface IParcelService
{
    // Zwraca tracking number po utworzeniu
    Task<string> CreateParcelAsync(ParcelDto dto);

    // Zwraca DTO z danymi o paczce
    Task<ParcelDto?> GetParcelByTrackingNumberAsync(string trackingNumber);
}
