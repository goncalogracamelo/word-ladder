using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace WordLadderApp.Configurations
{
    public static class Bootstrap
    {
        public static IHostBuilder UseLogging(this IHostBuilder app, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            Log.Logger.Information("Application Starting");

            return app;
        }

    }
}
