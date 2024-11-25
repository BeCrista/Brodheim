using System.ComponentModel.DataAnnotations;

namespace Brodheim.Models
{
    public class QuemSomos
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? NameRepresentative { get; set; }

        [Required]
        public int QuantityRepresentative { get; set; }
        public string? ImageRepresentative { get; set;}
    }
}
