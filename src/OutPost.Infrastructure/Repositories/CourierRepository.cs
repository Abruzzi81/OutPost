using OutPost.Application.Abstractions;
using OutPost.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using OutPost.Infrastructure.Persistence;


namespace OutPost.Infrastructure.Repositories;

public class CourierRepository : ICourierRepository
{
    private readonly AppDbContext _context;

    public CourierRepository(AppDbContext context)
    {
        _context = context;
    }


    // Funkcje


    // Dodawanie nowego kuriera do kolejki zapisu
    public async Task AddAsync(Courier courier)
    {
        await _context.Couriers.AddAsync(courier);
    }

    public async Task<Courier?> GetByIdAsync(int id)
    {
        return await _context.Couriers
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    // Zapisywanie wszystkich zmian w bazie danych
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Courier courier)
    {
        _context.Couriers.Update(courier);
        await _context.SaveChangesAsync();
    }

}