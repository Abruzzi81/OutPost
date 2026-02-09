using OutPost.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace OutPost.Domain.Entities;

public class Parcel
{
    [Key]
    public int Id { get; set; }
    public string TrackingNumber { get; set; } = default!;
    public ParcelStatus Status { get; set; }
    public DateTime DateOfCreation { get; set; }

    // Sender
    public string SenderId { get; set; }
    public User Sender { get; set; }
    public string s_Name { get; set; } = default!;
    public string s_Address { get; set; } = default!;
    public string s_Email { get; set; } = default!;
    public string s_PhoneNumber { get; set; } = default!;

    // Recipient
    public string r_Name { get; set; } = default!;
    public string r_Address { get; set; } = default!;
    public string r_Email { get; set; } = default!;
    public string r_PhoneNumber { get; set; } = default!;





    // ================================= Constructor =================================
    private Parcel() { }
    public Parcel(string s_id, string s_name, string s_address, string s_email, string s_phoneNumber,
                  string r_name, string r_address, string r_email, string r_phoneNumber )
    {
        DateOfCreation = DateTime.Now;
        TrackingNumber = "";
        Status = ParcelStatus.Created;

        SenderId = s_id;
        s_Name = s_name;
        s_Address = s_address;
        s_Email = s_email;
        s_PhoneNumber = s_phoneNumber;

        r_Name = r_name;
        r_Address = r_address;
        r_Email = r_email;
        r_PhoneNumber = r_phoneNumber;        
    }


    public void ChangeStatus(ParcelStatus status)
    {
        Status = status;
    }

    public string CreateTrackingNumber()
    {
        int rangeNumber = Random.Shared.Next(0, 10000);

        return DateOfCreation.ToString("yy") //ostatnie 2 cyfry roku
            + DateOfCreation.Month.ToString("D2")
            + DateOfCreation.Day.ToString("D2")
            + Id.ToString("D5")
            + DateOfCreation.Millisecond.ToString("D3") 
            + rangeNumber.ToString("D4");
    }
}