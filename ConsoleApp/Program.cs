using DBLayer;
using DBLayer.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
var app= builder.Build();
app.Run();