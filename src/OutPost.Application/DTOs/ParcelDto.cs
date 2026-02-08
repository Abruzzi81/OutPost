
using OutPost.Domain.Enums;

namespace OutPost.Application.DTOs;

public class ParcelDto
{
    public required string TrackingNumber { get; set; } = default!;
    public ParcelStatus Status { get; set; }

    // Sender
    public required string s_Name { get; set; }
    public required string s_Address { get; set; }
    public required string s_Email { get; set; }
    public required string s_Phone_number { get; set; }

    // Recipient
    public required string r_Name { get; set; }
    public required string r_Address { get; set; }
    public required string r_Email { get; set; }
    public required string r_Phone_number { get; set; }
}

public class CreateParcelDto()
{
    // Sender
    public required string s_Name { get; set; }
    public required string s_Addres { get; set; }
    public required string s_Email { get; set; }
    public required string s_Phone_number { get; set; }

    // Recipient
    public required string r_Name { get; set; }
    public required string r_Address { get; set; }
    public required string r_Email { get; set; }
    public required string r_Phone_number { get; set; }
}
