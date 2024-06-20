using DBLayer;
using DBLayer.Models;
using DBLayer.UOW;
using Microsoft.AspNetCore.Identity;
using ServiceLayer.IServices;
using ServiceLayer.Services.Classes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<StationeryContext>()
    .AddApiEndpoints();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IAlertsService, AlertsService>();
builder.Services.AddScoped<IRefillsService, RefillsService>();
builder.Services.AddScoped<IItemsService, ItemsService>();
builder.Services.AddScoped<IUsersService, UsersService>();



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

//app.MapIdentityApi<StationeryContext>();

app.Run();
