using System.Reflection;
using CoreLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(pOptions =>
{
    pOptions.AddPolicy("AllowAll", pBuilder =>
    {
        pBuilder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
    pOptions.AddPolicy("Test", pBuilder =>
    {
        pBuilder.WithOrigins("http://localhost:3000");
    });
});

// Load Projects
PersonsApi.Startup.RegisterModule(builder.Services, builder.Configuration);
WeatherForecastApi.Startup.RegisterModule(builder.Services, builder.Configuration);

builder.Services.AddControllers();

// Logging 
// Log all registered services in the ServiceCollection
Console.WriteLine("Custom Registered Services:");
var myServices = builder.Services
    .Where(pService => pService.ServiceType.Namespace != null && 
                      pService.ServiceType.Namespace.StartsWith("PersonsApi") || 
                      pService.ServiceType.Namespace.StartsWith("WeatherForecastApi"))
    .ToList();

foreach (var service in myServices)
{
    Console.WriteLine($"ServiceType: {service.ServiceType.FullName}, Lifetime: {service.Lifetime}, ImplementationType: {service.ImplementationType?.FullName}");
}


// Log all controller types explicitly
var controllerTypes = AppDomain.CurrentDomain.GetAssemblies()
    .SelectMany(pAssembly => pAssembly.GetExportedTypes())
    .Where(pType => typeof(ControllerBase).IsAssignableFrom(pType) && !pType.IsAbstract);

foreach (var controller in controllerTypes)
{
    Console.WriteLine($"Controller: {controller.FullName}");
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.MapHealthChecks("/health");

app.UseAuthorization();

app.MapControllers();

app.Run();