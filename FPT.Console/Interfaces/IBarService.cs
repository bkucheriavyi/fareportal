using System.Collections.Generic;

namespace FPT.ConsoleApp
{
    public interface IBarService
    {
        Order CloseOrder(Order closingOrder);
        IEnumerable<Order> GetClosedOrders();
        IEnumerable<Beverage> GetBeverages(IEnumerable<int> ids);
        IEnumerable<Additive> GetAdditives(IEnumerable<int> ids);
    }
}