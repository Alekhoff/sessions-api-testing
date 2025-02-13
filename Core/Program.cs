using System.Reflection;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

var allAssemblies = AppDomain.CurrentDomain.GetAssemblies();
var controllerTypes = allAssemblies
    .SelectMany(pAssembly => pAssembly.GetTypes())
    .Where(pType => typeof(ControllerBase).IsAssignableFrom(pType) && !pType.IsAbstract);

foreach (var controllerType in controllerTypes)
{
    builder.Services.AddControllers()
        .AddApplicationPart(controllerType.Assembly)
        .AddControllersAsServices();
}


var startupType = typeof(IModuleStartup);
var startupInstances = Assembly.GetExecutingAssembly()
    .GetTypes()
    .Where(pType => startupType.IsAssignableFrom(pType) && pType is { IsInterface: false, IsAbstract: false })
    .Select(Activator.CreateInstance)
    .Cast<IModuleStartup>();

foreach (var startup in startupInstances)
{
    startup.ConfigureServices(builder.Services, builder.Configuration);
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();