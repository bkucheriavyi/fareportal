using System;
using FPT.Business.Application.Interfaces;

namespace FPT.Business.Application.Actions
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
