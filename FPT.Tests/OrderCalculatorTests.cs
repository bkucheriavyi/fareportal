using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FPT.Tests
{
    [TestClass]
    public class OrderCalculatorTests
    {
        [TestMethod]
        [TestCase(2, 1, 2, 5.0)]
        [TestCase(1, 1, 0, 4.0)]
        [TestCase(2, 0, 0, 2.0)]
        [TestCase(2, -2, 1, -2.0)]
        [TestCase(Int.Max, Int.Max, 1, 0)]
        [TestCase(Int.Min, Int.Min, 1, 0)]
        public void Test_Calculate_ReturnsCorrectSum(int beveragePrice, int additivePrice1, int additivePrice2, double expected)
        {
            //given
            //var orderValidator = Mock.Of<IOrderValidator>(v => v.Validate(order) == new ValidationResult() { Valid = true })
            var calculator = new OrderCalculator();
            var order = new Order() { 
                Drinks = new List<Beverage>{ new Beverage { Price = beveragePrice } },
                Additives = new List<Additive>{
                    new Additive { Price = additivePrice1 }
                    new Additive { Price = additivePrice2 }
            }};

            //when
            var result = calculator.Calculate(order)

            //then
            Assert.That(result, Is.EqualTo(expected))
        }
        
        [TestMethod]
        public void Test_Calculate_OnlyBavarage(){
            //given
            //when
            //then
        }

        [TestMethod]
        public void Test_Calculate_OnlyAdditives(){
            //given
            //when
            //then
        }

        [TestMethod]
        public void Test_Calculate_EmptyOrder(){
            //given
            //when
            //then
        }
    }
}
