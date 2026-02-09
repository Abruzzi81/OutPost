using OutPost.Application.DTOs;
using OutPost.Domain.Entities;
using OutPost.Domain.Enums;

namespace OutPost.Application.Interfaces;

public interface IParcelService
{
    // Zwraca tracking number po utworzeniu
    Task<string> CreateParcelAsync(CreateParcelDto dto);

    // Zwraca DTO z danymi o paczce
    Task<ParcelDto?> GetParcelByTrackingNumberAsync(string trackingNumber);

    Task<IEnumerable<Parcel>> GetAllParcels();

    // Zwraca aktualny status po zmianie
    Task<bool> UpdateParcelStatus(string trackingNumber, ParcelStatus newStatus);
}
