using System;
using System.Collections.Generic;

namespace FPT.ConsoleApp
{
    public class Bartender : IActor, IBartender
    {
        private readonly BarService _barService;

        public string Name { get; }

        public Bartender(string name, BarService barService)
        {
            Name = name;
            _barService = barService;
        }

        public Order CreateOrder()
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(object id)
        {
            throw new NotImplementedException();
        }

        public Order AddAdditives(Order order, string additives)
        {
            throw new NotImplementedException();
        }

        public Order CloseOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Order AddBeverage(Order order, string beverageId)
        {
            throw new NotImplementedException();
        }
    }
}