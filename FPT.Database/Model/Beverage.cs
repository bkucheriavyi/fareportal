using System;
using System.Collections.Generic;
using System.Text;

namespace FPT.Database.Model
{
    public class Beverage
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public BeverageType Type { get; set; }
    }

    public enum BeverageType
    {
        Coffee,
        Tea,
        Water,
        Other
    }

    public class Additive
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
    }
}
