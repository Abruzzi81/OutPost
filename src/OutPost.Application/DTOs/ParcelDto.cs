
using OutPost.Domain.Enums;

namespace OutPost.Application.DTOs;

public class ParcelDto
{
    public required string TrackingNumber { get; set; } = default!;
    public ParcelStatus Status { get; set; }

    // Sender
   // public required string s_Name { get; set; }
  //  public required string s_addres { get; set; }
  //  public required string s_email { get; set; }
   // public required string s_phone_number { get; set; }

    // Recipient
  //  public required string r_Name { get; set; }
    public required string r_address { get; set; }
  //  public required string r_email { get; set; }
  //  public required string r_phone_number { get; set;
  //  

}

public class CreateParcelDto()
{
    public required string r_address { get; set; }
}
