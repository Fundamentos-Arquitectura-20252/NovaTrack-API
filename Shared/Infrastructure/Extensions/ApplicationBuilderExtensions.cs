using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Flota365.Platform.API.Shared.Infrastructure.Middleware;

namespace Flota365.Platform.API.Shared.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSharedMiddleware(this IApplicationBuilder app)
        {
            // Logging middleware
            app.UseMiddleware<RequestLoggingMiddleware>();

            // Global exception handler
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            return app;
        }

        public static IApplicationBuilder UseSharedInfrastructure(this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            app.UseSharedMiddleware();

            // Aquí podrías añadir otras configuraciones globales,
            // como inicializar colas, eventos o health checks.
            
            return app;
        }
    }
}