using Microsoft.Extensions.DependencyInjection;
using MFMFMS.Infrastructure.PDF;
using MFMFMS.Application.Contracts.PDF;
using MFMFMS.Application.Contracts.Storage;
using MFMFMS.Infrastructure.Storage;

namespace MFMFMS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IMonthlyServiceReportPdfGenerator, MonthlyServiceReportPdfGenerator>();
            services.AddScoped<IImageStorageService, ImageStorageService>();

            return services;
        }
    }
}
