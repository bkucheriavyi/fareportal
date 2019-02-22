using System;
using System.Collections.Generic;
using FPT.Console;
using FPT.ConsoleApp;
using NUnit.Framework;

namespace FPT.Tests
{
    [TestFixture]
    public class DefaultBarCalculatorTests
    {
        [Test]
        public void Calculate_ReturnsOrderWithTotalSet()
        {
            //given
            var order = new Order(1)
            {
                Beverages = new List<Beverage>
                {
                    new Beverage
                    {
                        Price = 5,
                        Additives = new List<Additive>
                        {
                            new Additive { Price = 2 },
                            new Additive { Price = 2 },
                            new Additive { Price = 1 },
                        }
                    },
                    new Beverage
                    {
                        Price = 15,
                        Additives = new List<Additive>
                        {
                            new Additive { Price = 1 },
                            new Additive { Price = 1 },
                            new Additive { Price = 1 },
                        }
                    }
                }
            };
            
            var calculator = new DefaultBarCalculator();

            //when
            var result = calculator.Calculate(order);

            //then
            Assert.That(result.Total, Is.EqualTo(28));
        }

        [Test]
        public void Calculate_OrderContainsNoItems_ReturnsOrderWithTotalZero()
        {
            //given
            var order = new Order(1);
            var calculator = new DefaultBarCalculator();

            //when
            var result = calculator.Calculate(order);

            //then
            Assert.That(result.Total, Is.EqualTo(0));
        }
    }
}
