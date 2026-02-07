using OutPost.Domain.Enums;

namespace OutPost.Domain;

public class Parcel
{
    public int Id { get; set; }
    public string TrackingNumber { get; set; } = default!;
    public ParcelStatus Status { get; set; }
    public DateTime dateOfCreation { get; set; }

    // Sender
    public string s_Name { get; set; } = default!;
    public string s_address { get; set; } = default!;
    public string s_email { get; set; } = default!;
    public string s_phone_number { get; set; } = default!;

    // Recipient
    public string r_Name { get; set; } = default!;
    public string r_address { get; set; } = default!;
    public string r_email { get; set; } = default!;
    public string r_phone_number { get; set; } = default!;


    // Constructor
    private Parcel() { }
    public Parcel(string address)
    {
        dateOfCreation = DateTime.Now;
        TrackingNumber = dateOfCreation.ToString();
        r_address = address;
        Status = ParcelStatus.Created;
    }


    public void ChangeStatus(ParcelStatus status)
    {
        Status = status;
    }
}