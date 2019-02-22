using System;
using FPT.Business.Application.Interfaces;

namespace FPT.Business.Application
{
    public abstract class AppAction<T> : IAction<T> where T : IActor
    {
        public abstract void Action(IActorContext<T> context);

        public virtual void Execute(IActorContext<T> context)
        {
            while (true)
            {
                try
                {
                    this.Action(context);
                    break;
                }
                catch (InvalidOperationException ex)
                {
                    context.Out.WriteLine(ex.Message);
                    continue;
                }
                catch (Exception ex)
                {
                    context.Out.WriteLine($"Sorry, an error occured: {ex.Message}, please, try again");
                    continue;
                }
            }
        }
    }
}
