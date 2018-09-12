using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FPT.Business;
using FPT.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using ValidationResult = FPT.Business.ValidationResult;

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

    public class OrderProcessor
    {
        private readonly IRepository<Order> _ordersRepository;
        private readonly IEnumerable<IOrderValidator> _validators;
        private readonly IOrderCalculator _calculator;

        public OrderProcessor(IEnumerable<IOrderValidator> validators, IOrderCalculator calculator)
        {
            _validators = validators;
            _calculator = calculator;
        }

        public OrderResult Process(Order order)
        {
            var warnings = new List<ValidationResult>();

            foreach (var validator in _validators)
            {
                var validationResult = validator.Validate(order);
                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.Message);
                }
            }

           var order = _ordersRepository.CreateOrUpdate(order);
           var calculated _calculator.Calculate(order);
            _ordersRepository.CreateOrUpdate()
            return new ProcessedOrder
            {
                Order = order,
                CalcuationResult = orderCalculationResult,
                Warnings = new List<ValidationResult>(),
                Error = new List<ValidationResult>()
            };
        }
    }

     public interface IRepository<T> where T : IWithGuidId
     {
        T Create(T item);
        T Update(T item);
        T Get(int id);
        T Delete(T item);
    }

    public interface IWithIntId
    {
        int Id { get; set; }
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