using DBLayer;
using DBLayer.IRepositories;
using DBLayer.Repositories;
using DBLayer.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceLayer.IServices;
using ServiceLayer.Services.Classes;


HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

var app = builder.Build();

//builder.Services.AddDbContext<StationeryContext>(options => 
//    options.UseSqlServer("name=ConnectionStrings:StationeryDB"));

//// Registrazione dei repository
//builder.Services.AddScoped<IAlertsRepository, AlertsRepository>();
//builder.Services.AddScoped<IItemsRepository, ItemsRepository>();
//builder.Services.AddScoped<IRefillsRepository, RefillsRepository>();
//builder.Services.AddScoped<IUsersRepository, UsersRepository>();

// Registrazione della Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IAlertsService, AlertsService>();
builder.Services.AddScoped<IRefillsService, RefillsService>();
builder.Services.AddScoped<IItemsService, ItemsService>();


// Registrazione dei controller
//builder.Services.AddControllers();

app.Run();