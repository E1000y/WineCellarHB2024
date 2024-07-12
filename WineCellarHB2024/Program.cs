using DAL;
using DAL.Business;
using DAL.Interfaces;
using DAL.Repository;

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
builder.Services.AddScoped<IBottleBusiness, BottleBusiness>();  

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
