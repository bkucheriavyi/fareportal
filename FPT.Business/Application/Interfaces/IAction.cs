namespace FPT.Business.Application.Interfaces
{
    public interface IAction<T> where T : IActor
    {
        void Execute(IActorContext<T> context);
    }
}
