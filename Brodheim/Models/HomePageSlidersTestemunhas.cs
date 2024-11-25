using System.ComponentModel.DataAnnotations;

namespace Brodheim.Models
{
    public class HomePageSlidersTestemunhas
    {
        [Key]
        public int ID { get; set; }
        [Required] 
        public string? NamePerson { get; set; }
        [Required]
        public string? PersonPosition { get; set; }
        public string? PersonImage { get; set;}
        [Required]
        public string? Description { get; set;}
    }
}
