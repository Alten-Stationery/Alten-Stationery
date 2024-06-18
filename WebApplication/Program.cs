using DBLayer;
using DBLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.IServices;
using ServiceLayer.Services.Classes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddDbContext<StationeryContext>(options =>options.UseSqlServer("name=ConnectionStrings:StationeryDB"));

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<StationeryContext>()
    .AddApiEndpoints();

//builder.Services.AddDbContext<StationeryContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("StationaryDB")));

//builder.Services.AddScoped<IAlertsService, AlertsService>();
//builder.Services.AddScoped<IRefillsService, RefillsService>();
//builder.Services.AddScoped<IItemsService, ItemsService>();
//builder.Services.AddScoped<IUsersService, UsersService>();



var app = builder.Build();

app.MapIdentityApi<User>();
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
