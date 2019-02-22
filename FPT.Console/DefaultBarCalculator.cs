using System;
using FPT.ConsoleApp;

namespace FPT.Console
{
    public class DefaultBarCalculator : IBarCalculator
    {
        public Order Calculate(Order order)
        {
            double sum = 0;
            foreach (var beverage in order.Beverages)
            {
                sum += beverage.Price;
                foreach (var additive in beverage.Additives)
                {
                    sum += additive.Price;
                }
            }
            order.Total = sum;
            return order;
        }
    }
}
