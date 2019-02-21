using System;
using System.Collections.Generic;

namespace FPT.ConsoleApp
{
    internal class Bartender : IActor
    {
        private readonly BarService _barService;

        public string Name { get; }

        public Bartender(string name, BarService barService)
        {
            Name = name;
            _barService = barService;
        }

        internal void CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        internal object CreateOrder()
        {
            var createNewOrderCommand =  new CreateNewOrderCommand();
            throw new NotImplementedException();
        }

        internal Order GetOrder(object id)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<Order> GetAllOpenedOrders()
        {
            throw new NotImplementedException();
        }
    }
}