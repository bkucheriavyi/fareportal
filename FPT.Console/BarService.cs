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
            var calculatedOrder = _calculator.Calculate(closingOrder);

            //TODO:Save order into persistence store, etc
            //TODO: immutable types?
            return calculatedOrder;
        }

        public IEnumerable<Additive> GetAdditives(int[] ids)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Beverage> GetBeverages(int[] ids)
        {
            throw new System.NotImplementedException();
        }
    }
}