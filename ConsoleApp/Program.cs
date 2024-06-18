using ConsoleApp;
using DBLayer;
using DBLayer.IRepositories;
using DBLayer.Models;
using DBLayer.Repositories;
using DBLayer.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceLayer.IServices;
using ServiceLayer.Services.Classes;


HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

//builder.Services.AddDbContext<StationeryContext>(options => 
//    options.UseSqlServer("name=ConnectionStrings:StationeryDB"));

//// Registrazione dei repository
//builder.Services.AddScoped<IAlertsRepository, AlertsRepository>();
//builder.Services.AddScoped<IItemsRepository, ItemsRepository>();
//builder.Services.AddScoped<IRefillsRepository, RefillsRepository>();
//builder.Services.AddScoped<IUsersRepository, UsersRepository>();

StationeryContext _context = new StationeryContext();
// Registrazione della Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Configuration.AddJsonFile("appsettings.json");
var connectionString = builder.Configuration.GetConnectionString("StationeryDB");

//builder.Services.AddDbContext<StationeryContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IAlertsService, AlertsService>();
builder.Services.AddScoped<IRefillsService, RefillsService>();
builder.Services.AddScoped<IItemsService, ItemsService>();
builder.Services.AddScoped<IUsersService, UsersService>();



// Registrazione dei controller
//builder.Services.AddControllers();
var app = builder.Build();
app.Run();
