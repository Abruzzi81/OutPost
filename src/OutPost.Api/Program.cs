using Microsoft.EntityFrameworkCore;
using OutPost.Application.Abstractions; 
using OutPost.Application.Services;
using OutPost.Application.Interfaces;
using OutPost.Infrastructure.Persistence; 
using OutPost.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Rejestracja serwisu (Scoped oznacza, ¿e ¿yje przez czas trwania jednego ¿¹dania HTTP)
builder.Services.AddScoped<IParcelService, ParcelService>();

// 1. Konfiguracja bazy danych (ConnectionString pobierany z appsettings.json)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Rejestracja Repozytorium
builder.Services.AddScoped<IParcelRepository, ParcelRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
