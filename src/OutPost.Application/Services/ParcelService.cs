using OutPost.Application.Abstractions;
using OutPost.Application.DTOs;
using OutPost.Application.Interfaces;
using OutPost.Domain.Entities;
using OutPost.Domain.Enums;

namespace OutPost.Application.Services;
public class ParcelService : IParcelService
{
    private readonly IParcelRepository _repository;

    public ParcelService(IParcelRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> CreateParcelAsync(CreateParcelDto dto)
    {
        // 1. Tworzymy obiekt Domain (Entity), który sam wygeneruje TrackingNumber
        var parcel = new Parcel(dto.s_Name, dto.s_Addres, dto.s_Email, dto.s_Phone_number, dto.r_Name, dto.r_Address, dto.r_Email, dto.r_Phone_number);

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
            Status = parcel.Status,
            s_Name = parcel.s_Name,
            s_Address = parcel.s_Address,
            s_Email = parcel.s_Email,
            s_Phone_number = parcel.s_Phone_number,

            r_Name = parcel.r_Name,
            r_Address = parcel.r_Address,
            r_Email = parcel.r_Email,
            r_Phone_number = parcel.r_Phone_number
        };

    }

    public async Task<bool> UpdateParcelStatus(string trackingNumber, ParcelStatus newStatus)
    {
        var parcel = await _repository.GetByTrackingNumberAsync(trackingNumber);
        if (parcel == null) return false;

        parcel.Status = newStatus;
        await _repository.UpdateAsync(parcel);

        return true;
    }
}