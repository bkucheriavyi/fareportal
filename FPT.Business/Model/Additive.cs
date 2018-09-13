using FPT.Database;
using FPT.Tests;

namespace FPT.Business
{
    public class Additive : IWithIntId
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public DrinkType AdditiveFor { get; set; }
    }
}