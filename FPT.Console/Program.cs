using System;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FPT.ConsoleApp
{
    class Program
    {
        public static int Main(string[] args)
        {
            var services = Bootstrap();
            var app = new CommandLineApplication<OrderConsoleApplication>();
            app.Conventions
                .UseDefaultConventions()
                .UseConstructorInjection(services);
            return app.Execute(args);
        }

        private static IServiceProvider Bootstrap()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IConsole>(PhysicalConsole.Singleton);
            services.AddScoped<OrderConsoleApplication>();
            ConfigureLogging(services);
            
            return services.BuildServiceProvider();
        }
        
        private static void ConfigureLogging(IServiceCollection serviceCollection)
        {
            serviceCollection.AddLogging(c=> c.AddConsole());
        }
    }
}
