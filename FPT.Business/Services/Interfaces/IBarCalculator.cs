using FPT.Business.Services.Model;

namespace FPT.Business.Services.Interaces
{
    public interface IBarCalculator
    {
        double Calculate(Order order);
    }
}