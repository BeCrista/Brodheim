using System.ComponentModel.DataAnnotations;

namespace Brodheim.Models
{
    public class Brands
    {
        [Key]
        public int ID { get; set; }

        public string? ImageBrand { get; set; }

    }
}
