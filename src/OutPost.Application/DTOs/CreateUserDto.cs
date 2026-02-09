namespace OutPost.Application.DTOs;

public class CreateUserDto
{
    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string Phone_Number { get; set; } = default!;
}