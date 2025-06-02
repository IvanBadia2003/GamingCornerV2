using GamingCorner.Data;
using GamingCorner.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using GamingCorner.Models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.Cookies;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173","https://7dz6xgfs-5173.uks1.devtunnels.ms")
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials();
                      });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


// var connectionString = builder.Configuration.GetConnectionString("ServerDB");
var connectionString = builder.Configuration.GetConnectionString("ServerDB");

builder.Services.AddScoped<IVideogameService, VideogameService>();
builder.Services.AddScoped<IVideogameRepository, VideogameEFRepository>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductEFRepository, ProductEFRepository>();

builder.Services.AddScoped<IGenderService, GenderService>();
builder.Services.AddScoped<IGenderRepository, GenderEFRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserEFRepository>();

builder.Services.AddScoped<ISecondHandProductService, SecondHandProductService>();
builder.Services.AddScoped<ISecondHandProductRepository, SecondHandProductEFRepository>();

builder.Services.AddScoped<IVideogameGenderService, VideogameGenderService>();
builder.Services.AddScoped<IVideogameGenderRepository, VideogameGenderEFRepository>();

builder.Services.AddScoped<IPlatformService, PlatformService>();
builder.Services.AddScoped<IPlatformRepository, PlatformEFRepository>();

builder.Services.AddScoped<IConsoleService, ConsoleService>();
builder.Services.AddScoped<IConsoleRepository, ConsoleEFRepository>();

builder.Services.AddScoped<IOrderHeaderService, OrderHeaderService>();
builder.Services.AddScoped<IOrderHeaderRepository, OrderHeaderEFRepository>();

builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IBasketRepository, BasketEFRepository>();

builder.Services.AddScoped<IFavouriteService, FavouriteService>();
builder.Services.AddScoped<IFavouriteRepository, FavouriteEFRepository>();

// Autenticaci�n con cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "MyApp.Auth";
        //options.LoginPath = "/User/login"; // ruta que redirige si no est� autenticado
        options.ExpireTimeSpan = TimeSpan.FromMinutes(5); // duraci�n
        options.SlidingExpiration = false; // NO renueva duraci�n si sigue activo
    });

// builder.Services.AddScoped<IIngredienteService, IngredienteService>();
// builder.Services.AddScoped<IIngredientesRepository, IngredienteEFRepository>();

// builder.Services.AddDbContext<ObraContext>(options =>
//     options.UseSqlServer(connectionString)
//     .LogTo(Console.WriteLine, LogLevel.Information));
builder.Services.AddDbContext<GamingCornerContext>(Options =>
        Options.UseSqlServer(connectionString)
        .LogTo(System.Console.WriteLine, LogLevel.Information));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura Kestrel para permitir HTTP
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000); // HTTP
    options.ListenAnyIP(5001, listenOptions => listenOptions.UseHttps());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}*/


app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
