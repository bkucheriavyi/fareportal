using System.Collections.Generic;

namespace FPT.ConsoleApp
{
    public class BarService : IBarService
    {
        private readonly IBarRepository<Order> _repository;
        private readonly IBarCalculator _calculator;

        public BarService(IBarRepository<Order> repository, IBarCalculator calculator)
        {
            _repository = repository;
            _calculator = calculator;
        }

        public Order CloseOrder(Order closingOrder)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Additive> GetAdditives(IEnumerable<int> ids)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Beverage> GetBeverages()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Beverage> GetBeverages(IEnumerable<int> ids)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Order> GetClosedOrders()
        {
            throw new System.NotImplementedException();
        }
    }
}