using System.Collections.Generic;
using System.Linq;
using FPT.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace FPT.Tests
{
    [TestFixture]
    public class OrderProcessorTests
    {
        [TestMethod]
        public void Test()
        {
            //given
            double expectedTotal = 100.23;
            var order = new Order();
            var validators = new List<IOrderValidator> {Mock.Of<IOrderValidator>(v => v.Valid() == true)};
            var calculator = Mock.Of<IOrderCalculator>(c => c.Calculate(order) == new OrderCalculationResult {Order = order, Total = expectedTotal});
            var processor = new OrderProcessor(validators, calculator);

            //when
            OrderResult result = processor.Process(order);

            //then
            Assert.That(result.Order, Is.EqualTo(order));
            Assert.That(result.Total, Is.EqualTo(expectedTotal));
        }
    }

    public class OrderProcessorResult 
    {
    }

    public interface IOrderCalculator
    {
        OrderCalculationResult Calculate(Order order);
    }

    public class OrderCalculationResult
    {
        public Order Order { get; set; }

        public double Total { get; set; }
    }
}