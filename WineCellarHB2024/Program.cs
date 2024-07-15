using DAL;
using DAL.Business;
using DAL.Interfaces;
using DAL.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CellarContext>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBottleRepository, BottleRepository>();
builder.Services.AddScoped<ICellarRepository, CellarRepository>();
builder.Services.AddScoped<IDrawerRepository, DrawerRepository>();
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<CellarUser>(
    c =>
    {
        c.Password.RequiredLength = 2;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CellarContext>();

builder.Services.AddDbContext<CellarContext>(options =>
{
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CellarDB;Trusted_Connection=True");
});
builder.Services.AddScoped<IBottleBusiness, BottleBusiness>();  
builder.Services.AddScoped<IDrawerBusiness, DrawerBusiness>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
