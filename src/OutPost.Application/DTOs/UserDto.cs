
using OutPost.Domain.Entities;

namespace OutPost.Application.DTOs;

public class UserDto {
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string Phone_Number { get; set; } = default!;

    public ICollection<Parcel> SentParcels { get; set; } = new List<Parcel>();
    public ICollection<Parcel> RecivedParcels { get; set; } = new List<Parcel>();
}