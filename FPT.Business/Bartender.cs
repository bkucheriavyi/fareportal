using System;
using System.Collections.Generic;
using System.Linq;
using FPT.Business.Services.Interaces;
using FPT.Business.Services.Model;

namespace FPT.Business
{
    public class Bartender : IBartender
    {
        public const char BEVARAGE_STING_SEPARATOR = ',';

        private readonly IBarService _barService;

        private List<Order> _pendingOrders = new List<Order>();

        public string Name { get; }

        public Bartender(string name, IBarService barService)
        {
            Name = name;
            _barService = barService;
        }

        public Order CreateOrder()
        {
            var newOrder =  new Order(_pendingOrders.Count + 1);
            _pendingOrders.Add(newOrder);

            return newOrder;
        }

        public Order CloseOrder(Order order)
        {
            var closingOrder = _pendingOrders.First(o => o.Id == order.Id);
            var closedOrder = _barService.CloseOrder(closingOrder);

            _pendingOrders.Remove(closingOrder);

            return closedOrder;
        }

        public Beverage GetBeverage(string beverageString)
        {
            var (beverageId, err) = this.ParseStringToIntId(beverageString);
            if (err != null)
            {
                throw new InvalidOperationException(err);
            }

            var beverage = _barService.GetBeverages(new int[] { beverageId })
                                      .FirstOrDefault(b => b.Id == beverageId);

            if (beverage == null)
                throw new InvalidOperationException($"No beverages with id {beverageId} were found\n");

            return beverage;
        }

        public List<Additive> GetAdditives(Beverage beverage, string additivesString)
        {
            var (customerAdditivesIds, err) = this.ParseAdditivesString(additivesString);
            if (err != null)
            {
                throw new InvalidOperationException(err);
            }

            var existingAdditives = _barService.GetAdditives(customerAdditivesIds);

            if (existingAdditives.Any(ca => !ca.Group.HasFlag(beverage.Group)))
            {
                throw new InvalidOperationException($"Some of the additives is not be compatible with {beverage.Name}\n");
            }

            return existingAdditives.ToList();
        }

        private (int[], string) ParseAdditivesString(string additivesString)
        {
            var result = additivesString.Split(BEVARAGE_STING_SEPARATOR)
                                        .Select(a=> a.Trim())
                                        .Select(ParseStringToIntId);

            var (_, error) = result.FirstOrDefault(r => r.Error != null);

            if (error != null)
            {
                return (null, error);
            }

            return (result.Select(r => r.Id).ToArray(), null);
        }

        private (int Id, string Error) ParseStringToIntId(string input)
        {
            if (!int.TryParse(input, out int beverageId))
            {
                return (-1, $"Failed to parse string '{input}', integer value expected\n");
            }

            return (beverageId, null);
        }
    }
}