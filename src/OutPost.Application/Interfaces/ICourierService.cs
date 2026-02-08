using OutPost.Application.DTOs;
using OutPost.Domain.Enums;

namespace OutPost.Application.Interfaces;

public interface ICourierService
{
    // Zwraca tracking number po utworzeniu
    Task<bool> CreateCourierlAsync(CreateCourierDto dto);

    // Zwraca DTO z danymi o paczce
    Task<CourierDto?> GetCourierAsync(int id);

    // Zwraca aktualny status po zmianie
    Task<bool> UpdateEmploymentStatus(int id, bool status);
}
