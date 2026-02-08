using Microsoft.AspNetCore.Mvc;
using OutPost.Application.Interfaces;
using OutPost.Application.DTOs;

namespace OutPost.Api.Controllers;

[ApiController]
[Route("api/parcels")]
public class ParcelsController : ControllerBase
{
    private readonly IParcelService _parcelService;

    // Konstruktor wstrzykuje IParcelService, który zarejestrowaliśmy w Program.cs
    public ParcelsController(IParcelService parcelService)
    {
        _parcelService = parcelService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateParcelDto dto)
    {
        // Serwis zajmie się resztą: nada TrackingNumber i ustawi Status na 'New'
        var trackingNumber = await _parcelService.CreateParcelAsync(dto);

        return Ok(new { Message = "Paczka utworzona!", TrackingNumber = trackingNumber });
    }
}