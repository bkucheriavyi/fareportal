using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FPT.Tests;

namespace FPT.Business
{
    public class OrderBuilder
    {
        private readonly IRepository<Beverage> _beveragesRepository;
        private readonly IRepository<Additive> _additivesRepository;

        private Order _order = new Order
        {
            Beverages = new List<Beverage>(),
            Additives = new List<Additive>()
        };

        public OrderBuilder()
        {
            
        }

        public OrderBuilder AddBeverages(int beverageId)
        {
           var beverage = _beveragesRepository.Get(beverageId);
           if (beverage == null)
                throw new KeyNotFoundException($"Beverage with id {beverageId} was not found.");

           _order.Beverages.AddRange(beverages);
           return beverage;
        }

        public OrderBuilder AddAdditives(Beverage beverage, IEnumerable<int> additives)
        {

        }

        public Order BuildOrder(int[] additiveIds, int[] beverageIds)
        {
            return _order;
        }

        public void Clear()
        {
            _order = new Order
            {
                Beverages = new List<Beverage>(),
                Additives = new List<Additive>()
            };
        }
    } 
}
