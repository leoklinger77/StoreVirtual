using System.ComponentModel.DataAnnotations.Schema;

namespace StoreVirtual.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Caminho { get; set; }
        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; }
        public int ProdutoId { get; set; }

    }
}
