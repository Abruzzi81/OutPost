using Microsoft.EntityFrameworkCore;
using OutPost.Application.Abstractions; 
using OutPost.Application.Interfaces;
using OutPost.Application.LabelGenerator;
using OutPost.Application.Services;
using OutPost.Infrastructure.Persistence; 
using OutPost.Infrastructure.Repositories;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Rejestracja generatora Swaggera
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddRazorPages();

// Rejestracja Repozytorium i Serwisu Paczki
builder.Services.AddScoped<IParcelService, ParcelService>();
builder.Services.AddScoped<IParcelRepository, ParcelRepository>();
builder.Services.AddScoped<LabelService>();

// Rejestracja Repozytorium i Serwisu Kuriera
builder.Services.AddScoped<ICourierRepository, CourierRepository>();
builder.Services.AddScoped<ICourierService, CourierService>();

// Rejestracja Repozytorium i Serwisu Klienta
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();

// Konfiguracja bazy danych (ConnectionString pobierany z appsettings.json)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



var app = builder.Build();

// Konfiguracja licencji QuestPDF
QuestPDF.Settings.License = LicenseType.Community;

app.UseSwagger();
app.UseSwaggerUI();
/// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // TE DWIE LINIE S¥ KLUCZOWE:

}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

app.Run();
