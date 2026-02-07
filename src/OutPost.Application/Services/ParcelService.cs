using OutPost.Application.DTOs;
using OutPost.Application.Interfaces;
using OutPost.Application.Abstractions;
using OutPost.Domain;

namespace OutPost.Application.Services;
public class ParcelService : IParcelService
{
    private readonly IParcelRepository _repository;

    public ParcelService(IParcelRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> CreateParcelAsync(ParcelDto dto)
    {
        // 1. Tworzymy obiekt Domain (Entity), który sam wygeneruje TrackingNumber
        var parcel = new Parcel(dto.r_address);

        // 2. Dodajemy do repozytorium
        await _repository.AddAsync(parcel);

        // 3. Zapisujemy zmiany
        await _repository.SaveChangesAsync();

        return parcel.TrackingNumber;
    }

    public async Task<ParcelDto?> GetParcelByTrackingNumberAsync(string trackingNumber)
    {
        var parcel = await _repository.GetByTrackingNumberAsync(trackingNumber);
        if (parcel == null) return null;

        // Mapowanie Entity -> DTO (możesz to zrobić ręcznie lub AutoMapperem)
        return new ParcelDto
        {
            TrackingNumber = parcel.TrackingNumber,
            r_address = parcel.r_address
        };
    }
}