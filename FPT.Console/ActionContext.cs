namespace FPT.ConsoleApp
{
    public class ActionContext<T> : IActorContext<T>
    {
        public T Actor { get; private set; }

        public ActionContext(T actor)
        {
            Actor = actor;
        }
    }
}