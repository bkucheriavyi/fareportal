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
            var validator = new Validator();
            var barService = new BarService();
            var bartender = new Bartender(!string.IsNullOrEmpty(args[0]) ? args[0] : "", barService);



            var actions = new Actions<Bartender>(null);

            actions.Register(1, "Create order", a =>
            {
                System.Console.WriteLine("Enter beverage:");
                var beverageId = a.
                var order = a.Actor.CreateOrder()
                                   .AddBeverage(beverageId);

                System.Console.WriteLine("Enter additives:");
                var additives = System.Console.ReadLine();

                bartender.GetOrder(order.Id)
                       .AddAdditives(additives);
            });

           // actions.Register(2, "Modify order", () => { });
          //  actions.Register(3, "List orders", () => {
          //      var ordersList = bartender.GetAllOpenedOrders();
          //      System.Console.WriteLine(string.Join("\n", ordersList.Select(o => o.ToString())));
         //  });

            return actions.Run(bartender, System.Console.In);
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
