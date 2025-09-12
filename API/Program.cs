using Application.Interfaces;
using Application.Services;
using Infrastructure;



var builder = WebApplication.CreateBuilder(args);

// ------------------------------
// Configuração de serviços
// ------------------------------

// Injetar Infrastructure (DbContext + Repositories)
builder.Services.AddInfrastructure(builder.Configuration);

// Injetar Application Services
builder.Services.AddScoped<IFleetService, FleetService>();

// Adicionar controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// ------------------------------
// Rodar app
// ------------------------------
app.Run();