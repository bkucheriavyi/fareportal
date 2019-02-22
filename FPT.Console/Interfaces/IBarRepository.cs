using System.Collections.Generic;

namespace FPT.ConsoleApp
{
    public interface IBarRepository<T>
    {
        T[] Get(int[] ids);
    }
}