using Application.Interfaces;
using Application.Services;
using Application.Configs;
using Infrastructure;
using API.Extensions;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

var configs = builder.Configuration.Get<Settings>();
builder.Services.AddSingleton(configs);

// ------------------------------
// Configuração de serviços
// ------------------------------

// Injetar Infrastructure (DbContext + Repositories)
builder.Services.AddInfrastructure(builder.Configuration);

// Injetar Application Services
builder.Services.AddScoped<IFleetService, FleetService>();

// Adicionar controllers
builder.Services.AddControllers();

// ------------------------------
// Versionamento da API
// ------------------------------
builder.Services.AddVersioning();

// ------------------------------
// Swagger
// ------------------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger(configs);

// ------------------------------
// Health Checks
// ------------------------------
builder.Services.AddHealthCheckConfiguration(builder.Configuration);

// ------------------------------
// Build do app
// ------------------------------

var app = builder.Build();

// ------------------------------
// Pipeline HTTP
// ------------------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(ui =>
    {
        ui.SwaggerEndpoint("/swagger/v1/swagger.json", "WEB.API v1");
        ui.SwaggerEndpoint("/swagger/v2/swagger.json", "WEB.API v2");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

// ------------------------------
// Health Check Endpoints
// ------------------------------
app.MapHealthChecks("/health");
app.MapHealthChecks("/health-details", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapControllers();

// ------------------------------
// Rodar app
// ------------------------------
app.Run();