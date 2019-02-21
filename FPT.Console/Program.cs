using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FPT.ConsoleApp
{
    class Program
    {
        public static int Main(string[] args)
        {
            var barService = new BarService();
            var bartender = new Bartender("Joe", barService);

            var actions = new Actions<Bartender>();

            actions.Register(1, "Create order", a =>
            {
                while (true)
                {
                    try
                    {
                        a.Out.WriteLine("Enter beverage:");
                        var beverageId = a.In.ReadLine();
                        var order = a.Actor.CreateOrder();
                        order = a.Actor.AddBeverage(order, beverageId);

                        a.Out.WriteLine("Enter additives:");
                        var additives = a.In.ReadLine();

                        order = a.Actor.AddAdditives(order, additives);
                        order = a.Actor.CloseOrder(order);

                        a.Out.WriteLine($"Cost: ${order.Total}");

                        break;
                    }
                    catch (Exception ex)
                    {
                        a.Out.WriteLine($"Sorry, an error occured: {ex.Message}, please, try again");
                        continue;
                    }
                }
            });

            return actions.Run(bartender, System.Console.In, System.Console.Out);
        }

        private static IServiceProvider Bootstrap()
        {
            var services = new ServiceCollection();
            //services.AddScoped<OrderConsoleApplication>();


            services.AddLogging(c => c.AddConsole());

            return services.BuildServiceProvider();
        }
    }

    //  public static DoWhile

}
