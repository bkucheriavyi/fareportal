using System.Collections.Generic;

namespace FPT.ConsoleApp
{
    public class BarService : IBarService
    {
        private readonly IBarRepository<Beverage> _beverages;
        private readonly IBarRepository<Additive> _additives;
        private readonly IBarCalculator _calculator;

        public BarService(IBarRepository<Beverage> beverages, IBarRepository<Additive> additives, IBarCalculator calculator)
        {
            _beverages = beverages;
            _additives = additives;
            _calculator = calculator;
        }

        public Order CloseOrder(Order closingOrder)
        {
            var total = _calculator.Calculate(closingOrder);
            closingOrder.Total = total;
            //TODO:Save order into persistence store and assign unique ID
            //TODO: immutable types?

            return closingOrder;
        }

        public Beverage[] GetBeverages(int[] ids)
        {
            return _beverages.Get(ids);
        }

        public Additive[] GetAdditives(int[] ids)
        {
            return _additives.Get(ids);
        }
    }
}