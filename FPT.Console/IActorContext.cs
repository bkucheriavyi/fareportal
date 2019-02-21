using System.IO;

namespace FPT.ConsoleApp
{
    public interface IActorContext<T> 
    {
        T Actor { get; }
        TextReader In { get; }
        TextWriter Out { get; }
    }
}