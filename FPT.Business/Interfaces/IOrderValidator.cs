namespace FPT.Business
{
    public interface IOrderValidator
    {
        ValidationResult Validate(Order order);
    }
}