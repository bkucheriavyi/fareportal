using System.Collections.Generic;

namespace FPT.ConsoleApp
{
    public class CreateOneBeverageOrderAction : AppAction<IBartender>
    {
        public override void Action(IActorContext<IBartender> context)
        {
            context.Out.WriteLine("Enter beverage:");
            var beverageId = context.In.ReadLine();
            Beverage beverage = context.Actor.GetBeverage(beverageId);

            context.Out.WriteLine("Enter additives:");
            var additivesString = context.In.ReadLine();
            List<Additive> additives = context.Actor.GetAdditives(beverage, additivesString);

            var order = context.Actor.CreateOrder();
            beverage.Additives = additives;
            order.Beverages.Add(beverage);

            order = context.Actor.CloseOrder(order);

            context.Out.WriteLine($"Cost: ${order.Total}");
        }
    }
}
