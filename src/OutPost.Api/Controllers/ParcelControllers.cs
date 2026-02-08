using Microsoft.AspNetCore.Mvc;
using OutPost.Application.Interfaces;
using OutPost.Application.DTOs;
using OutPost.Domain.Enums;

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


        // Sprawdzanie poprawnosci danych
        if (dto.s_Phone_number.Length != 9)
            return BadRequest("Niepoprawny numer telefonu nadawcy");

        if (dto.r_Phone_number.Length != 9)
            return BadRequest("Niepoprawny numer telefonu adresata");

        if (!dto.s_Email.Contains('@'))
            return BadRequest("Niepoprawny adres email nadawcy");

        if (!dto.r_Email.Contains('@'))
            return BadRequest("Niepoprawny adres email adresata");

        return Ok(new { Message = "Paczka utworzona!", TrackingNumber = trackingNumber });
    }

    [HttpGet("{trackingNumber}")]
    public async Task<IActionResult> GetParcelByTrackingNumber(string trackingNumber)
    {
        ParcelDto parcel = await _parcelService.GetParcelByTrackingNumberAsync(trackingNumber);
        if (parcel == null)  
            return NotFound($"Paczka o numerze {trackingNumber} nie istnieje.");

        return Ok(parcel);
    }

    [HttpPut("{trackingNumber}/status")]
    public async Task<IActionResult> UpdateStatus(string trackingNumber,[FromBody] ParcelStatus newStatus)
    {
        bool success = await _parcelService.UpdateParcelStatus(trackingNumber, newStatus);

        if (!success)
            return NotFound($"Nie istnieje paczka o numerze {trackingNumber}");

        return Ok(new {Message = "Pomyslnie zmieniono status" });
    }
}