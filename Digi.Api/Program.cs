using Digi.Core.Devices;
using Digi.Core.Geofences;
using Scalar.AspNetCore;
//using Digi.Infrastructure.Devices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddSingleton<IDeviceRepository, InMemoryDeviceRepository>();

var app = builder.Build();

//Boa pratica: UI só em Development
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}


app.MapGet("/health", () => Results.Ok("OK"));

app.MapGet("/devices/{id:int}", async (int id, IDeviceRepository repo, CancellationToken ct) =>
{
    var device = await repo.GetDeviceIdAsync(id, ct);
    return device is null ? Results.NotFound() : Results.Ok(device);
});

app.MapGet("/geofence/decide", (bool wasInside, bool isInside) =>
{
    var ev = GeofenceDecision.Decide(wasInside, isInside);
    return Results.Ok(ev.ToString());
});

app.Run();

// necessário para WebApplicationFactory (testes de integração)
public partial class Program { }
