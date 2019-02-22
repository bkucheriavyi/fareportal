using System;
using FPT.Console;
using Microsoft.Extensions.DependencyInjection;

namespace FPT.ConsoleApp
{
    class Program
    {
        public static int Main(string[] args)
        {
            var barService = new BarService(new DefaultBeveragesRepository(),
                                            new DefaultAdditivesRepository(),
                                            new DefaultBarCalculator());
            var bartender = new Bartender("Joe", barService);

            var app = new ConsoleApplication<IBartender>();

            app.Register(1, "Create order", new CreateOneBeverageOrderAction());
            app.Register(2, "Modify opened order", new DefaultBartenderAction());
            app.Register(3, "List closed orders", new DefaultBartenderAction());
            app.Register(4, "Close all pending orders", new DefaultBartenderAction());

            return app.Run(bartender, System.Console.In, System.Console.Out);
        }

        private static IServiceProvider Bootstrap()
        {
            var services = new ServiceCollection();
            //TODO: add registrations
            return services.BuildServiceProvider();
        }
    }
}
