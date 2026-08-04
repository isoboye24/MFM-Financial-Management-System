using MFMFMS.Application.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace MFMFMS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IMediator, SimpleMediator>();

            services.Scan(scan => scan
                .FromAssembliesOf(typeof(DependencyInjection))
                .AddClasses(c => c.AssignableTo(typeof(IRequestHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
                .AddClasses(c => c.AssignableTo(typeof(IRequestHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
