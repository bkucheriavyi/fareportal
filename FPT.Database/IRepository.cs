using System.Collections.Generic;
using FPT.Database;

namespace FPT.Tests
{
    public interface IRepository<T> where T : IWithIntId
     {
        T Create(T item);
        T Update(T item);
        T Get(int id);
        T Delete(T item);

        List<T> GetRange(IEnumerable<int> itemsIds);
     }
}