using Application.Interfaces;
using Application.Services;
using Application.Configs;
using Infrastructure;
using API.Extensions;


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

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger(configs);

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
        ui.SwaggerEndpoint("/swagger/v1/swagger.json",  "WEB.API v1");
        ui.SwaggerEndpoint("/swagger/v2/swagger.json",  "WEB.API v2");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// ------------------------------
// Rodar app
// ------------------------------
app.Run();