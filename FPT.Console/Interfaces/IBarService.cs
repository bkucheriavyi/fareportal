using System.Collections.Generic;

namespace FPT.ConsoleApp
{
    public interface IBarService
    {
        Order CloseOrder(Order closingOrder);
        Beverage[] GetBeverages(int[] ids);
        Additive[] GetAdditives(int[] ids);
    }
}