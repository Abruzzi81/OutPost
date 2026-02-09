using Microsoft.AspNetCore.Mvc;
using OutPost.Application.DTOs;
using OutPost.Application.Interfaces;

namespace OutPost.Api.Controllers;

[ApiController]
[Route("api/client")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    // ===================================== POST =====================================

    [HttpPost]
    [EndpointSummary("Tworzy nowego klienta")]
    public async Task<IActionResult> AddClientAsync([FromBody] CreateClientDto dto)
    {
        int id = await _clientService.CreateClientAsync(dto);

        return Ok(new { message = $"Utworzono nowego klienta o numerze ID: {id}"});
    }


    // ===================================== GET =====================================

    [HttpGet]
    [EndpointSummary("Pobiera dane o wszystkich klientach")]
    public async Task<IActionResult> GetAllClientsAsync()
    {
        var couriers = await _clientService.GetAllClientsAsync();
        if (couriers == null)
            return NotFound("Nie znaleziono klientów");

        return Ok(couriers);
    }

    [HttpGet("{id}")]
    [EndpointSummary("Pobiera informacje o danym kliencie")]
    public async Task<IActionResult> GetClientByIdAsync(int id)
    {
        var client = await _clientService.GetClientByIdAsync(id);
        if (client == null) 
            return NotFound($"Nie znaleziono kuriera o numerze ID: {id}");

        return Ok(client);
    }


}

