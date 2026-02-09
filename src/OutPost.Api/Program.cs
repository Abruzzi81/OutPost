using Microsoft.EntityFrameworkCore;
using OutPost.Application.Abstractions; 
using OutPost.Application.Services;
using OutPost.Application.Interfaces;
using OutPost.Infrastructure.Persistence; 
using OutPost.Infrastructure.Repositories;

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

// Rejestracja Repozytorium i Serwisu Kuriera
builder.Services.AddScoped<ICourierRepository, CourierRepository>();
builder.Services.AddScoped<ICourierService, CourierService>();

// Konfiguracja bazy danych (ConnectionString pobierany z appsettings.json)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Rejestracja Repozytorium


var app = builder.Build();


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
