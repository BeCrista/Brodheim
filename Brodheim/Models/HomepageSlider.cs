using System.ComponentModel.DataAnnotations;

namespace Brodheim.Models
{
    public class HomePageSlider
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string? Title { get; set; }
        [Required]
        public string? SubTitle { get; set; }
        public string? ImageSlider { get; set; }


    }
}