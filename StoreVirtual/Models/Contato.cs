using System.ComponentModel.DataAnnotations;
namespace StoreVirtual.Models
{
    public class Contato
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(1000)]
        public string Texto { get; set; }
    }
}
