using System.Collections.Generic;
using FPT.Database;

namespace FPT.Business
{
    public class Beverage : IWithIntId
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public List<Additive> Additives { get; set; }
    }
}