
namespace OutPost.Application.DTOs;

public class CreateCourierDto
{
    public required string Name { get; set; } = default!;
    public DateOnly DateOfHire { get; set; }
}
