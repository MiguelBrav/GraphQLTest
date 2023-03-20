using GraphQLServer.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQLServer.Extensions
{
    public static class Extensions
    {

        public static async Task ConfigMigraciones(this WebApplication app)
        {
            var scope = app.Services.CreateScope();

            var services = scope.ServiceProvider;

            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {

                var context = services.GetRequiredService<Context>();

                await context.Database.MigrateAsync();

                await ContextSeed.SeedAsync(context, loggerFactory);
            }
            catch (Exception ex)
            {

                var logger = loggerFactory.CreateLogger<Program>();

                logger.LogError(ex, "Ocurrió un error durante la migración");

            }
        }
    }
}
