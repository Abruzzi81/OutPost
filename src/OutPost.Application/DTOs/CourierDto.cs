
namespace OutPost.Application.DTOs;

public class CourierDto
{
    public required string Name { get; set; } = default!;
    DateOnly DateOfHire { get; set; }
    bool IsHired { get; set; }
}


