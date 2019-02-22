using System.Collections.Generic;

namespace FPT.ConsoleApp
{
    public interface IBarRepository<T>
    {
        List<T> Get(int[] ids);
    }
}