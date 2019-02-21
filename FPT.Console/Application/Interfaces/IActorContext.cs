using System.IO;

namespace FPT.ConsoleApp
{
    public interface IActorContext<T> where T : IActor
    {
        T Actor { get; }
        TextReader In { get; }
        TextWriter Out { get; }
    }
}