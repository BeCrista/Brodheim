using System.ComponentModel.DataAnnotations;

namespace Brodheim.Models
{
    public class Oportunidades
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? NomeTrabalho { get; set; }
        [Required]
        public string? NomeEmpresa { get; set; }

        public string? ImageEmpresa { get; set; }

        [Required]
        public string? Localizacao { get; set; }
        [Required]
        public string? NomeFuncao { get; set; }
        
        [Required]
        public string? DetalhesFuncao { get; set; }

        [Required]
        public string? TipoContrato { get; set; }

        [Required]
        public DateTime DateTrabalho { get; set; }

    }
}
