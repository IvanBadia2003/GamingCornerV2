using AutoMapper;
using GamingCornerAPI.Application.Main.UserServices;
using GamingCornerAPI.CrossCutting.Mappings;
using GamingCornerAPI.Data.Main;
using GamingCornerAPI.Data.Main.Repositories.UserRepository;
using GamingCornerAPI.Domain.Entities;
using GamingCornerAPI.Domain.Main;
using GamingCornerAPI.Domain.Main.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutomapperConfiguration).Assembly);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Inyección de dependencias para el repositorio
builder.Services.AddScoped<IUserRepository, UsuarioRepository>();

// Inyección de dependencias para el servicio
builder.Services.AddScoped<IUserService ,UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
