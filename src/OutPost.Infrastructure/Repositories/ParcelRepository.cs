using OutPost.Application.Abstractions;
using OutPost.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using OutPost.Domain.Entities;

namespace OutPost.Infrastructure.Repositories;

public class ParcelRepository : IParcelRepository
{
    private readonly AppDbContext _context;

    public ParcelRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Parcel parcel)
    {
        await _context.Parcels.AddAsync(parcel);
    }

    public async Task<Parcel?> GetByTrackingNumberAsync(string trackingNumber)
    {
        return await _context.Parcels
            .FirstOrDefaultAsync(p => p.TrackingNumber == trackingNumber);
    }

    public async Task<IEnumerable<Parcel>> GetAllParcelsAsync()
    {
        return await _context.Parcels.ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Parcel parcel)
    {
        _context.Parcels.Update(parcel);
        await _context.SaveChangesAsync();
    }
}