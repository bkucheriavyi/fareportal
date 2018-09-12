using System;
using System.Collections.Generic;
using FPT.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace FPT.Tests
{
    [TestFixture]
    public class OrderCalculatorTests
    {
        [Test]
        [TestCase(2, 1, 2, 5.0)]
        [TestCase(1, 1, 0, 4.0)]
        [TestCase(2, 0, 0, 2.0)]
        [TestCase(2, -2, 1, -2.0)]
        [TestCase(int.MaxValue, int.MaxValue, 1, 0)]
        [TestCase(int.MinValue, int.MinValue, 1, 0)]
        public void Test_Calculate_ReturnsCorrectSum(int beveragePrice, int additivePrice1, int additivePrice2, double expected)
        {
            //given
            //var orderValidator = Mock.Of<IOrderValidator>(v => v.Validate(order) == new ValidationResult() { Valid = true })
            var calculator = new OrderCalculator();
            var order = new Order
            { 
                Beverages = new List<Beverage>{ new Beverage { Price = beveragePrice } },
                Additives = new List<Additive>{
                    new Additive { Price = additivePrice1 },
                    new Additive { Price = additivePrice2 }
            }};

            //when
            var result = calculator.Calculate(order);

            //then
            Assert.That(result, Is.EqualTo(expected));
        }
        
        [TestMethod]
        public void Test_Calculate_OnlyBeverage(){
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
