﻿using System.Collections.Generic;

namespace FPT.ConsoleApp
{
    public class Order
    {
        public Order(int id)
        {
            Id = id;
            Beverages = new List<Beverage>();
        }

        public int Id { get; }

        public List<Beverage> Beverages { get; set; }

        public double Total { get; internal set; }
    }
}