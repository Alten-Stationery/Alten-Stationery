using DBLayer;
using DBLayer.IRepositories;
using DBLayer.Repositories;
using DBLayer.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

var app = builder.Build();

builder.Services.AddDbContext<StationeryContext>(options => 
    options.UseSqlServer("name=ConnectionStrings:StationeryDB"));

// Registrazione dei repository
builder.Services.AddScoped<IAlertsRepository, AlertsRepository>();
builder.Services.AddScoped<IItemsRepository, ItemsRepository>();
builder.Services.AddScoped<IRefillsRepository, RefillsRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

// Registrazione della Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Registrazione dei controller
//builder.Services.AddControllers();

app.Run();