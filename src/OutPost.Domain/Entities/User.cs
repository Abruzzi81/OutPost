using Microsoft.AspNetCore.Identity;

namespace OutPost.Domain.Entities;

public class User : IdentityUser
{
    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string Phone_Number { get; set; } = default!;

    public ICollection<Parcel> SentParcels {  get; set; } = new List<Parcel>();
    public ICollection<Parcel> RecivedParcels { get; set; } = new List<Parcel>();


    public User() { }
    public User(string name, string address, string phone_Number)
    {
        Name = name;
        Address = address;
        Phone_Number = phone_Number;
    }

}
