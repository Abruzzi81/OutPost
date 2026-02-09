using OutPost.Application.DTOs;
using OutPost.Domain.Enums;
using OutPost.Domain.Entities;

namespace OutPost.Application.Interfaces;

public interface ICourierService
{
    Task<bool> CreateCourierlAsync(CreateCourierDto dto);

    // Zwraca DTO z danymi o kurierze
    Task<CourierDto?> GetCourierAsync(int id);
    Task<IEnumerable<Courier>> GetAllAsync();

    // Zwraca aktualny status po zmianie
    Task<bool> UpdateEmploymentStatus(int id, bool isHired);
}
