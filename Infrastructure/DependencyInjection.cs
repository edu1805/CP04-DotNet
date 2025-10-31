using Domain.Interfaces;
using Infrastructure.persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Persistence;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configurações do MongoDB
            services.Configure<MongoSettings>(configuration.GetSection("MongoDB"));
            
            // DbContext do MongoDB (Singleton porque mantém a conexão)
            services.AddSingleton<FleetDbContext>();

            // Repositórios (Scoped para seguir o padrão de repositórios)
            services.AddScoped<IFleetRepository, FleetRepository>();

            return services;
        }
    }
}