using System;
using System.Collections.Generic;

namespace FPT.Business
{

    public interface IOrderValidator
    {
        ValidationResult Validate(Order order);
        bool Valid();
    }

    public class ValidationResult
    {
        public string Message { get; set; }
        bool Valid { get; set; }
        public bool IsValid { get; set; }
        public bool IsCritical { get; set; }
    }

    [Flags]
    public enum DrinkType : int
    {
        Coffee = 0,
        Tea = 1
    }

    public class Beverage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DrinkType DrinkType { get; set; }
    }

    public class Additive
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DrinkType AdditiveFor { get; set; }
    }

    public class Order
    {
        public List<Beverage> Beverages { get; set; }

        public List<Additive> Additives { get; set; }
    }
}
