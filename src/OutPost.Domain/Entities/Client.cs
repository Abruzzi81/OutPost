
namespace OutPost.Domain.Entities;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Phone_Number { get; set; } = default!;

    public ICollection<Parcel> SentParcels {  get; set; } = new List<Parcel>();
    public ICollection<Parcel> RecivedParcels { get; set; } = new List<Parcel>();


    public Client() { }
    public Client(string name, string password, string address, string email, string phone_Number)
    {
        Name = name;
        Password = password;
        Address = address;
        Email = email;
        Phone_Number = phone_Number;
    }

}
