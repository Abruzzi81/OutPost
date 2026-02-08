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
    public string s_Name { get; set; } = default!;
    public string s_Address { get; set; } = default!;
    public string s_Email { get; set; } = default!;
    public string s_Phone_number { get; set; } = default!;

    // Recipient
    public string r_Name { get; set; } = default!;
    public string r_Address { get; set; } = default!;
    public string r_Email { get; set; } = default!;
    public string r_Phone_number { get; set; } = default!;


    // Constructor
    private Parcel() { }
    public Parcel(string s_name, string s_address, string s_email, string s_phone_number,
                  string r_name, string r_address, string r_email, string r_phone_number )
    {
        DateOfCreation = DateTime.Now;
        TrackingNumber = CreateTrackingNumber();
        Status = ParcelStatus.Created;

        s_Name = s_name;
        s_Address = s_address;
        s_Email = s_email;
        s_Phone_number = s_phone_number;

        r_Name = r_name;
        r_Address = r_address;
        r_Email = r_email;
        r_Phone_number = r_phone_number;        
    }


    public void ChangeStatus(ParcelStatus status)
    {
        Status = status;
    }

    private string CreateTrackingNumber()
    {
        int rangeNumber = Random.Shared.Next(1000, 10000);

        return DateOfCreation.Year.ToString() + DateOfCreation.Month.ToString() + DateOfCreation.Day.ToString() + DateOfCreation.Millisecond.ToString() 
                + rangeNumber.ToString();
    }
}