using System;
namespace FPT.Console.Commands
{
    public class CreateOrderCommand : ICommand
    {
        private readonly IBartenderService _service;

        public CreateOrderCommand(IBartenderService service, int orderId, string[] bavarages, string[] additives)
        {
            _service = service;
        }

        public void Execute()
        {
        //    _service.AddOrder();
        }
    }
}
