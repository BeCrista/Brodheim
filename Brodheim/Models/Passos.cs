using System.ComponentModel.DataAnnotations;

namespace Brodheim.Models
{
    public class Passos
    {
        [Key]
        public int ID { get; set; }

        public string? ImagePasso { get; set; }
        [Required]
        public string? DescricaoPasso { get; set; }
    }
}
