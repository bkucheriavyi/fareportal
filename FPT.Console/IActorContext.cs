namespace FPT.ConsoleApp
{
    public interface IActorContext<T> where T : IActor
    {
        T Actor { get; }
    }
}