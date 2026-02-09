
namespace OutPost.Application.DTOs;

public class CourierDto
{
    public int Id { get; set; }
    public required string Name { get; set; } = default!;
    public DateOnly DateOfHire { get; set; }
    public bool IsHired { get; set; }
}


