using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MFMFMS.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register the DbContext with the connection string from configuration
            services.AddDbContext<MFMFMSDBContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("MFMFMSConnection")));

            // Register other persistence-related services here if needed
            services.Scan(scan => scan
                .FromAssembliesOf(typeof(DependencyInjection))
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());


            return services;
        }
    }
}
