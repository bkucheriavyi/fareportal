using System;
using System.Collections.Generic;

namespace FPT.ConsoleApp
{
    public class Order
    {
        public int Id { get; set; }

        public List<Beverage> Beverages { get; set; }

        public List<Additive> Additives { get; set; }

        public double Total { get; internal set; }
    }
}