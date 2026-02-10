using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OutPost.Application.DTOs;
using OutPost.Application.Interfaces;
namespace OutPost.Api.Controllers;


[ApiController]
[Route("api/courier")]
public class CourierController : ControllerBase
{
    private readonly ICourierService _courierService;

    public CourierController(ICourierService courierService)
    {
        _courierService = courierService;
    }

    // ===================================== POST =====================================

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [EndpointSummary("Tworzy nowego kuriera")]
    public async Task<IActionResult> Create([FromBody] CreateCourierDto courierDto)
    {

        if (!await _courierService.CreateCourierlAsync(courierDto))
            return BadRequest(new { error = "Nie udało się dodać kuriera. Sprawdź poprawność danych." });

        return Ok(new { message = "Kurier dodany do zespołu" });
    }


    // ===================================== GET =====================================

    [Authorize(Roles = "Admin")]
    [HttpGet]
    [EndpointSummary("Pobiera informacje o wszystkich kurierach")]
    public async Task<IActionResult> GetAllCouriers()
    {
        var couriers = await _courierService.GetAllAsync();
        if (couriers == null)
            return NotFound("Nie znaleziono kurierów");

        return Ok(couriers);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    [EndpointSummary("Pobiera informacje o danym kurierze")]
    public async Task<IActionResult> GetCourierById(int id)
    {
        CourierDto courier = await _courierService.GetCourierAsync(id);
        if (courier == null)
            return NotFound($"Nie znaleziono kuriera o ID {id}");

        return Ok(courier);
    }



    // ===================================== PUT =====================================

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}/status")]
    [EndpointSummary("Zmienia status zatrudnienia kuriera")]
    public async Task<IActionResult> UpdateEmploymentStatus(int id, bool isHired)
    {
        if (!await _courierService.UpdateEmploymentStatus(id, isHired))
            return NotFound($"Nie znaleziono kuriera o ID {id}");

        return Ok();
    }
}

