using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OutPost.Application.Abstractions; 
using OutPost.Application.Interfaces;
using OutPost.Application.LabelGenerator;
using OutPost.Application.Services;
using OutPost.Domain.Entities;
using OutPost.Infrastructure.Persistence; 
using OutPost.Infrastructure.Repositories;
using QuestPDF.Infrastructure;
using System.Text;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Ta linia rozwi¹zuje problem z 403 przy rolach
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

// Rejestracja generatora Swaggera
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Rejestracja Repozytoriów i Serwisów
builder.Services.AddScoped<IParcelService, ParcelService>();
builder.Services.AddScoped<IParcelRepository, ParcelRepository>();
builder.Services.AddScoped<LabelService>();

builder.Services.AddScoped<ICourierRepository, CourierRepository>();
builder.Services.AddScoped<ICourierService, CourierService>();

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IUserService, UserService>();


// =========================== Tworzenie ról ===========================

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = false; // Twoje opcje hase³
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "TwójSystem",
        ValidAudience = "TwójSystem",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TwójBardzoD³ugiSekretnyKlucz123!"))
    };
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "OutPost API",
        Version = "v1"
    });

    // 1. Definicja zabezpieczeñ
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Wpisz sam token JWT",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    };

    options.AddSecurityDefinition("Bearer", securityScheme);

    // 2. Wymaganie zabezpieczeñ
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


var app = builder.Build();


// Tworzymy scope, aby dobraæ siê do us³ug zarejestrowanych w kontenerze DI
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

    string[] roles = { "Admin", "User" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }

    // --- LOGIKA TWORZENIA ADMINA ---
    var adminEmail = "admin@outpost.pl";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        // 1. Wywo³ujemy konstruktor z parametrami User
        var newAdmin = new User("Admin Account", "Main Office 1", "000000000");

        // 2. Identity wymaga UserName i Email, wiêc musimy je przypisaæ po stworzeniu obiektu
        newAdmin.UserName = adminEmail;
        newAdmin.Email = adminEmail;

        // 3. Tworzymy u¿ytkownika w bazie (z has³em)
        var result = await userManager.CreateAsync(newAdmin, "Admin123!");

        if (result.Succeeded)
        {
            // 4. Przypisujemy rolê
            await userManager.AddToRoleAsync(newAdmin, "Admin");
        }
    }
}

    // Konfiguracja licencji QuestPDF (do tworzenia etykiety)
    QuestPDF.Settings.License = LicenseType.Community;


app.UseSwagger();
app.UseSwaggerUI();


/// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication(); // Kto to jest? (Logowanie)
app.UseAuthorization();
app.MapControllers();
app.MapRazorPages();
app.Run();
