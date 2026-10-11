using Microsoft.Extensions.DependencyInjection;
using MFMFMS.Infrastructure.PDF;
using MFMFMS.Application.Contracts.PDF;

namespace MFMFMS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IMonthlyServiceReportPdfGenerator, MonthlyServiceReportPdfGenerator>();

            return services;
        }
    }
}
