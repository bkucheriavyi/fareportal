using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace FPT.ConsoleApp
{
    class OrderConsoleApplication
    {
        private readonly ILogger _logger;
        private readonly IConsole _console;

        public OrderConsoleApplication(ILogger logger, IConsole console)
        {
            _logger = logger;
            _console = console;
        }

        private void OnExecute()
        {
            _logger.LogInformation("On execute called");
            do
            {
                _console.WriteLine("1. Add order");
                var action = Prompt.GetInt("Please select action:");
                switch (action)
                {
                    case 1:
                    {
                        _console.WriteLine("Ok, action 1 pressed");
                        break;
                    }

                    default:
                    {
                        _console.WriteLine("Unknown action, sorry, try again");
                        break;
                    }
                }

            } while (Prompt.GetYesNo("Continue?", true));
           
        }
    }
}
