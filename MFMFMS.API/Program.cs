using DotNetEnv;
using MFMFMS.API.Middleware;
using MFMFMS.Application;
using MFMFMS.Persistence;
using MFMFMS.Security;
using MFMFMS.Security.Models;
using MFMFMS.Security.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

Env.TraversePath().Load();

// Add services to the container.

builder.Services.AddControllers(options =>
    options.Filters.Add(new AuthorizeFilter("isAdmin"))
)
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(
        new JsonStringEnumConverter());
});

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddOpenApi();

builder.Services.AddSecurityServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider
        .GetRequiredService<UserManager<User>>();

    await SecuritySeeder.SeedAdminAsync(userManager);
}

app.MapIdentityApi<User>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCustomExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
