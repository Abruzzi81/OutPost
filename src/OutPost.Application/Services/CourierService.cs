using OutPost.Application.Abstractions;
using OutPost.Application.DTOs;
using OutPost.Application.Interfaces;
using OutPost.Domain.Entities;
using OutPost.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutPost.Application.Services;

public class CourierService : ICourierService
{
    private readonly ICourierRepository _repository;

    public CourierService(ICourierRepository repository)
    {
        _repository = repository;
    }



    public async Task<bool> CreateCourierlAsync(CreateCourierDto dto)
    {
        var courier = new Courier(dto.Name, dto.DateOfHire);
        if (courier == null) return false;

        await _repository.AddAsync(courier);
        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task<CourierDto?> GetCourierAsync(int id)
    {
        return null;
    }

    public async Task<bool> UpdateEmploymentStatus(int id, bool status)
    {
        return false;
    }
}