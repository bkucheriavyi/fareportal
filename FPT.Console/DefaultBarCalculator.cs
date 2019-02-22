using System;
using FPT.ConsoleApp;

namespace FPT.Console
{
    public class DefaultBarCalculator : IBarCalculator
    {
        public double Calculate(Order order)
        {
            double total = 0;
            foreach (var beverage in order.Beverages)
            {
                total += beverage.Price;
                foreach (var additive in beverage.Additives)
                {
                    total += additive.Price;
                }
            }
           
            return total;
        }
    }
}
