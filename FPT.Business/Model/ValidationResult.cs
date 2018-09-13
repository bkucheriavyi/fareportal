namespace FPT.Business
{
    public class ValidationResult
    {
        public string Message { get; set; }
        bool Valid { get; set; }
        public bool IsValid { get; set; }
        public bool IsCritical { get; set; }
    }
}