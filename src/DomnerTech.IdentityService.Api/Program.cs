using Correlate.AspNetCore;
using Correlate.DependencyInjection;
using DomnerTech.IdentityService.Api;
using DomnerTech.IdentityService.Api.ApiDocs;
using DomnerTech.IdentityService.Api.Auth;
using DomnerTech.IdentityService.Api.Middleware;
using DomnerTech.IdentityService.Application;
using System.Reflection;
using DomnerTech.IdentityService.Application.Constants;
using DomnerTech.IdentityService.Infrastructure;
using DomnerTech.IdentityService.Infrastructure.Persistence;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Configuration.AddJsonFile("serilog.json", true, true);
    builder.Logging.ClearProviders();
    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .CreateLogger();
    builder.Host.UseSerilog();
    builder.Services.AddControllerJsonSerializerOptions();
    var appSettings = new AppSettings();
    builder.Configuration.GetRequiredSection("AppSettings").Bind(appSettings);
    builder.Services.AddSingleton(appSettings);
    builder.Services.AddAuth(appSettings);
    builder.Services.AddSwaggerDoc(appSettings, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
    builder.Services.AddCorrelate(options =>
    {
        options.RequestHeaders =
        [
            HeaderConstants.CorrelationId
        ];
    });
    builder.Services.AddOpenIddict()
        .AddCore(options =>
        {
            options.UseEntityFrameworkCore()
                .UseDbContext<IdentityDbContext>();
        })
        .AddServer(options =>
        {
            options.AllowPasswordFlow();

            options.AllowRefreshTokenFlow();

            options.SetTokenEndpointUris("/connect/token");

            options.AcceptAnonymousClients();

            options.AddDevelopmentEncryptionCertificate();

            options.AddDevelopmentSigningCertificate();

            options.UseAspNetCore()
                .EnableTokenEndpointPassthrough();
        })
        .AddValidation(options =>
        {
            options.UseLocalServer();

            options.UseAspNetCore();
        });

    builder.Services.AddHealthChecks();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services
        .AddApplication()
        .AddInfrastructure(appSettings);

    // Middleware
    builder.Services.AddTransient<RequestTimingMiddleware>();
    builder.Services.AddTransient<ErrorHandlingMiddleware>();
    builder.Services.AddTransient<CorrelationIdMiddleware>();

    var app = builder.Build();

    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseSwaggerDoc(appSettings);
    app.UseCorrelate();
    app.UseMiddleware<CorrelationIdMiddleware>();

    app.UseSerilogRequestLogging();
    app.UseMiddleware<RequestTimingMiddleware>();

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapHealthChecks("/healthz");
    app.MapControllers();
    await SeedData.SeedAsync(app.Services);
    await app.RunAsync();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    await Log.CloseAndFlushAsync();
}