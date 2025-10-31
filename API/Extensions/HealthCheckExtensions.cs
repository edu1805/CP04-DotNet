namespace API.Extensions;

public static class HealthCheckExtensions
{
    public static IServiceCollection AddHealthCheckConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks()
            .AddMongoDb(
                mongodbConnectionString: configuration["MongoDB:ConnectionString"]!,
                name: "mongodb-database",
                timeout: TimeSpan.FromSeconds(3),
                tags: new[] { "database", "mongodb" }
            );

        return services;
    }
}