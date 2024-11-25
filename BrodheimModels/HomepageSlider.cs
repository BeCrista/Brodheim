using System.ComponentModel.DataAnnotations;

namespace BrodheimModels
{
    public class HomePageSlider
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string? Title { get; set; }
        [Required]
        public string? SubTitle { get; set; }
        [Required]
        public string? ImageSlider { get; set; }


    }
}