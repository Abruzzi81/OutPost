using OutPost.Application.Abstractions;
using OutPost.Domain;
using OutPost.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}