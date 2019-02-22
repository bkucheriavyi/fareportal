using System.Collections.Generic;

namespace FPT.ConsoleApp
{
    public class Beverage
    {
        public Beverage()
        {
            Additives = new List<Additive>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public AdditiveGroup Group {get; set;}

        public List<Additive> Additives { get; set; }
    }
}