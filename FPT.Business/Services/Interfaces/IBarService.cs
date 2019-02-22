using FPT.Business.Services.Model;

namespace FPT.Business.Services.Interaces
{
    public interface IBarService
    {
        Order CloseOrder(Order closingOrder);
        Beverage[] GetBeverages(int[] ids);
        Additive[] GetAdditives(int[] ids);
    }
}