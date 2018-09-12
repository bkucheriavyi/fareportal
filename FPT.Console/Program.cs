using System;

namespace FPT.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");
            string beverageId = args[0];
            string additives = args[1];
        }
    }

    public class Beverage
    {
        public int Id {get;set}
        public string Name {get;set;}
        public double Price {get;set;}
        public DringType DrinkType {get;set}
    }

    [Flags]
    public enum DrinkType : int
    {
        Coffee = 0,
        Tea = 1
    }
    
    public class Additive
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public double Price {get;set;}
        public enum DrinkType AdditiveFor {get; set;}
    }
}
