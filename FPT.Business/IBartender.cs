using System.Collections.Generic;
using FPT.Business.Application.Interfaces;
using FPT.Business.Services.Model;

namespace FPT.Business
{
    public interface IBartender : IActor
    {
        Order CreateOrder();
        Order CloseOrder(Order order);

        Beverage GetBeverage(string beverageId);
        List<Additive> GetAdditives(Beverage beverage, string additivesString);
    }
}