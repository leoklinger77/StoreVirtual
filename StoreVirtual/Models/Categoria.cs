using StoreVirtual.Service.Lang;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreVirtual.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(3, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E002")]
        public string Nome { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(3, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E002")]
        
        public string Slug { get; set; }
        [ForeignKey("CategoriaPaiId")]
        [Display(Name = "Categoria Pai")]
        public virtual Categoria CategoriaPai { get; set; }        
        public int? CategoriaPaiId { get; set; }

        public Categoria()
        {
        }

        public Categoria(int id, string nome, string slug, Categoria categoriaPai)
        {
            Id = id;
            Nome = nome;
            Slug = slug;
            CategoriaPai = categoriaPai;
        }
    }
}
