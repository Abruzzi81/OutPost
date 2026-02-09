
using OutPost.Domain.Entities;

namespace OutPost.Application.DTOs;

public class CreateParcelDto()
{
    // Sender
    public int Sender_Id { get; set; }
    public required Client Sender { get; set; }
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
