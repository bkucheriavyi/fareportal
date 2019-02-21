﻿using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;

namespace FPT.ConsoleApp
{
    public class Actions<T> where T : IActor
    {
        public const string EXIT_CONST = "exit";

        private readonly IDictionary<int, (string, Action<IActorContext<T>>)> _actions = new SortedDictionary<int, (string, Action<IActorContext<T>>();

        private readonly ILogger _logger;

        public Actions(ILogger logger)
        {
            _logger = logger;
        }

        public void Register(int key, string name, Action<IActorContext<T>> action)
        {
            if (_actions.ContainsKey(key))
            {
                throw new InvalidOperationException($"Sorry ,the item with key {key} was already registered.");
            }

            _actions.Add(key, (name, action));
        }

        public IEnumerable<string> GetActionsInfo()
        {
            foreach (var action in _actions)
            {
                var (name, _) = action.Value;
                yield return $"{action.Key}. {name}";
            }
        }

        public int Run(T actor, TextReader userInput)
        {
            _logger.LogInformation($"Hi {actor.Name}, today is {DateTime.Now.ToShortDateString()}!");

            string input;
            while (!(input = userInput.ReadLine()).Equals(EXIT_CONST, StringComparison.OrdinalIgnoreCase))
            {
                if (!int.TryParse(input, out int actionId))
                {
                    _logger.LogError($" {input} Wrong input, try one more time");
                }

                Execute(actionId, actor);
            }

            return 0;
        }

        private void Execute(int actionId, T actor)
        {
            if (!_actions.ContainsKey(actionId))
            {
                throw new InvalidOperationException($"Sorry {actor.Name}, there is no action registered with #{actionId}");
            }

            var (name, action) = _actions[actionId];

            try
            {
                action(new ActionContext<T>(actor));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unhandled exception occured while action execution.\n#{actionId} {name}", ex);
            }
        }
    }
}