using System.Collections.Generic;

namespace FPT.ConsoleApp
{
    public interface IBartender : IActor
    {
        Order CreateOrder();
        Order CloseOrder(Order order);

        Beverage GetBeverage(string beverageId);
        List<Additive> GetAdditives(Beverage beverage, string additivesString);
    }
}