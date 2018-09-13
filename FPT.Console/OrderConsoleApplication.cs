using System;
using System.Linq;
using FPT.Business;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace FPT.ConsoleApp
{
    public class OrderConsoleApplication: IExecutable
    {
        private readonly ILogger _logger;
        private readonly IConsole _console;
        private readonly IOrderProcessor _orderProcessor;

        public OrderConsoleApplication(ILogger logger, IConsole console, IOrderProcessor orderProcessor)
        {
            _logger = logger;
            _console = console;
            _orderProcessor = orderProcessor;
        }

        public void OnExecute()
        {
            _logger.LogInformation("On execute called");
            DoWhilePromptLoop(() =>
            {
                DoWhilePromptLoop(() =>
                {
                    _console.WriteLine("Please select an action");
                    _console.WriteLine("1. Make order");
                    
                    var action = Prompt.GetInt("");
                    ActionSwitch(action);
                },"");
               
               
            }, "Continue?");
        }

        private void ActionSwitch(int action)
        {
            switch (action)
            {
                case 1:
                {
                    
                    _console.WriteLine("Ok, action 1 pressed.");
                    var order = new Order();
                    do
                    {
                        _console.WriteLine($"Current order status: {order.Beverages}");
                        var beverageId = Prompt.GetInt("Enter a beverage:");
                        var beverage = _db.Beverages.Get(beverageId);
                        if (beverage == null)
                        {
                            _console.WriteLine($"Beverage with id{beverageId} does not exist.");
                            continue;
                        }

                        var additivesString = Prompt.GetString("Enter a additives:");
                        
                        var enteredIds = additivesString
                            .Trim()
                            .Split(',')
                            .Select(c => c.Trim())
                            .Select(TryGetInt)
                            .Where(c => c.HasValue)
                            .ToList();

                        if (enteredIds.Count > 0)
                        {
                            var additives = _db.Additives.Where(a => enteredIds.Contains(a.Id) && a.Type.HasFlag(beverage.Type));

                            if (additives.Length == 0 || enteredIds.Count != additives.Length)
                            {
                                _console.WriteLine($"Additive(s) with id(s): {enteredIds.Except(additives.Select(a => a.Id))} were not found as match for that beverage");
                                continue;
                            }

                            beverage.Additives.AddRange(additives);
                        }

                        order.Beverages.Add(beverage);

                        if (Prompt.GetYesNo("Wanna add one more beverage to order?", false))
                            continue;

                        var result = _orderProcessor.Process(order);
                        _console.WriteLine($"Cost: {result.Total}");

                    } while (!Prompt.GetYesNo("Continue adding to order?", true));

                    break;
                }
            }
        }

        public static int? TryGetInt(string item)
        {
            bool success = int.TryParse(item, out var i);
            return success ? i : null as int?;
        }

        private void DoWhilePromptLoop(Action loopTarget, string message)
        {
            bool skip = false;
            do
            {
                try
                {
                    loopTarget.Invoke();
                }

                catch (Exception ex)
                {
                    _console.WriteLine($"Error:{ex.Message}");
                }
            } while (Prompt.GetYesNo(message, true));

        }
    }

    public interface IExecutable
    {
        void OnExecute();
    }
}

