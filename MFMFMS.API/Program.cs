using DotNetEnv;
using MFMFMS.API.Middleware;
using MFMFMS.Application;
using MFMFMS.Persistence;
using MFMFMS.Security;
using MFMFMS.Security.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

Env.TraversePath().Load();

// Add services to the container.

builder.Services.AddControllers();

builder.Configuration.AddEnvironmentVariables();
builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddSecurityServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var app = builder.Build();

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
