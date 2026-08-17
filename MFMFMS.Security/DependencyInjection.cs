using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Security.Models;
using MFMFMS.Security.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MFMFMS.Security
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSecurityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(IdentityConstants.BearerScheme)
                .AddBearerToken(IdentityConstants.BearerScheme);

            services.AddAuthorization(options =>
            {
                options.AddPolicy("isAdmin", policy => policy.RequireClaim("isAdmin, true"));
            });

            services.AddDbContext<MFMFMSSecurityDBContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("MFMFMSConnection")));

            services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<MFMFMSSecurityDBContext>()
                .AddApiEndpoints();

            services.AddTransient<IUserService, UserService>();
            services.AddHttpContextAccessor();

            return services;
        }
    }
}
