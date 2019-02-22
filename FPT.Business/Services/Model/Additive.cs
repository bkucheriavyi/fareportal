namespace FPT.Business.Services.Model
{
    public class Additive
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public AdditiveGroup Group { get; set; }
    }
}