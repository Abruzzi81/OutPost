using Microsoft.AspNetCore.Mvc;
using OutPost.Application.DTOs;
using OutPost.Application.Interfaces;
using OutPost.Application.LabelGenerator;
using OutPost.Domain.Enums;

namespace OutPost.Api.Controllers;

[ApiController]
[Route("api/parcel")]
public class ParcelController : ControllerBase
{
    private readonly IParcelService _parcelService;
    private readonly LabelService _labelService;

    // Konstruktor wstrzykuje IParcelService
    public ParcelController(IParcelService parcelService, LabelService labelService)
    {
        _parcelService = parcelService;
        _labelService = labelService;
    }


    // ===================================== POST =====================================

    [HttpPost]
    [EndpointSummary("Tworzy nową paczkę")]
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


    // ===================================== GET =====================================

    [HttpGet("all")]
    [EndpointSummary("Pobiera informacje o wszystkich paczkach")]
    public async Task<IActionResult> GetAllParcels()
    {
        var parcels = await _parcelService.GetAllParcels();
        if (parcels == null)
            return NotFound("Nie znaleziono żadnych paczek");

        return Ok(parcels);
    }

    [HttpGet("{trackingNumber}")]
    [EndpointSummary("Pobiera informacje o danej paczce")]
    public async Task<IActionResult> GetParcelByTrackingNumber(string trackingNumber)
    {
        ParcelDto parcel = await _parcelService.GetParcelByTrackingNumberAsync(trackingNumber);
        if (parcel == null)  
            return NotFound($"Paczka o numerze {trackingNumber} nie istnieje.");

        return Ok(parcel);
    }

    [HttpGet("{trackingNumber}/label")]
    [EndpointSummary("Generuje etykiete")]
    public async Task<IActionResult> GetLabel(string trackingNumber)
    {
        var parcel = await _parcelService.GetParcelByTrackingNumberAsync(trackingNumber);
        if (parcel == null) return NotFound();

        var pdfBytes = _labelService.GenerateParcelLabel(parcel);

        // Zwracasz plik, który przeglądarka od razu pobierze lub wyświetli
        return File(pdfBytes, "application/pdf", $"Etykieta_{parcel.TrackingNumber}.pdf");
    }


    // ===================================== PUT =====================================

    [HttpPut("{trackingNumber}/status")]
    [EndpointSummary("Zmienia status paczki")]
    public async Task<IActionResult> UpdateStatus(string trackingNumber,[FromBody] ParcelStatus newStatus)
    {
        bool success = await _parcelService.UpdateParcelStatus(trackingNumber, newStatus);

        if (!success)
            return NotFound($"Nie istnieje paczka o numerze {trackingNumber}");

        return Ok(new {Message = "Pomyslnie zmieniono status" });
    }
}