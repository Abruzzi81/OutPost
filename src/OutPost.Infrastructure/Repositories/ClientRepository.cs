
using Microsoft.EntityFrameworkCore;
using OutPost.Application.Abstractions;
using OutPost.Domain.Entities;
using OutPost.Infrastructure.Persistence;

namespace OutPost.Infrastructure.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly AppDbContext _context;

    public ClientRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task AddAsync(Client client)
    {
        await _context.Clients.AddAsync(client);
    }

    public async Task<Client?> GetByIdAsync(int id)
    {
        return await _context.Clients
            .FirstOrDefaultAsync(c => c.Id == id);
    }
    public async Task<IEnumerable<Client>> GetAllAsync()
    {
        return await _context.Clients.ToListAsync();
    }


    // Zapisywanie wszystkich zmian w bazie danych
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Client client)
    {
        _context.Clients.Update(client);
        await _context.SaveChangesAsync();
    }
}
