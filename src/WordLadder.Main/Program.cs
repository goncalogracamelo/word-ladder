using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using WordLadder.Application.Contracts;
using WordLadder.Application.Services.Interfaces;
using WordLadderApp.Configurations;
using WordLadderApp.Contracts;

namespace WordLadderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load parameters
            RequestArgs request = ProcessInputArgs(args);

            //Run Application
            RunApplication(request);

            //Force batched log itens to be published from Log buffers
            Log.CloseAndFlush();
        }

        private static RequestArgs ProcessInputArgs(string[] args)
        {
            //TODO: add input validations
            RequestArgs request = new RequestArgs
            {
                StartWord = args[0],
                EndWord = args[1],
                DictionaryFile = args[2],
                OutputFile = args[3]
            };

            return request;
        }

        private static void RunApplication(RequestArgs request)
        {
            var host = BuildHost();
            
            using var serviceScope = host.Services.CreateScope();

            var mainService = serviceScope.ServiceProvider.GetService<IMainService>();

            //TODO: evaluate if a mapping library should be added
            MainServiceRequest mainServiceRequest = new MainServiceRequest
            {
                StartWord = request.StartWord,
                EndWord = request.EndWord,
                DictionaryFile = request.DictionaryFile,
                OutputFile = request.OutputFile
            };

            mainService.Run(mainServiceRequest);
        }

        private static IHost BuildHost()
        {
            var configurationBuilder = BuildConfigurationBuilder();

            var configuration = configurationBuilder.Build();

            var builder = new HostBuilder()
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.AddConfiguration(configuration);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddAppLogging();

                    services.AddAppIoC(configuration);
                })
                .UseLogging(configuration);

            return builder.Build();
        }

        /// <summary>
        /// Configuration sources (local config file, environment variables, KeyVault, etc)
        /// </summary>
        /// <returns></returns>
        private static IConfigurationBuilder BuildConfigurationBuilder()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables();

            return configurationBuilder;
        }
    }
}
