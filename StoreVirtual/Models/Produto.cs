using StoreVirtual.Service.Lang;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreVirtual.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        public string Nome { get; set; }
        [Display(Name ="Descrição")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        public string Descricao { get; set; }
        [Display(Name = "Preço")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        public decimal Valor { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [Range(0,1000, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E006")]
        public int Quantidade { get; set; }

        //Frete
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [Range(0.001, 30, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E006")]
        public double Peso { get; set; }

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [Range(11, 105, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E006")]
        public int Largura { get; set; }

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [Range(2, 105, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E006")]
        public int Altura { get; set; }

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [Range(16, 105, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E006")]
        public int Comprimento { get; set; }
        
        [ForeignKey("CategoriaId")]                
        public virtual Categoria Categoria { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        public int CategoriaId { get; set; }

        public virtual ICollection<Imagem> Imagens { get; set; }
    }
}
