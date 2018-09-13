using System.ComponentModel.DataAnnotations;

namespace FPT.Database
{
    public interface IWithIntId
    {
        [Key]
        int Id { get; set; }
    }
}