namespace FPT.Business.Repositories
{
    public interface IBarRepository<T>
    {
        T[] Get(int[] ids);
    }
}