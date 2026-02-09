namespace OutPost.Application.DTOs;

public class CreateClientDto
{
    public string Name { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Phone_Number { get; set; } = default!;
}