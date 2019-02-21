namespace FPT.ConsoleApp
{
    public interface IAction<T> where T : IActor
    {
        void Execute(IActorContext<T> context);
    }
}
