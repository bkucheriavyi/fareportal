using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FPT.Business;
using ValidationResult = FPT.Business.ValidationResult;

namespace FPT.Tests
{
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
            _ordersRepository.CreateOrUpdate();

            return new ProcessedOrder
            {
                Order = order,
                CalcuationResult = orderCalculationResult,
                Warnings = new List<ValidationResult>(),
                Error = new List<ValidationResult>()
            };
        }
    }
}