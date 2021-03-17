using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using WordLadder.Application.Configuration;
using WordLadder.Application.Configuration.Interfaces;
using WordLadder.Application.Data.Repositories;
using WordLadder.Application.Services;
using WordLadder.Application.Services.Interfaces;
using WordLadder.Application.Services.Strategies;
using WordLadder.Application.Services.Strategies.Interfaces;
using WordLadder.Infrastructure.Repositories;

namespace WordLadderApp.Configurations
{
    public static class IoC
    {
        public static IServiceCollection AddAppIoC(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettings = configuration.GetSection(nameof(ApplicationSettings)).Get<ApplicationSettings>();
            services.AddSingleton<IApplicationSettings>(applicationSettings);

            services.AddScoped<IMainService, MainService>();
            services.AddScoped<IFindWordLadderDataFactory, FindWordLadderDataFactory>(); 
            
            services.AddScoped<IFindWordLadderBreadthFirstStrategy, FindWordLadderBreadthFirstStrategy>();
            services.AddScoped<IFindWordLadderDeepFirstStrategy, FindWordLadderDeepFirstStrategy>();

            services.AddSingleton<IOutputFileRepository, OutputFileRepository>();
            services.AddSingleton<IDictionaryFileRepository, DictionaryFileRepository>();
            
            return services;
        }

        public static IServiceCollection AddAppLogging(this IServiceCollection services)
        {
            var loggerFactory = LoggerFactory.Create(c =>
            {
                c.AddSerilog();
            });

            services.AddSingleton<ILoggerFactory>(loggerFactory);

            return services;
        }






    }
}
