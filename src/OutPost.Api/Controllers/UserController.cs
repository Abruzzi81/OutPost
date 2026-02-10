using Microsoft.AspNetCore.Mvc;
using OutPost.Application.DTOs;
using OutPost.Application.Interfaces;
using OutPost.Application.Services;

namespace OutPost.Api.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // ===================================== POST =====================================

    [HttpPost]
    [EndpointSummary("Tworzy nowego klienta")]
    public async Task<IActionResult> AddUserAsync([FromBody] CreateUserDto dto)
    {
        string id = await _userService.CreateClientAsync(dto);

        return Ok(new { message = $"Utworzono nowego klienta o numerze ID: {id}"});
    }


    // ===================================== GET =====================================

    [HttpGet]
    [EndpointSummary("Pobiera dane o wszystkich klientach")]
    public async Task<IActionResult> GetAllUsersAsync()
    {
        var couriers = await _userService.GetAllClientsAsync();
        if (couriers == null)
            return NotFound("Nie znaleziono klientów");

        return Ok(couriers);
    }

    [HttpGet("{id}")]
    [EndpointSummary("Pobiera informacje o danym kliencie")]
    public async Task<IActionResult> GetUserByIdAsync(string id)
    {
        var client = await _userService.GetClientByIdAsync(id);
        if (client == null) 
            return NotFound($"Nie znaleziono kuriera o numerze ID: {id}");

        return Ok(client);
    }


}

