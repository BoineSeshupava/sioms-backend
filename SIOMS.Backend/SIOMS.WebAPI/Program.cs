using SIOMS.Infrastructure;
using SIOMS.Application.Interfaces;
using SIOMS.Application.Profiles;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SIOMS.Infrastructure.Persistence;
using SIOMS.Infrastructure.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "SIOMS Web API",
        Version = "v1",
        Description = "Sales Inventory Order Management System API"
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SIOMSDbContext>();
    context.Database.Migrate();
    SeedData.SeedDatabase(context);
}
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

