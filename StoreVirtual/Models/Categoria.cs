using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoreVirtual.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Slug { get; set; }
        [ForeignKey("CategoriaPaiId")]
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
