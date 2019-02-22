using System.Collections.Generic;

namespace FPT.ConsoleApp
{
    public interface IBarService
    {
        Order CloseOrder(Order closingOrder);
        IEnumerable<Beverage> GetBeverages(int[] ids);
        IEnumerable<Additive> GetAdditives(int[] ids);
    }
}