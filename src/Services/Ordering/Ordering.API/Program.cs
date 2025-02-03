using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);

var app = builder.Build();
if(app.Environment.IsDevelopment())
{
    await app.IntializeDatabaseAsync();
}
// Configure the HTTP request pipeline.
app.UseApiService();

app.Run();
