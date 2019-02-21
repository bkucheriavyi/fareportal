using System;

namespace FPT.ConsoleApp
{
    public class DefaultBartenderAction : AppAction<IBartender>
    {
        public override void Action(IActorContext<IBartender> context)
        {
            context.Out.WriteLine("Press ENTER");
            context.In.ReadLine();
            throw new NotImplementedException();
        }
    }
}
