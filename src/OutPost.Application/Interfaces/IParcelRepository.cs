using OutPost.Domain;

namespace OutPost.Application.Interfaces;

public interface IParcelRepository
{
    Task<Parcel> GetByTrackingNumberAsync(string trackingNumber);
    Task AddAsync(Parcel parcel);
    Task UpdateAsync(Parcel parcel);
    Task SaveChangesAsync();
}
