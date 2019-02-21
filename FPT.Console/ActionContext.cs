using System.IO;

namespace FPT.ConsoleApp
{
    public class ActionContext<T> : IActorContext<T> where T: IActor
    {
        public T Actor { get; private set; }
        public TextReader In { get; private set; }
        public TextWriter Out { get; private set; }

        public ActionContext(T actor, TextReader input, TextWriter output)
        {
            Actor = actor;
            In = input;
            Out = output;
        }
    }
}