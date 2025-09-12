using Domain.Interfaces;
using Infrastructure.persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext Oracle
            services.AddDbContext<FleetDbContext>(options =>
                options.UseOracle(configuration.GetConnectionString("OracleConnection")));

            // Repositórios
            services.AddScoped<IFleetRepository, FleetRepository>();

            return services;
        }
    }
}
